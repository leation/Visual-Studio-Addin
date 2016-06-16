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
    public partial class frmDllRefFileCopy : Form
    {
        private DTE2 _app = null;
        private readonly string ConfigFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Leation.VSAddin\frmDllRefFileCopy.config");
        private readonly string HideRefStrategyConfigFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Leation.VSAddin\frmSetHideRefStrategy.config");
        private List<string> _copiedFiles = new List<string>();
        private DirectoryModel _dirModel = null;

        public frmDllRefFileCopy(DTE2 app)
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
            }

            this.LoadUserConfig();

            DllRefReflectUtility.ClearTempFiles();
            DllRefReflectUtility.SubDirGuid = Guid.NewGuid().ToString();
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
                if (dllRef.Path.StartsWith(@"C:\Windows", StringComparison.CurrentCultureIgnoreCase) || dllRef.Path.StartsWith(@"C:\Program Files", StringComparison.CurrentCultureIgnoreCase))
                {
                    continue;
                }
                if (dllRef.Path.StartsWith(@"D:\Program Files", StringComparison.CurrentCultureIgnoreCase))
                {
                    continue;
                }
                if (dllRef.Path.StartsWith(@"E:\Program Files", StringComparison.CurrentCultureIgnoreCase))
                {
                    continue;
                }
                if (dllRef.Path.StartsWith(@"F\Program Files", StringComparison.CurrentCultureIgnoreCase))
                {
                    continue;
                }
                if (dllRef.Path.IndexOf(@"Infragistics\NetAdvantage", StringComparison.CurrentCultureIgnoreCase) > 0)
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
            if (string.IsNullOrEmpty(dllRootDir)==false && Directory.Exists(dllRootDir))
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

        private void btnDestDir_Click(object sender, EventArgs e)
        {
            string destDir = this.txtDestDir.Text.Trim();
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (string.IsNullOrEmpty(destDir) == false && Directory.Exists(destDir))
            {
                fbd.SelectedPath = destDir;
            }
            else
            {
                string slnPath = _app.Solution.FileName;
                string dir = Path.GetDirectoryName(slnPath);
                fbd.SelectedPath = this.FindBinDir(dir);
            }
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                this.txtDestDir.Text = fbd.SelectedPath;
            }
        }

        private void rMenuCopyAllRefDlls_Click(object sender, EventArgs e)
        {
            if (this.combProjects.Tag == null)
            {
                return;
            }
            string dllRootDir = this.txtLibRootDir.Text.Trim();
            if (string.IsNullOrEmpty(dllRootDir) || Directory.Exists(dllRootDir) == false)
            {
                MsgBox.ShowTip("请先输入Lib根目录");
                return;
            }
            string destDir = this.txtDestDir.Text.Trim();
            if (string.IsNullOrEmpty(destDir) || Directory.Exists(destDir) == false)
            {
                MsgBox.ShowTip("请先输入目标路径");
                return;
            }
            CopyStrategyModel strategy = this.lblSetHideRefStrategy.Tag as CopyStrategyModel;
            if (strategy == null)
            {
                strategy=new CopyStrategyModel();
            }
            strategy.DeepCopy = this.chkDeepCopy.Checked;
            strategy.CopyHideRefDlls = this.chkCopyHideRefDlls.Checked;

            _copiedFiles.Clear();
            _dirModel = FileDirUtility.ReadAllDirAndFiles(dllRootDir);

            this.Cursor = Cursors.WaitCursor;

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
                    string dllPath = dllRef.Path;
                    if (string.IsNullOrEmpty(dllPath) || File.Exists(dllPath) == false)
                    {
                        continue;
                    }
                    List<string> subRefDlls = DllRefReflectUtility.GetRefDlls(dllPath);
                    if (subRefDlls == null || subRefDlls.Count < 1)
                    {
                        continue;
                    }
                    foreach (string subRef in subRefDlls)
                    {
                        if (subRef.StartsWith("System") || subRef.StartsWith("mscorlib"))
                        {
                            continue;
                        }
                        if (subRef == dllRef.Name)
                        {
                            continue;
                        }
                        List<string> similarDlls = new List<string>();
                        this.FindSimilarDlls(_dirModel, subRef, ref similarDlls);
                        if (similarDlls.Count < 1)
                        {
                            continue;
                        }
                        string destFilePath = Path.Combine(destDir, Path.GetFileName(similarDlls[0]));
                        if (_copiedFiles.Contains(destFilePath))
                        {
                            continue;
                        }
                        _copiedFiles.Add(destFilePath);

                        File.Copy(similarDlls[0], destFilePath, true);
                        if (strategy.DeepCopy)
                        {
                            int count = 0;
                            this.CopySubRefDlls(similarDlls[0], destDir, dllRootDir, ref count);
                        }
                        if (strategy.CopyHideRefDlls && strategy.UseStrStrategy)
                        {
                            this.CopyHideRefDlls(dllRootDir,similarDlls[0], destDir, strategy);
                        }
                    }
                }
            }
            if (strategy.CopyHideRefDlls && strategy.UseDirStrategy)
            {
                this.CopyHideRefFiles(dllRootDir, destDir, strategy);
            }

            this.Cursor = Cursors.Default;
        }

        private void rMenuCopySelRefDlls_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows == null || this.dataGridView1.SelectedRows.Count < 1)
            {
                return;
            }
            string dllRootDir = this.txtLibRootDir.Text.Trim();
            if (string.IsNullOrEmpty(dllRootDir) || Directory.Exists(dllRootDir) == false)
            {
                MsgBox.ShowTip("请先输入Lib根目录");
                return;
            }
            string destDir = this.txtDestDir.Text.Trim();
            if (string.IsNullOrEmpty(destDir) || Directory.Exists(destDir) == false)
            {
                MsgBox.ShowTip("请先输入目标路径");
                return;
            }
            CopyStrategyModel strategy = this.lblSetHideRefStrategy.Tag as CopyStrategyModel;
            if (strategy == null)
            {
                strategy = new CopyStrategyModel();
            }
            strategy.DeepCopy = this.chkDeepCopy.Checked;
            strategy.CopyHideRefDlls = this.chkCopyHideRefDlls.Checked;
            
            _copiedFiles.Clear();
            _dirModel = FileDirUtility.ReadAllDirAndFiles(dllRootDir);

            this.Cursor = Cursors.WaitCursor;

            for (int i = 0; i < this.dataGridView1.SelectedRows.Count; i++)
            {
                DataGridViewRow selRow = this.dataGridView1.SelectedRows[i];
                Reference dllRef = selRow.Tag as Reference;
                if (dllRef == null)
                {
                    continue;
                }
                string dllPath = dllRef.Path;
                if (string.IsNullOrEmpty(dllPath) || File.Exists(dllPath) == false)
                {
                    continue;
                }
                List<string> subRefDlls = DllRefReflectUtility.GetRefDlls(dllPath);
                if (subRefDlls == null || subRefDlls.Count < 1)
                {
                    continue;
                }
                foreach (string subRef in subRefDlls)
                {
                    if (subRef.StartsWith("System")||subRef.StartsWith("mscorlib"))
                    {
                        continue;
                    }
                    if (subRef == dllRef.Name)
                    {
                        continue;
                    }
                    List<string> similarDlls = new List<string>();
                    this.FindSimilarDlls(_dirModel, subRef, ref similarDlls);
                    if (similarDlls.Count < 1)
                    {
                        continue;
                    }
                    string destFilePath = Path.Combine(destDir, Path.GetFileName(similarDlls[0]));
                    if (_copiedFiles.Contains(destFilePath))
                    {
                        continue;
                    }
                    _copiedFiles.Add(destFilePath);
                    File.Copy(similarDlls[0], destFilePath, true);
                    if (strategy.DeepCopy)
                    {
                        int count = 0;
                        this.CopySubRefDlls(similarDlls[0], destDir, dllRootDir, ref count);
                    }
                    if (strategy.CopyHideRefDlls && strategy.UseStrStrategy)
                    {
                        this.CopyHideRefDlls(dllRootDir, similarDlls[0], destDir, strategy);
                    }
                }
            }
            if (strategy.CopyHideRefDlls && strategy.UseDirStrategy)
            {
                this.CopyHideRefFiles(dllRootDir, destDir, strategy);
            }

            this.Cursor = Cursors.Default;
        }

        private void rMenuBrowseDllRef_Click(object sender, EventArgs e)
        {
            if (this.combProjects.Tag == null)
            {
                return;
            }
            string dllRootDir = this.txtLibRootDir.Text.Trim();
            if (string.IsNullOrEmpty(dllRootDir) || Directory.Exists(dllRootDir) == false)
            {
                MsgBox.ShowTip("请先输入Lib根目录");
                return;
            }
            List<Project> prjList = this.combProjects.Tag as List<Project>;
            frmDllRefBrowse frm = new frmDllRefBrowse(prjList,dllRootDir);
            this.Cursor = Cursors.WaitCursor;
            frm.InitialData();
            this.Cursor = Cursors.Default;
            frm.ShowDialog();
        }

        private void rMenuBrowseSelPrjDllRef_Click(object sender, EventArgs e)
        {
            if (this.combProjects.Tag == null || this.combProjects.SelectedItem == null)
            {
                return;
            }
            string dllRootDir = this.txtLibRootDir.Text.Trim();
            if (string.IsNullOrEmpty(dllRootDir) || Directory.Exists(dllRootDir) == false)
            {
                MsgBox.ShowTip("请先输入Lib根目录");
                return;
            }
            List<Project> prjList = this.combProjects.Tag as List<Project>;
           
            Project selProj = prjList[this.combProjects.SelectedIndex];
            List<Project> temp = new List<Project>();
            temp.Add(selProj);

            frmDllRefBrowse frm = new frmDllRefBrowse(temp, dllRootDir);
            this.Cursor = Cursors.WaitCursor;
            frm.InitialData();
            this.Cursor = Cursors.Default;
            frm.ShowDialog();
        }

        private void frmDllRefSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.SaveUserConfig();
        }

        private void lblSetHideRefStrategy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyStrategyModel strategy = this.lblSetHideRefStrategy.Tag as CopyStrategyModel;
            frmSetHideRefStrategy frm = new frmSetHideRefStrategy(strategy);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.lblSetHideRefStrategy.Tag = frm.CopyStrategy;
            }
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
                this.txtDestDir.Text = this.FindBinDir(dir);

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
                            if (strArray != null && strArray.Length == 3)
                            {
                                if (Directory.Exists(strArray[1]))
                                {
                                    this.txtLibRootDir.Text = strArray[1];
                                }
                                if (Directory.Exists(strArray[2]))
                                {
                                    this.txtDestDir.Text = strArray[2];
                                }
                            }
                            break;
                        }
                    }
                }
            }
            catch
            {
            }
            try
            {
                CopyStrategyModel strategy = new CopyStrategyModel();
                if (File.Exists(HideRefStrategyConfigFilePath))
                {
                    string[] contexts = File.ReadAllLines(HideRefStrategyConfigFilePath, Encoding.UTF8);
                    string slnPath = _app.Solution.FileName;
                    if (contexts != null && contexts.Length > 0)
                    {
                        //以sln的路径为键
                        for (int i = 0; i < contexts.Length; i++)
                        {
                            if (contexts[i].StartsWith(slnPath, StringComparison.CurrentCultureIgnoreCase))
                            {
                                string[] temp = contexts[i].Split('=');
                                if (temp != null && temp.Length == 7)
                                {
                                    string[] strArray = temp[1].Split('#');
                                    if (strArray != null && strArray.Length > 0)
                                    {
                                        strategy.DirStrategyList.AddRange(strArray);
                                        strategy.DirStrategyList.Remove(string.Empty);
                                    }
                                    strArray = temp[2].Split('#');
                                    if (strArray != null && strArray.Length > 0)
                                    {
                                        strategy.StrStrategyList.AddRange(strArray);
                                        strategy.StrStrategyList.Remove(string.Empty);
                                    }
                                    strategy.UseDirStrategy = bool.Parse(temp[3]);
                                    strategy.UseStrStrategy = bool.Parse(temp[4]);
                                    strategy.DeepCopy = bool.Parse(temp[5]);
                                    strategy.CopyHideRefDlls = bool.Parse(temp[6]);

                                    this.chkDeepCopy.Checked = strategy.DeepCopy;
                                    this.chkCopyHideRefDlls.Checked = strategy.CopyHideRefDlls;
                                }
                                break;
                            }
                        }
                    }
                }
                this.lblSetHideRefStrategy.Tag = strategy;
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
                string uiParam = this.txtLibRootDir.Text.Trim() + "=" + this.txtDestDir.Text.Trim();

                //以sln的路径为键
                string slnPath = _app.Solution.FileName;
                bool isExist = false;
                for (int i = 0; i < contexts.Count; i++)
                {
                    if (contexts[i].StartsWith(slnPath))
                    {
                        contexts[i] = slnPath + "=" + uiParam;
                        isExist = true;
                        break;
                    }
                }
                if (isExist == false)
                {
                    contexts.Add(slnPath + "=" + uiParam);
                }
                File.WriteAllLines(ConfigFilePath, contexts.ToArray(), Encoding.UTF8);
            }
            catch
            {
            }
            try
            {
                CopyStrategyModel strategy = this.lblSetHideRefStrategy.Tag as CopyStrategyModel;
                strategy.DeepCopy = this.chkDeepCopy.Checked;
                strategy.CopyHideRefDlls = this.chkCopyHideRefDlls.Checked;
                if (strategy == null)
                {
                    return;
                }
                List<string> contexts = new List<string>();
                if (File.Exists(HideRefStrategyConfigFilePath) == false)
                {
                    string dir = Path.GetDirectoryName(HideRefStrategyConfigFilePath);
                    if (Directory.Exists(dir) == false)
                    {
                        Directory.CreateDirectory(dir);
                    }
                    File.Create(HideRefStrategyConfigFilePath).Close();
                }
                else
                {
                    string[] temp = File.ReadAllLines(HideRefStrategyConfigFilePath, Encoding.UTF8);
                    if (temp != null && temp.Length > 0)
                    {
                        contexts.AddRange(temp);
                    }
                }
                string uiParam = this.GetCombainStr(strategy.DirStrategyList) + "=" + this.GetCombainStr(strategy.StrStrategyList) + "=" + strategy.UseDirStrategy.ToString() + "=" + strategy.UseStrStrategy.ToString();
                uiParam += "=" + strategy.DeepCopy.ToString() + "=" + strategy.CopyHideRefDlls.ToString();

                //以sln的路径为键
                string slnPath = _app.Solution.FileName;
                bool isExist = false;
                for (int i = 0; i < contexts.Count; i++)
                {
                    if (contexts[i].StartsWith(slnPath))
                    {
                        contexts[i] = slnPath + "=" + uiParam;
                        isExist = true;
                        break;
                    }
                }
                if (isExist == false)
                {
                    contexts.Add(slnPath + "=" + uiParam);
                }
                File.WriteAllLines(HideRefStrategyConfigFilePath, contexts.ToArray(), Encoding.UTF8);
            }
            catch
            {
            }
        }

        private void CopySubRefDlls(string dllPath,string destDir, string dllRootDir, ref int count)
        {
            //避免陷入死循环
            if (count > 1000)
            {
                return;
            }
            string dllName = Path.GetFileNameWithoutExtension(dllPath);
            List<string> subRefDlls = DllRefReflectUtility.GetRefDlls(dllPath);
            if (subRefDlls == null || subRefDlls.Count < 1)
            {
                return;
            }
            count++;
            foreach (string subRef in subRefDlls)
            {
                if (subRef.StartsWith("System") || subRef.StartsWith("mscorlib") || subRef == dllName)
                {
                    continue;
                }
                List<string> similarDlls = new List<string>();
                this.FindSimilarDlls(_dirModel, subRef, ref similarDlls);
                if (similarDlls.Count < 1)
                {
                    continue;
                }
                string destFilePath = Path.Combine(destDir, Path.GetFileName(similarDlls[0]));
                if (_copiedFiles.Contains(destFilePath))
                {
                    continue;
                }
                _copiedFiles.Add(destFilePath);
                File.Copy(similarDlls[0], destFilePath, true);
                CopySubRefDlls(similarDlls[0], destDir, dllRootDir, ref count);
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

        private string GetCombainStr(List<string> strArray)
        {
            string rlt = string.Empty;
            if (strArray != null)
            {
                for (int i = 0; i < strArray.Count; i++)
                {
                    if (i == 0)
                    {
                        rlt += strArray[i];
                    }
                    else
                    {
                        rlt += "#" + strArray[i];
                    }
                }
            }
            return rlt;
        }

        private void CopyHideRefFiles(string dllRootDir,string destDir, CopyStrategyModel strategy)
        {
            string[] dirs = Directory.GetDirectories(dllRootDir, "*", SearchOption.AllDirectories);
            if (dirs == null || dirs.Length < 1)
            {
                return;
            }
            for (int i = 0; i < dirs.Length; i++)
            {
                if (dirs[i].Contains(".svn"))
                {
                    continue;
                }
                DirectoryInfo dirInfo = new DirectoryInfo(dirs[i]);
                for (int j = 0; j < strategy.DirStrategyList.Count; j++)
                {
                    if (dirInfo.Name.Equals(strategy.DirStrategyList[j], StringComparison.CurrentCultureIgnoreCase))
                    {
                        string[] files = Directory.GetFiles(dirs[i]);
                        for (int k = 0; k < files.Length; k++)
                        {
                            string destFilePath = Path.Combine(destDir, Path.GetFileName(files[k]));
                            if (_copiedFiles.Contains(destFilePath))
                            {
                                continue;
                            }
                            _copiedFiles.Add(destFilePath);
                            File.Copy(files[k], destFilePath, true);
                        }
                    }
                }
            }
        }

        private void CopyHideRefDlls(string dllRootDir,string dllPath,string destDir,CopyStrategyModel strategy)
        {
            string dllName = Path.GetFileNameWithoutExtension(dllPath);
            if (dllName.IndexOf('.') < 1)
            {
                return;
            }
            dllName = dllName.Substring(0, dllName.LastIndexOf('.'));

            string dir = Path.GetDirectoryName(dllPath);
            string[] files = Directory.GetFiles(dir, "*.dll", SearchOption.TopDirectoryOnly);
            if (files == null || files.Length < 1)
            {
                return;
            }
            for (int i = 0; i < files.Length; i++)
            {
                string fileName = Path.GetFileName(files[i]);
                if (fileName.StartsWith(dllName)==false)
                {
                    continue;
                }
                for (int j = 0; j < strategy.StrStrategyList.Count; j++)
                {
                    if (fileName.Contains(strategy.StrStrategyList[j]))
                    {
                        string destFilePath = Path.Combine(destDir, fileName);
                        if (_copiedFiles.Contains(destFilePath))
                        {
                            continue;
                        }
                        _copiedFiles.Add(destFilePath);
                        File.Copy(files[i], destFilePath, true);
                        int count = 0;
                        CopySubRefDlls(files[0], destDir, dllRootDir, ref count);
                    }
                }
            }
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

        private string FindBinDir(string slnDir)
        {
            DirectoryInfo info = new DirectoryInfo(slnDir);
            DirectoryInfo[] subDirs = info.GetDirectories("*bin");
            if (subDirs != null && subDirs.Length > 0)
            {
                for (int j = 0; j < subDirs.Length; j++)
                {
                    if (subDirs[j].Name.Equals("bin", StringComparison.CurrentCultureIgnoreCase))
                    {
                        return subDirs[j].FullName;
                    }
                }
            }            
            return slnDir;
        }

        private void GetTopDirs(string lowerDir, ref List<string> dirs)
        {
            if (string.IsNullOrEmpty(lowerDir) == false && Directory.Exists(lowerDir))
            {
                dirs.Add(lowerDir);
                DirectoryInfo info = new DirectoryInfo(lowerDir);
                if (info.Parent != null)
                {
                    GetTopDirs(info.Parent.FullName, ref dirs);
                }
            }
        }
    }
}
