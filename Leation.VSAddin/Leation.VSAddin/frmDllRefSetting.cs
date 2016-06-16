using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using EnvDTE;
using EnvDTE80;
using VSLangProj;

namespace Leation.VSAddin
{
    public partial class frmDllRefSetting : Form
    {
        private DTE2 _app = null;
        private readonly string ConfigFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Leation.VSAddin\frmDllRefSetting.config");
        private readonly string ThirdDllPathConfigFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Leation.VSAddin\ThirdDllPath.config");
        private DirectoryModel _dirModel = null;
        private DirectoryModel _dotNetBarDirModel = null;
        private DirectoryModel _infragisticsDirModel = null;

        public frmDllRefSetting(DTE2 app)
        {
            InitializeComponent();

            _app = app;

            List<Project> pros = ProjectUtility.GetAllProjects(_app);
            if (pros != null && pros.Count > 0)
            {
                for (int i = 0; i < pros.Count; i++)
                {
                    this.combProjects.Items.Add(pros[i].Name);
                }
                this.combProjects.Tag = pros;

                //获取所有解决方案配置名称
                string activeConfigName = string.Empty;
                for (int i = 0; i < pros.Count; i++)
                {
                    foreach (Configuration config in pros[i].ConfigurationManager)
                    {
                        activeConfigName = pros[i].ConfigurationManager.ActiveConfiguration.ConfigurationName;

                        string configName = config.ConfigurationName;
                        if (this.combSolutionPlatform.Items.Contains(configName) == false)
                        {
                            this.combSolutionPlatform.Items.Add(configName);
                        }
                    }
                }
                if (this.combSolutionPlatform.Items.Count > 0)
                {
                    this.combSolutionPlatform.SelectedItem = activeConfigName;
                }
            }

            this.LoadUserConfig();

            this.LoadThirdDllPathUserConfig();
        }

        private void frmDllRefSetting_Load(object sender, EventArgs e)
        {
            if (this.combProjects.Items.Count > 0)
            {
                this.combProjects.SelectedIndex = 0;
            }
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.rMenu.Show(this.dataGridView1, e.Location);
            }
        }

        private void combProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            if (this.combProjects.SelectedItem == null)
            {
                return;
            }
            List<Project> pros = this.combProjects.Tag as List<Project>;
            if (pros == null)
            {
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            Project selProj = pros[this.combProjects.SelectedIndex];
            VSProject vsProj = selProj.Object as VSProject;
            References dllRefs = vsProj.References;
            this.dataGridView1.Tag = dllRefs;
            int index=0;
            foreach (Reference dllRef in dllRefs)
            {
                if (this.IsNeedChangePath(dllRef.Path) == false)
                {
                    continue;
                }
                this.dataGridView1.Rows.Add(1);
                this.dataGridView1[0, index].Value = dllRef.Name;
                string dllPath = dllRef.Path;
                this.dataGridView1[1, index].Value = dllPath;
                if (string.IsNullOrEmpty(dllPath) == false && File.Exists(dllPath) == false)
                {
                    this.dataGridView1.Rows[index].DefaultCellStyle.ForeColor = Color.Salmon;
                }
                this.dataGridView1.Rows[index].Tag = dllRef;
                
                index++;
            }
            this.Cursor = Cursors.Default;
        }

        private void btnLibRootDir_Click(object sender, EventArgs e)
        {
            string dllRootDir = this.txtLibRootDir.Text.Trim();
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (string.IsNullOrEmpty(dllRootDir) == false && Directory.Exists(dllRootDir))
            {
                fbd.SelectedPath = dllRootDir;
            }
            else
            {
                string slnPath = _app.Solution.FileName;
                string dir = Path.GetDirectoryName(slnPath);
                fbd.SelectedPath = this.FindLibDir(dir);
            }
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                this.txtLibRootDir.Text = fbd.SelectedPath;
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.dataGridView1.SelectedRows == null || this.dataGridView1.SelectedRows.Count > 1 || this.dataGridView1.SelectedRows.Count==0)
            {
                return;
            }
            DataGridViewRow selRow = this.dataGridView1.SelectedRows[0];

            References dllRefs = this.dataGridView1.Tag as References;
            Reference dllRef = selRow.Tag as Reference;
            if (dllRefs == null || dllRef == null)
            {
                return;
            }

            string dllRootDir = this.txtLibRootDir.Text.Trim();
            if (string.IsNullOrEmpty(dllRootDir) || Directory.Exists(dllRootDir) == false)
            {
                MsgBox.ShowTip("请先输入Lib根目录");
                return;
            }
            frmSelDllRef frm = new frmSelDllRef(dllRootDir);
            frm.SelDllPath = selRow.Cells[1].Value.ToString();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                selRow.Tag = null;
                dllRef.Remove();

                try
                {
                    dllRef = dllRefs.Add(frm.SelDllPath);
                }
                catch
                {
                }
                selRow.Tag = dllRef;
                selRow.Cells[0].Value = Path.GetFileNameWithoutExtension(frm.SelDllPath);
                selRow.Cells[1].Value = frm.SelDllPath;
            }
        }

        private void rMenuModifyAll_Click(object sender, EventArgs e)
        {
            if (this.combProjects.Tag == null)
            {
                return;
            }
            string dllRootDir = this.txtLibRootDir.Text.Trim();
            string dotNetBarDir = this.txtDotNetBarDir.Text.Trim();
            string infragisticsDir = this.txtInfragisticsDir.Text.Trim();
            
            if (string.IsNullOrEmpty(dllRootDir) || Directory.Exists(dllRootDir) == false)
            {
                MsgBox.ShowTip("请先输入Lib根目录");
                return;
            }
            bool proItemFirst = this.chkProItemFirst.Checked;
            string solPlatform = this.combSolutionPlatform.SelectedItem.ToString();

            this.Cursor = Cursors.WaitCursor;

            //读取lib和第三方类库
            _dirModel = FileDirUtility.ReadAllDirAndFiles(dllRootDir);
            if (string.IsNullOrEmpty(dotNetBarDir) == false && Directory.Exists(dotNetBarDir))
            {
                _dotNetBarDirModel = FileDirUtility.ReadAllDirAndFiles(dotNetBarDir);
            }
            if (string.IsNullOrEmpty(infragisticsDir) == false && Directory.Exists(infragisticsDir))
            {
                _infragisticsDirModel = FileDirUtility.ReadAllDirAndFiles(infragisticsDir);
            }

            List<Project> prjList = this.combProjects.Tag as List<Project>;
            for (int p = 0; p < prjList.Count; p++)
            {
                VSProject vsProj = prjList[p].Object as VSProject;
                References dllRefs = vsProj.References;
                if (dllRefs == null)
                {
                    continue;
                }
                foreach (Reference dllRef in dllRefs)
                {
                    if (this.IsNeedChangePath(dllRef.Path) == false)
                    {
                        continue;
                    }
                    //优先引用项目，再引用lib下的dll
                    Project bestSimilarProj = null;
                    if (proItemFirst)
                    {
                        string dllName = dllRef.Name;
                        bestSimilarProj = this.FindProItem(dllName, solPlatform);
                        if (bestSimilarProj != null)
                        {
                            string dllFilePath = this.GetOutPutDllPath(bestSimilarProj,solPlatform);
                            if (dllFilePath.Equals(dllRef.Path, StringComparison.CurrentCultureIgnoreCase))
                            {
                                continue;
                            }
                            dllRef.Remove();
                            dllRefs.AddProject(bestSimilarProj);
                        }
                    }
                    if (bestSimilarProj==null)
                    {
                        List<string> similarDlls = new List<string>();
                        if (_dotNetBarDirModel != null && dllRef.Name.ToUpper().Contains("DevComponents".ToUpper()))
                        {
                            this.FindSimilarDlls(_dotNetBarDirModel, dllRef.Name, ref similarDlls);
                        }
                        else if (_infragisticsDirModel != null && dllRef.Name.ToUpper().Contains("Infragistics".ToUpper()))
                        {
                            this.FindSimilarDlls(_infragisticsDirModel, dllRef.Name, ref similarDlls);
                        }
                        if (similarDlls.Count == 0)
                        {
                            this.FindSimilarDlls(_dirModel, dllRef.Name, ref similarDlls);
                        }
                        if (similarDlls.Count < 1)
                        {
                            continue;
                        }
                        string bestSimilarDll = similarDlls[0];
                        if (similarDlls.Count > 1)
                        {
                            double maxSim = double.MinValue;
                            int maxSimIndex = 0;
                            for (int j = 0; j < similarDlls.Count; j++)
                            {
                                double sim = StrSimCalculator.CalculateSim(similarDlls[j], dllRef.Path);
                                if (maxSim < sim)
                                {
                                    maxSim = sim;
                                    maxSimIndex = j;
                                }
                            }
                            bestSimilarDll = similarDlls[maxSimIndex];
                        }
                        if (bestSimilarDll.Equals(dllRef.Path, StringComparison.CurrentCultureIgnoreCase))
                        {
                            continue;
                        }
                        dllRef.Remove();
                        try
                        {
                            dllRefs.Add(bestSimilarDll);
                        }
                        catch
                        {
                        }
                    }                 
                }
            } 
            this.combProjects_SelectedIndexChanged(null, null);
            this.Cursor = Cursors.Default;
        }

        private void rMenuModifySelection_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows == null || this.dataGridView1.SelectedRows.Count < 1)
            {
                return;
            }
            References dllRefs = this.dataGridView1.Tag as References;
            if (dllRefs == null)
            {
                return;
            }
            string dllRootDir = this.txtLibRootDir.Text.Trim();
            string dotNetBarDir = this.txtDotNetBarDir.Text.Trim();
            string infragisticsDir = this.txtInfragisticsDir.Text.Trim();

            if (string.IsNullOrEmpty(dllRootDir) || Directory.Exists(dllRootDir) == false)
            {
                MsgBox.ShowTip("请先输入Lib根目录");
                return;
            }
            bool proItemFirst = this.chkProItemFirst.Checked;
            string solPlatform=this.combSolutionPlatform.SelectedItem.ToString();

            this.Cursor = Cursors.WaitCursor;

            //读取lib和第三方类库
            _dirModel = FileDirUtility.ReadAllDirAndFiles(dllRootDir);
            if (string.IsNullOrEmpty(dotNetBarDir) == false && Directory.Exists(dotNetBarDir))
            {
                _dotNetBarDirModel = FileDirUtility.ReadAllDirAndFiles(dotNetBarDir);
            }
            if (string.IsNullOrEmpty(infragisticsDir) == false && Directory.Exists(infragisticsDir))
            {
                _infragisticsDirModel = FileDirUtility.ReadAllDirAndFiles(infragisticsDir);
            }

            for (int i = 0; i < this.dataGridView1.SelectedRows.Count; i++)
            {
                DataGridViewRow selRow = this.dataGridView1.SelectedRows[i];
                Reference dllRef = selRow.Tag as Reference;
                if (dllRef == null)
                {
                    continue;
                }
                //优先引用项目，再引用lib下的dll
                Project bestSimilarProj = null;
                if (proItemFirst)
                {
                    string dllName = dllRef.Name;
                    bestSimilarProj = this.FindProItem(dllName, solPlatform);
                    string bestSimilarDll = this.FindProItemOutPath(dllName, solPlatform);
                    if (bestSimilarProj != null)
                    {
                        string dllFilePath = this.GetOutPutDllPath(bestSimilarProj, solPlatform);
                        if (dllFilePath.Equals(dllRef.Path, StringComparison.CurrentCultureIgnoreCase))
                        {
                            continue;
                        }

                        selRow.Tag = null;
                        dllRef.Remove();

                        dllRef = dllRefs.AddProject(bestSimilarProj);

                        selRow.Tag = dllRef;
                        selRow.Cells[0].Value = Path.GetFileNameWithoutExtension(bestSimilarDll);
                        selRow.Cells[1].Value = bestSimilarDll;
                    }
                }
                if (bestSimilarProj == null)
                {
                    List<string> similarDlls = new List<string>();
                    if (_dotNetBarDirModel != null && dllRef.Name.ToUpper().Contains("DevComponents".ToUpper()))
                    {
                        this.FindSimilarDlls(_dotNetBarDirModel, dllRef.Name, ref similarDlls);
                    }
                    else if (_infragisticsDirModel != null && dllRef.Name.ToUpper().Contains("Infragistics".ToUpper()))
                    {
                        this.FindSimilarDlls(_infragisticsDirModel, dllRef.Name, ref similarDlls);
                    }
                    if (similarDlls.Count == 0)
                    {
                        this.FindSimilarDlls(_dirModel, dllRef.Name, ref similarDlls);
                    }
                    if (similarDlls.Count < 1)
                    {
                        continue;
                    }
                    string bestSimilarDll = similarDlls[0];
                    if (similarDlls.Count > 1)
                    {
                        double maxSim = double.MinValue;
                        int maxSimIndex = 0;
                        for (int j = 0; j < similarDlls.Count; j++)
                        {
                            double sim = StrSimCalculator.CalculateSim(similarDlls[j], dllRef.Path);
                            if (maxSim < sim)
                            {
                                maxSim = sim;
                                maxSimIndex = j;
                            }
                        }
                        bestSimilarDll = similarDlls[maxSimIndex];
                    }
                    if (bestSimilarDll.Equals(dllRef.Path, StringComparison.CurrentCultureIgnoreCase))
                    {
                        continue;
                    }

                    selRow.Tag = null;
                    dllRef.Remove();

                    try
                    {
                        dllRef = dllRefs.Add(bestSimilarDll);
                    }
                    catch
                    {
                    }
                    selRow.Tag = dllRef;
                    selRow.Cells[0].Value = Path.GetFileNameWithoutExtension(bestSimilarDll);
                    selRow.Cells[1].Value = bestSimilarDll;
                }           
            }
            this.Cursor = Cursors.Default;
        }

        private void rMenuAddRefs_Click(object sender, EventArgs e)
        {
            string dllRootDir = this.txtLibRootDir.Text.Trim();
            if (string.IsNullOrEmpty(dllRootDir) || Directory.Exists(dllRootDir) == false)
            {
                MsgBox.ShowTip("请先输入Lib根目录");
                return;
            }
            References dllRefs = this.dataGridView1.Tag as References;
            if (dllRefs == null)
            {
                return;
            }
            List<string> existDlls = new List<string>();
            foreach (Reference dllRef in dllRefs)
            {
                existDlls.Add(dllRef.Name);
            }
            frmMutiSelDllRef frm = new frmMutiSelDllRef(dllRootDir);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                List<string> selDlls = frm.SelDllPaths;
                for (int i = 0; i < selDlls.Count; i++)
                {
                    string dllName = Path.GetFileNameWithoutExtension(selDlls[i]);
                    if (existDlls.Contains(dllName)==false)
                    {
                        try
                        {
                            dllRefs.Add(selDlls[i]);
                        }
                        catch
                        {
                        }
                    }
                }
                this.combProjects_SelectedIndexChanged(null, null);
                this.Cursor = Cursors.Default;
            }
        }

        private void btnRemoveRefs_Click(object sender, EventArgs e)
        {
            References dllRefs = this.dataGridView1.Tag as References;
            if (dllRefs == null)
            {
                return;
            }
            DataGridViewSelectedRowCollection selRows = this.dataGridView1.SelectedRows;
            if (selRows == null || selRows.Count < 1)
            {
                return;
            }
            if (MsgBox.ShowOkCancel("确认删除？")== System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            for (int i = 0; i < selRows.Count; i++)
            {
                Reference dllRef = selRows[i].Tag as Reference;
                if (dllRef != null)
                {
                    dllRef.Remove();
                    this.dataGridView1.Rows.Remove(selRows[i]);
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void frmDllRefSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.SaveUserConfig();

            this.SaveThirdDllPathUserConfig();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// 加载用户配置信息
        /// </summary>
        private void LoadUserConfig()
        {
            try
            {
                string slnPath = _app.Solution.FileName;
                string dir = Path.GetDirectoryName(slnPath);
                this.txtLibRootDir.Text = this.FindLibDir(dir);

                if (File.Exists(ConfigFilePath) == false)
                {
                    return;
                }
                string[] contexts = File.ReadAllLines(ConfigFilePath, Encoding.UTF8);
                if (contexts != null && contexts.Length > 0)
                {
                    //以sln的路径为键
                    for (int i = 0; i < contexts.Length; i++)
                    {
                        if (contexts[i].StartsWith(slnPath, StringComparison.CurrentCultureIgnoreCase))
                        {
                            string[] strArray = contexts[i].Split('=');
                            if (strArray != null && strArray.Length == 2 && Directory.Exists(strArray[1]))
                            {
                                this.txtLibRootDir.Text = strArray[1];
                            }
                            break;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 保存用户配置信息，在protected override void Dispose(bool disposing)方法中调用
        /// </summary>
        private void SaveUserConfig()
        {
            try
            {
                List<string> contexts = new List<string>();
                if (File.Exists(ConfigFilePath) == false)
                {
                    string dir = Path.GetDirectoryName(ConfigFilePath);
                    if (Directory.Exists(dir) == false)
                    {
                        Directory.CreateDirectory(dir);
                    }
                    File.Create(ConfigFilePath).Close();
                }
                else
                {
                    string[] temp = File.ReadAllLines(ConfigFilePath, Encoding.UTF8);
                    if (temp != null && temp.Length > 0)
                    {
                        contexts.AddRange(temp);
                    }
                }
                //以sln的路径为键
                string slnPath = _app.Solution.FileName;
                bool isExist = false;
                for (int i = 0; i < contexts.Count; i++)
                {
                    if (contexts[i].StartsWith(slnPath))
                    {
                        contexts[i] = slnPath + "=" + this.txtLibRootDir.Text.Trim();
                        isExist = true;
                        break;
                    }
                }
                if (isExist==false)
                {
                    contexts.Add(slnPath + "=" + this.txtLibRootDir.Text.Trim());
                }
                File.WriteAllLines(ConfigFilePath, contexts.ToArray(), Encoding.UTF8);
            }
            catch
            {
            }
        }

        /// <summary>
        /// 加载用户配置信息
        /// </summary>
        private void LoadThirdDllPathUserConfig()
        {
            try
            {
                if (File.Exists(ThirdDllPathConfigFilePath) == false)
                {
                    this.txtDotNetBarDir.Text = this.GetDotNetBarDir();
                    this.txtInfragisticsDir.Text = this.GetInfragisticsDir();
                    return;
                }
                string[] contexts = File.ReadAllLines(ThirdDllPathConfigFilePath, Encoding.UTF8);
                if (contexts != null && contexts.Length == 2)
                {
                    if (Directory.Exists(contexts[0]))
                    {
                        this.txtDotNetBarDir.Text = contexts[0];
                    }
                    else
                    {
                        this.txtDotNetBarDir.Text = this.GetDotNetBarDir();
                    }
                    if (Directory.Exists(contexts[1]))
                    {
                        this.txtInfragisticsDir.Text = contexts[1];
                    }
                    else
                    {
                        this.txtInfragisticsDir.Text = this.GetInfragisticsDir();
                    }
                }
                else
                {
                    this.txtDotNetBarDir.Text = this.GetDotNetBarDir();
                    this.txtInfragisticsDir.Text = this.GetInfragisticsDir();
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 保存用户配置信息，在protected override void Dispose(bool disposing)方法中调用
        /// </summary>
        private void SaveThirdDllPathUserConfig()
        {
            try
            {
                List<string> contexts = new List<string>();
                contexts.Add(this.txtDotNetBarDir.Text.Trim());
                contexts.Add(this.txtInfragisticsDir.Text.Trim());

                if (File.Exists(ThirdDllPathConfigFilePath) == false)
                {
                    string dir = Path.GetDirectoryName(ThirdDllPathConfigFilePath);
                    if (Directory.Exists(dir) == false)
                    {
                        Directory.CreateDirectory(dir);
                    }
                }
                File.WriteAllLines(ThirdDllPathConfigFilePath, contexts.ToArray(), Encoding.UTF8);
            }
            catch
            {
            }
        }

        private void FindSimilarDlls(DirectoryModel dirModel, string dllName, ref List<string> rltList)
        {
            List<string> dllFiles = dirModel.GetFilesByExtension(".dll");
            if (dllFiles != null)
            {
                for (int i = 0; i < dllFiles.Count; i++)
                {
                    string fileName = Path.GetFileNameWithoutExtension(dllFiles[i]);
                    if (fileName == dllName)
                    {
                        rltList.Add(dllFiles[i]);
                        return;
                    }

                }
            }
            List<DirectoryModel> subDirs = dirModel.DirectoryList;
            if (subDirs != null)
            {
                for (int i = 0; i < subDirs.Count; i++)
                {
                    this.FindSimilarDlls(subDirs[i], dllName, ref rltList);
                }
            }
        }

        /// <summary>
        /// 根据名称查找项目dll输出路径
        /// </summary>
        /// <param name="dllName">dll名称</param>
        /// <returns>dll的输出路径</returns>
        private string FindProItemOutPath(string dllName,string solPlatform)
        {
            List<Project> pros = ProjectUtility.GetAllProjects(_app);
            if (pros == null || pros.Count < 1)
            {
                return null;
            } 
            for (int i = 0; i < pros.Count; i++)
            {
                Project proj = pros[i];
                string fileName = proj.Properties.Item("OutputFileName").Value.ToString();
                if (fileName.EndsWith(".dll", StringComparison.CurrentCultureIgnoreCase))
                {
                    string name = fileName.Substring(0, fileName.Length - 4);
                    if (name.Equals(dllName, StringComparison.CurrentCultureIgnoreCase)==false)
                    {
                        continue;
                    }
                } 
                foreach (Configuration config in proj.ConfigurationManager)
                {
                    if (config.ConfigurationName == solPlatform)
                    {                       
                        string rootDir = Path.GetDirectoryName(proj.FileName);
                        string outputPath = config.Properties.Item("OutputPath").Value.ToString();
                        char[] charList = outputPath.ToCharArray();
                        int num = 0;
                        for (int j = 0; j < charList.Length; j++)
                        {
                            if (charList[j] == '.')
                            {
                                bool isOK = true;
                                for (int k = 0; k < j; k++)
                                {
                                    if (charList[k] != '.')
                                    {
                                        isOK = false;
                                    }
                                }
                                if (isOK)
                                {
                                    num++;
                                }
                            }
                        }
                        for (int j = 0; j < num - 1; j++)
                        {
                            rootDir = rootDir.Substring(0, rootDir.LastIndexOf('\\'));
                        }
                        if (outputPath.StartsWith("."))
                        {
                            outputPath = outputPath.Substring(outputPath.LastIndexOf('.') + 2);
                        }
                        outputPath = Path.Combine(rootDir, outputPath);
                        outputPath = Path.Combine(outputPath, fileName);
                        if (outputPath.EndsWith(".dll", StringComparison.CurrentCultureIgnoreCase) == false)
                        {
                            continue;
                        }
                        return outputPath;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 根据名称查找项目
        /// </summary>
        /// <param name="dllName">dll名称</param>
        /// <returns>项目Project</returns>
        private Project FindProItem(string dllName, string solPlatform)
        {
            List<Project> pros = ProjectUtility.GetAllProjects(_app);
            if (pros == null || pros.Count < 1)
            {
                return null;
            }
            for (int i = 0; i < pros.Count; i++)
            {
                Project proj = pros[i];
                string fileName = proj.Properties.Item("OutputFileName").Value.ToString();
                if (fileName.EndsWith(".dll", StringComparison.CurrentCultureIgnoreCase))
                {
                    string name = fileName.Substring(0, fileName.Length - 4);
                    if (name.Equals(dllName, StringComparison.CurrentCultureIgnoreCase))
                    {
                        return proj;
                    }
                }
            }
            return null;
        }

        private bool IsNeedChangePath(string dllPath)
        {
            if (dllPath.StartsWith(@"C:\Windows", StringComparison.CurrentCultureIgnoreCase))
            {
                return false;
            }
            //if (dllPath.Substring(1).StartsWith(@":\Program Files", StringComparison.CurrentCultureIgnoreCase))
            //{
            //    return false;
            //}
            //if (dllPath.IndexOf(@"DotNetBar for Windows Forms", StringComparison.CurrentCultureIgnoreCase) > 0 || dllPath.IndexOf(@"Infragistics\NetAdvantage", StringComparison.CurrentCultureIgnoreCase) > 0)
            //{
            //    if (File.Exists(dllPath))
            //    {
            //        return false;
            //    }
            //}
            return true;
        }

        //自下向上查找
        private string FindLibDir(string slnDir)
        {
            List<string> searchDirs = new List<string>();
            this.GetTopDirs(slnDir, ref searchDirs);
            if (searchDirs.Count > 0)
            {
                for (int i = 0; i < searchDirs.Count; i++)
                {
                    DirectoryInfo info = new DirectoryInfo(searchDirs[i]);
                    if (info.Name.Equals("Lib", StringComparison.CurrentCultureIgnoreCase))
                    {
                        return searchDirs[i];
                    }
                    DirectoryInfo[] subDirs = info.GetDirectories("*Lib");
                    if (subDirs != null && subDirs.Length > 0)
                    {
                        for (int j = 0; j < subDirs.Length; j++)
                        {
                            if (subDirs[j].Name.Equals("Lib", StringComparison.CurrentCultureIgnoreCase))
                            {
                                return subDirs[j].FullName;
                            }
                        }
                    }
                }
            }
            return slnDir;
        }

        private void GetTopDirs(string lowerDir, ref List<string> dirs)
        {
            if (string.IsNullOrEmpty(lowerDir)==false && Directory.Exists(lowerDir))
            {
                dirs.Add(lowerDir);
                DirectoryInfo info = new DirectoryInfo(lowerDir);
                if (info.Parent != null)
                {
                    GetTopDirs(info.Parent.FullName, ref dirs);
                }
            }
        }

        private string GetOutPutDllPath(Project proj, string solPlatform)
        {
            foreach (Configuration config in proj.ConfigurationManager)
            {
                if (config.ConfigurationName == solPlatform)
                {
                    string rootDir = Path.GetDirectoryName(proj.FileName);
                    string outputPath = config.Properties.Item("OutputPath").Value.ToString();
                    char[] charList = outputPath.ToCharArray();
                    int num = 0;
                    for (int j = 0; j < charList.Length; j++)
                    {
                        if (charList[j] == '.')
                        {
                            bool isOK = true;
                            for (int k = 0; k < j; k++)
                            {
                                if (charList[k] != '.')
                                {
                                    isOK = false;
                                }
                            }
                            if (isOK)
                            {
                                num++;
                            }
                        }
                    }
                    for (int j = 0; j < num - 1; j++)
                    {
                        rootDir = rootDir.Substring(0, rootDir.LastIndexOf('\\'));
                    }
                    string fileName = proj.Properties.Item("OutputFileName").Value.ToString();
                    if (outputPath.StartsWith("."))
                    {
                        outputPath = outputPath.Substring(outputPath.LastIndexOf('.') + 2);
                    }
                    outputPath = Path.Combine(rootDir, outputPath);
                    outputPath = Path.Combine(outputPath, fileName);
                    if (outputPath.EndsWith(".dll", StringComparison.CurrentCultureIgnoreCase) == false)
                    {
                        continue;
                    }
                    return outputPath;
                }
            }
            return null;
        }

        public string GetDotNetBarDir()
        {
            DriveInfo[] infoList = DriveInfo.GetDrives();
            for (int i = 0; i < infoList.Length; i++)
            {
                if (infoList[i].DriveType != DriveType.Fixed)
                {
                    continue;
                }
                string rootDir = infoList[i].Name;
                string x86Dir = Path.Combine(rootDir, "Program Files (x86)");
                string[] dirList = Directory.GetDirectories(x86Dir, "DotNetBar for Windows Forms", SearchOption.TopDirectoryOnly);
                if (dirList != null && dirList.Length > 0)
                {
                    return dirList[0];
                }
                string x64Dir = Path.Combine(rootDir, "Program Files");
                dirList = Directory.GetDirectories(x64Dir, "DotNetBar for Windows Forms", SearchOption.TopDirectoryOnly);
                if (dirList != null && dirList.Length > 0)
                {
                    return dirList[0];
                }
            }
            return string.Empty;
        }

        public string GetInfragisticsDir()
        {
            DriveInfo[] infoList = DriveInfo.GetDrives();
            for (int i = 0; i < infoList.Length; i++)
            {
                if (infoList[i].DriveType != DriveType.Fixed)
                {
                    continue;
                }
                string rootDir = infoList[i].Name;
                string x86Dir = Path.Combine(rootDir, "Program Files (x86)");
                string[] dirList = Directory.GetDirectories(x86Dir, "Infragistics", SearchOption.TopDirectoryOnly);
                if (dirList != null && dirList.Length > 0)
                {
                    return dirList[0];
                }
                string x64Dir = Path.Combine(rootDir, "Program Files");
                dirList = Directory.GetDirectories(x64Dir, "Infragistics", SearchOption.TopDirectoryOnly);
                if (dirList != null && dirList.Length > 0)
                {
                    return dirList[0];
                }
            }
            return string.Empty;
        }

        private void btnDotNetBarDir_Click(object sender, EventArgs e)
        {
            string dir = this.txtDotNetBarDir.Text.Trim();
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (string.IsNullOrEmpty(dir) == false && Directory.Exists(dir))
            {
                fbd.SelectedPath = dir;
            }
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                this.txtDotNetBarDir.Text = fbd.SelectedPath;
            }
        }

        private void btnInfragisticsDir_Click(object sender, EventArgs e)
        {
            string dir = this.txtInfragisticsDir.Text.Trim();
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (string.IsNullOrEmpty(dir) == false && Directory.Exists(dir))
            {
                fbd.SelectedPath = dir;
            }
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                this.txtInfragisticsDir.Text = fbd.SelectedPath;
            }
        }

    }
}
