using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Leation.VSAddin
{
    public partial class frmSelDllRef : Form
    {
        private string _selDllPath = null;
        public string SelDllPath
        {
            get
            {
                return _selDllPath;
            }
            set
            {
                _selDllPath = value;
            }
        }

        public frmSelDllRef(string dllRootDir)
        {
            InitializeComponent();

            if (Directory.Exists(dllRootDir))
            {
                DirectoryInfo dirInfo=new DirectoryInfo(dllRootDir);
                TreeNode rootNode=this.treeView1.Nodes.Add(dirInfo.Name);
                this.GetDllListTreeNode(dllRootDir, ref rootNode);
                rootNode.Expand();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.treeView1.SelectedNode == null || this.treeView1.SelectedNode.Tag == null)
            {
                MsgBox.ShowTip("请选择要引用的dll");
                return;
            }
            string dllFileName = string.Empty;
            if (string.IsNullOrEmpty(_selDllPath) == false)
            {
                dllFileName = Path.GetFileName(_selDllPath);
            }
            TreeNode selNode=this.treeView1.SelectedNode;
            if (string.IsNullOrEmpty(dllFileName) == false)
            {
                if (dllFileName != selNode.Text)
                {
                    DialogResult rlt = MsgBox.ShowOkCancel("所选dll名称与要修改引用的dll名称不一致，仍要修改吗？");
                    if (rlt == DialogResult.Cancel)
                    {
                        return;
                    }
                }
            }
            _selDllPath = selNode.Tag as string;
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.treeView1.SelectedNode == null || this.treeView1.SelectedNode.Tag == null)
            {
                return;
            }
            this.btnOK_Click(null, null);
        }

        private void GetDllListTreeNode(string dllRootDir,ref TreeNode rootNode)
        {
            if (dllRootDir.EndsWith(".svn"))
            {
                return;
            }
            string[] subDirs = this.GetSubDirs(dllRootDir);
            if (subDirs != null)
            {
                for (int i = 0; i < subDirs.Length; i++)
                {
                    if (subDirs[i].EndsWith(".svn"))
                    {
                        continue;
                    }
                    DirectoryInfo dirInfo = new DirectoryInfo(subDirs[i]);
                    TreeNode subRoot = rootNode.Nodes.Add(dirInfo.Name);

                    this.GetDllListTreeNode(subDirs[i], ref subRoot);
                }
            }
            string[] dllFiles = this.GetDllFiles(dllRootDir);
            if (dllFiles != null)
            {
                for (int i = 0; i < dllFiles.Length; i++)
                {
                    string fileName = Path.GetFileName(dllFiles[i]);
                    TreeNode node = rootNode.Nodes.Add(fileName);
                    node.Tag = dllFiles[i];
                }
            }
        }

        private string[] GetDllFiles(string dir)
        {
            string[] files = Directory.GetFiles(dir, "*.dll");
            return files;
        }

        private string[] GetSubDirs(string dir)
        {
            string[] dirs = Directory.GetDirectories(dir);
            return dirs;
        }

    }
}
