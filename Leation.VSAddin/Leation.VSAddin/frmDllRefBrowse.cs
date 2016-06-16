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
    public partial class frmDllRefBrowse : Form
    {
        private List<Project> _prjList = null;
        private string _dllRootDir = null;
        private DirectoryModel _dirModel = null;

        public frmDllRefBrowse(List<Project> prjList,string dllRootDir)
        {
            InitializeComponent();

            _prjList = prjList;
            _dllRootDir = dllRootDir;
        }

        public void InitialData()
        {
            if (_prjList == null || _prjList.Count < 1)
            {
                return;
            }
            _dirModel = FileDirUtility.ReadAllDirAndFiles(_dllRootDir);

            for (int i = 0; i < _prjList.Count; i++)
            {
                TreeNode rootNode = this.treeView1.Nodes.Add(_prjList[i].Name);

                VSProject vsProj = _prjList[i].Object as VSProject;
                References dllRefs = vsProj.References;
                if (dllRefs == null)
                {
                    continue;
                }
                foreach (Reference dllRef in dllRefs)
                {
                    TreeNode subRootNode = rootNode.Nodes.Add(dllRef.Name);
                    if (dllRef.Name.StartsWith("System") || dllRef.Name.StartsWith("mscorlib"))
                    {
                        continue;
                    }
                    string dllPath = dllRef.Path;
                    if (string.IsNullOrEmpty(dllPath) || File.Exists(dllPath) == false)
                    {
                        continue;
                    }
                    int count = 0;
                    this.GetDllListTreeNode(dllPath, ref subRootNode, ref count);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void GetDllListTreeNode(string dllPath, ref TreeNode rootNode,ref int count)
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
                if (subRef.StartsWith("System") || subRef.StartsWith("mscorlib")||subRef==dllName)
                {
                    continue;
                }
                TreeNode subNode = rootNode.Nodes.Add(subRef);
                List<string> similarDlls = new List<string>();
                this.FindSimilarDlls(_dirModel, subRef, ref similarDlls);
                if (similarDlls.Count < 1)
                {
                    continue;
                }
                GetDllListTreeNode(similarDlls[0], ref subNode,ref count);
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

    }
}
