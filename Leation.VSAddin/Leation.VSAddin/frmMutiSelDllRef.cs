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
    public partial class frmMutiSelDllRef : Form
    {
        private List<string> _selDllPaths = null;
        public List<string> SelDllPaths
        {
            get
            {
                return _selDllPaths;
            }
        }

        public frmMutiSelDllRef(string dllRootDir)
        {
            InitializeComponent();

            if (Directory.Exists(dllRootDir))
            {
                DirectoryInfo dirInfo=new DirectoryInfo(dllRootDir);
                TreeNode rootNode=this.treeView1.Nodes.Add(dirInfo.Name);
                rootNode.Tag = dllRootDir;
                this.GetDirListTreeNode(dllRootDir, ref rootNode);
                rootNode.Expand();
                this.treeView1.SelectedNode = rootNode;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.treeView1.SelectedNode == null || this.treeView1.SelectedNode.Tag == null)
            {
                MsgBox.ShowTip("请选择要引用的dll");
                return;
            }
            _selDllPaths = new List<string>();
            for (int i = 0; i < this.listView1.SelectedItems.Count; i++)
            {
                string dllPath = this.listView1.SelectedItems[i].Tag as string;
                _selDllPaths.Add(dllPath);
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.listView1.Items.Clear();
            TreeNode selNode = e.Node;
            if (selNode.Tag == null)
            {
                return;
            }
            string selDir = selNode.Tag as string;
            string[] dllFiles = this.GetDllFiles(selDir);
            if (dllFiles != null)
            {
                for (int i = 0; i < dllFiles.Length; i++)
                {
                    string fileName = Path.GetFileName(dllFiles[i]);
                    ListViewItem item = this.listView1.Items.Add(fileName);
                    item.Tag = dllFiles[i];
                }
            }
        }

        private void GetDirListTreeNode(string dllRootDir,ref TreeNode rootNode)
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
                    subRoot.Tag = subDirs[i];
                    this.GetDirListTreeNode(subDirs[i], ref subRoot);
                }
            }
        }

        private string[] GetDllFiles(string dir)
        {
            string[] files = Directory.GetFiles(dir, "*.dll",SearchOption.AllDirectories);
            return files;
        }

        private string[] GetSubDirs(string dir)
        {
            string[] dirs = Directory.GetDirectories(dir);
            return dirs;
        }

    }
}
