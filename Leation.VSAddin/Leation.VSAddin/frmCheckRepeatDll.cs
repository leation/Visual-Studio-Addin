using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using EnvDTE;
using EnvDTE80;
using VSLangProj;

namespace Leation.VSAddin
{
    public partial class frmCheckRepeatDll : Form
    {
        private DTE2 _app = null;
        private readonly string ConfigFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Leation.VSAddin\frmShowRepeatDll.config");

        public frmCheckRepeatDll(DTE2 app)
        {
            InitializeComponent();

            _app = app;
            this.LoadUserConfig();
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

        private void txtLibRootDir_TextChanged(object sender, EventArgs e)
        {
            this.treeView1.Nodes.Clear();
            string dllRootDir = this.txtLibRootDir.Text.Trim();
            if (Directory.Exists(dllRootDir))
            {
                string[] files = Directory.GetFiles(dllRootDir, "*.dll", SearchOption.AllDirectories);
                if (files == null || files.Length < 1)
                {
                    return;
                }
                Dictionary<string, List<string>> fileDic = new Dictionary<string, List<string>>();
                for (int i = 0; i < files.Length; i++)
                {
                    string fileName = Path.GetFileNameWithoutExtension(files[i]);
                    if (fileDic.ContainsKey(fileName))
                    {
                        fileDic[fileName].Add(files[i]);
                    }
                    else
                    {
                        List<string> fileList = new List<string>();
                        fileList.Add(files[i]);
                        fileDic.Add(fileName, fileList);
                    }
                }
                foreach (string key in fileDic.Keys)
                {
                    List<string> fileList = fileDic[key];
                    if (fileList.Count > 1)
                    {
                        fileList.Sort();
                        TreeNode root = new TreeNode(key);
                        this.treeView1.Nodes.Add(root);
                        for (int i = 0; i < fileList.Count; i++)
                        {
                            string dllPath = fileList[i].Substring(dllRootDir.Length+1);
                            TreeNode chidNode = new TreeNode(dllPath);
                            chidNode.Tag = fileList[i];
                            root.Nodes.Add(chidNode);
                        }
                    }
                }
                this.treeView1.ExpandAll();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.treeView1.Nodes.Count; i++)
            {
                for (int j = 0; j < this.treeView1.Nodes[i].Nodes.Count; j++)
                {
                    TreeNode node = this.treeView1.Nodes[i].Nodes[j];
                    if (node.Checked == false)
                    {
                        continue;
                    }
                    string tip = string.Format("确定删除：{0}？", node.Text);
                    if (MsgBox.ShowOkCancel(tip) == System.Windows.Forms.DialogResult.OK)
                    {
                        try
                        {
                            File.Delete(node.Tag.ToString());
                            node.Remove();
                            if (node.Parent.Nodes.Count < 2)
                            {
                                node.Parent.Remove();
                            }
                        }
                        catch (Exception ex)
                        {
                            MsgBox.ShowTip(ex.Message);
                        }
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowRepeatDll_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.SaveUserConfig();
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
                if (isExist == false)
                {
                    contexts.Add(slnPath + "=" + this.txtLibRootDir.Text.Trim());
                }
                File.WriteAllLines(ConfigFilePath, contexts.ToArray(), Encoding.UTF8);
            }
            catch
            {
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
