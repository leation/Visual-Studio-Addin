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
    public partial class frmDll2Lib : Form
    {
        private DTE2 _app = null;
        private readonly string ConfigFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Leation.VSAddin\frmDll2Lib.config");
        private DirectoryModel _dirModel = null;
        private bool _isLoaded = false;

        public frmDll2Lib(DTE2 app)
        {
            InitializeComponent();

            _app = app;

            this.LoadUserConfig();

            List<Project> pros = ProjectUtility.GetAllProjects(_app);
            if (pros != null && pros.Count > 0)
            {
                this.dataGridView1.Tag = pros;
                //初始化datagridview
                this.dataGridView1.Rows.Add(pros.Count);
                for (int i = 0; i < pros.Count; i++)
                {
                    this.dataGridView1[0, i].Value = true;
                    this.dataGridView1[1, i].Value = pros[i].Name;
                    this.dataGridView1[2, i].Value = string.Empty;
                    this.dataGridView1[3, i].Value = string.Empty;
                    this.dataGridView1[4, i].Value = string.Empty;
                    this.dataGridView1.Rows[i].Tag = pros[i];
                }
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
            _isLoaded = true;
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.rMenu.Show(this.dataGridView1, e.Location);
            }
        }

        private void combSolutionPlatform_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.combSolutionPlatform.SelectedItem == null)
                {
                    return;
                }
                string dllRootDir = this.txtLibRootDir.Text.Trim();
                if (string.IsNullOrEmpty(dllRootDir) || Directory.Exists(dllRootDir) == false)
                {
                    return;
                }
                if (_dirModel == null||_dirModel.DirectoryPath!=dllRootDir)
                {
                    _dirModel = FileDirUtility.ReadAllDirAndFiles(dllRootDir);
                }
                string solPlatform = this.combSolutionPlatform.SelectedItem.ToString();
                for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                {
                    Project proj = this.dataGridView1.Rows[i].Tag as Project;
                    if (proj != null)
                    {
                        foreach (Configuration config in proj.ConfigurationManager)
                        {
                            if (config.ConfigurationName == solPlatform)
                            {
                                string rootDir = Path.GetDirectoryName(proj.FileName);

                                string objDllPath = Path.Combine(rootDir, "obj");
                                objDllPath = Path.Combine(objDllPath, solPlatform);
                                objDllPath = Path.Combine(objDllPath, proj.Properties.Item("OutputFileName").Value.ToString());
                                if (File.Exists(objDllPath))
                                {
                                    this.dataGridView1[2, i].Value = objDllPath.Substring(rootDir.Length+1);
                                    this.dataGridView1[2, i].Tag = objDllPath;
                                    this.dataGridView1[2, i].ToolTipText = objDllPath;
                                }
                                else
                                {
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
                                    this.dataGridView1[2, i].Value = outputPath.Substring(rootDir.Length+1);
                                    this.dataGridView1[2, i].Value = outputPath;
                                    this.dataGridView1[2, i].ToolTipText = outputPath;
                                }
                                break;
                            }
                        }
                        //查找最佳目标dll路径
                        List<string> similarDlls = new List<string>();
                        this.FindSimilarDlls(_dirModel, proj.Name, ref similarDlls);
                        if (similarDlls.Count > 0)
                        {
                            string cellValue = string.Empty;
                            string toolTip = string.Empty;
                            for (int j = 0; j < similarDlls.Count; j++)
                            {
                                if (j == 0)
                                {
                                    cellValue = similarDlls[j].Substring(dllRootDir.Length+1);
                                    toolTip = similarDlls[j];
                                }
                                else
                                {
                                    cellValue += "#" + similarDlls[j].Substring(dllRootDir.Length+1);
                                    toolTip += "#" + similarDlls[j];
                                }
                            }
                            this.dataGridView1[3, i].Value = cellValue;
                            this.dataGridView1[3, i].Tag = similarDlls;
                            this.dataGridView1[3, i].ToolTipText = toolTip;
                        }
                        this.dataGridView1[4, i].Value = similarDlls.Count;
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowTip(ex.Message);
            }
        }

        private void txtLibRootDir_TextChanged(object sender, EventArgs e)
        {
            if (_isLoaded == false)
            {
                return;
            }
            this.combSolutionPlatform_SelectedIndexChanged(null, null);
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
     
        private void rMenuSelAll_Click(object sender, EventArgs e)
        {
            this.btnOK.Focus();
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                this.dataGridView1[0, i].Value = true;
            }
            this.btnOK.Focus();
        }

        private void rMenuSelReverse_Click(object sender, EventArgs e)
        {
            this.btnOK.Focus();
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                object obj = this.dataGridView1[0, i].Value;
                if (obj != null && obj is bool)
                {
                    this.dataGridView1[0, i].Value = !(bool)obj;
                }
            }
            this.btnOK.Focus();
        }

        private void rMenuChkSel_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows == null || this.dataGridView1.SelectedRows.Count < 1)
            {
                return;
            }
            this.btnOK.Focus();
            for (int i = 0; i < this.dataGridView1.SelectedRows.Count; i++)
            {
                this.dataGridView1.SelectedRows[i].Cells[0].Value = true;
            }
            this.btnOK.Focus();
        }

        private void rMenuReverseSel_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows == null || this.dataGridView1.SelectedRows.Count < 1)
            {
                return;
            }
            this.btnOK.Focus();
            for (int i = 0; i < this.dataGridView1.SelectedRows.Count; i++)
            {
                object obj = this.dataGridView1.SelectedRows[i].Cells[0].Value;
                if (obj != null && obj is bool)
                {
                    this.dataGridView1.SelectedRows[i].Cells[0].Value = !(bool)obj;
                }
            }
            this.btnOK.Focus();
        }

        private void frmDllRefSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.SaveUserConfig();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.combSolutionPlatform.SelectedItem == null)
            {
                MsgBox.ShowTip("请选择解决方案配置");
                return;
            }
            string dllRootDir = this.txtLibRootDir.Text.Trim();
            if (string.IsNullOrEmpty(dllRootDir) || Directory.Exists(dllRootDir) == false)
            {
                MsgBox.ShowTip("请选择Lib根目录");
                return;
            }
            List<string> msgList = new List<string>();
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                bool isSel = (bool)this.dataGridView1[0, i].Value;
                if (isSel == false)
                {
                    continue;
                }
                string srcPath = this.dataGridView1[2, i].Tag as string;
                List<string> destPaths = this.dataGridView1[3, i].Tag as List<string>;
                if (string.IsNullOrEmpty(srcPath)==false &&File.Exists(srcPath) && destPaths != null && destPaths.Count > 0)
                {
                    for (int j = 0; j < destPaths.Count; j++)
                    {
                        string msg = string.Format("从 {0}  拷贝到  {1}  ", this.dataGridView1[2, i].Value.ToString(), destPaths[j].Substring(dllRootDir.Length));
                        try
                        {
                            File.Copy(srcPath, destPaths[j], true);
                            msg += "成功";
                        }
                        catch (Exception ex)
                        {
                            msg += "失败!，具体信息:"+ex.Message;
                        }
                        msgList.Add(msg);
                    }
                }
            }
            SaveText2Notepad.SaveContext(msgList, true);
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
     
    }
}
