using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EnvDTE80;
using EnvDTE90;
using EnvDTE;
using System.IO;

namespace Leation.VSAddin
{
    public partial class frmMultiLoadProjects : Form
    {
        private DTE2 _app = null;

        public frmMultiLoadProjects(DTE2 app)
        {
            InitializeComponent();

            _app = app;           
        }

        private void rMenuSelAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.treeView1.Nodes.Count; i++)
            {
                CheckTreeNodes(this.treeView1.Nodes[i]);
            }
        }

        private void rMenuSelReverse_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.treeView1.Nodes.Count; i++)
            {
                CheckReverseTreeNodes(this.treeView1.Nodes[i]);
            }
        }

        private void rMenuUncheckedSolDir_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.treeView1.Nodes.Count; i++)
            {
                this.treeView1.Nodes[i].Checked = false;
            }
        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.rMenu.Show(this.treeView1, e.Location);
            }
        }

        private void btnBrowseRootDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "选择解决方案所在目录";
            string rootDir = this.txtRootDir.Text.Trim();
            if (string.IsNullOrEmpty(rootDir) == false && Directory.Exists(rootDir))
            {
                fbd.SelectedPath = rootDir;
            }
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                this.txtRootDir.Text = fbd.SelectedPath;
            }
        }

        private void txtRootDir_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string rootDir = this.txtRootDir.Text.Trim();
                if (string.IsNullOrEmpty(rootDir) || Directory.Exists(rootDir) == false)
                {
                    return;
                }
                this.treeView1.Nodes.Clear();
                string[] csprojList = Directory.GetFiles(rootDir, "*.csproj", SearchOption.AllDirectories);
                if (csprojList == null || csprojList.Length < 1)
                {
                    return;
                }
                Dictionary<string, List<string>> projDic = new Dictionary<string, List<string>>();
                List<string> keyList = new List<string>();
                for (int i = 0; i < csprojList.Length; i++)
                {
                    string fileName = Path.GetFileNameWithoutExtension(csprojList[i]);
                    string key = fileName;
                    if (fileName.IndexOf('.') > 0)
                    {
                        key = fileName.Substring(0, fileName.LastIndexOf('.'));
                    }
                    if (projDic.ContainsKey(key) == false)
                    {
                        List<string> temp = new List<string>();
                        temp.Add(csprojList[i]);
                        projDic.Add(key, temp);
                        keyList.Add(key);
                    }
                    else
                    {
                        projDic[key].Add(csprojList[i]);
                    }
                }
                keyList.Sort();
                for (int i = 0; i < keyList.Count; i++)
                {
                    List<string> fileList = projDic[keyList[i]];
                    TreeNode root = this.treeView1.Nodes.Add(keyList[i]);
                    root.Tag = keyList[i];
                    for (int j = 0; j < fileList.Count; j++)
                    {
                        string fileName = Path.GetFileName(fileList[j]);
                        TreeNode node = root.Nodes.Add(fileName);
                        node.Tag = fileList[j];
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowTip(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        //保存前一个鼠标进入的节点    
        private TreeNode MyOldNode = null;    

        private void treeView1_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)   
        {
            try
            {
                TreeNode node = e.Item as TreeNode;
                if (node == null)
                {
                    return;
                }
                //如果为顶级节点或有子节点则不允许移动改节点
                if (node.Parent == null || node.Nodes.Count > 0)
                {
                    return;
                }

                //设置拖放类型为移动            
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
            catch
            {
            }
        }            

        private void treeView1_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)       
        {
            try
            {
                //获取节点的数据内容           
                object MyData = e.Data.GetData(typeof(TreeNode));
                //如果节点有数据，拖放目标允许移动        
                if (MyData != null)
                {
                    e.Effect = DragDropEffects.Move;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
                TreeView MyTreeView = (TreeView)sender;
                TreeNode MyNode = MyTreeView.GetNodeAt(treeView1.PointToClient(new Point(e.X, e.Y)));
                if (MyNode != null)
                {
                    //改变进入节点的背景色       
                    MyNode.BackColor = Color.YellowGreen;
                    //保存此节点，进入下一个时还原背景色   
                    MyOldNode = MyNode;
                }
            }
            catch
            {
            }        
        }              

        private void treeView1_DragOver(object sender, System.Windows.Forms.DragEventArgs e)   
        {
            try
            {
                //修改鼠标进入节点的背景色，还原上一个节点的背景色     
                TreeView MyTreeView = (TreeView)sender;
                TreeNode MyNode = MyTreeView.GetNodeAt(treeView1.PointToClient(new Point(e.X, e.Y)));
                if ((MyNode != null) && (MyNode != MyOldNode))
                {
                    MyOldNode.BackColor = Color.White;
                    MyNode.BackColor = Color.YellowGreen;
                    MyOldNode = MyNode;
                }
            }
            catch
            {
            }   
        }       
        
        private void treeView1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            try
            {
                TreeNode MyNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
                TreeView MyTreeView = (TreeView)sender;
                //得到当前鼠标进入的节点      
                TreeNode MyTargetNode = MyTreeView.GetNodeAt(treeView1.PointToClient(new Point(e.X, e.Y)));
                if (MyTargetNode != null)
                {
                    MyTargetNode.BackColor = Color.White;

                    if (MyTargetNode.Equals(MyNode) == false&&MyTargetNode.Parent==null)
                    {
                        //删除拖放的节点             
                        MyNode.Remove();
                        //添加到目标节点             
                        MyTargetNode.Nodes.Add(MyNode);
                        MyTreeView.SelectedNode = MyTargetNode;
                    }
                }
            }
            catch
            {
            }     
        }

        private void CheckTreeNodes(TreeNode root)
        {
            root.Checked = true;
            for (int i = 0; i < root.Nodes.Count; i++)
            {
                CheckTreeNodes(root.Nodes[i]);
            }
        }

        private void CheckChildTreeNodes(TreeNode root,bool isSel)
        {
            root.Checked = isSel;
            for (int i = 0; i < root.Nodes.Count; i++)
            {
                CheckChildTreeNodes(root.Nodes[i], isSel);
            }
        }

        private void CheckReverseTreeNodes(TreeNode root)
        {
            root.Checked = !root.Checked;
            for (int i = 0; i < root.Nodes.Count; i++)
            {
                CheckReverseTreeNodes(root.Nodes[i]);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Solution3 sol3 = _app.Solution as Solution3;
                if (sol3 == null||string.IsNullOrEmpty(sol3.FileName))
                {
                    MsgBox.ShowTip("请先打开已有解决方案或者新建一个解决方案");
                    return;
                }
                List<Project> existProjs = ProjectUtility.GetAllProjects(_app);
                for (int i = 0; i < this.treeView1.Nodes.Count; i++)
                {
                    TreeNode rootNode = this.treeView1.Nodes[i];
                    if (rootNode.Checked && rootNode.Nodes.Count > 0)
                    {
                        string foldName = rootNode.Tag as string;
                        bool isExistFolder = false;
                        for (int j = 1; j < sol3.Projects.Count; j++)
                        {
                            Project proj = sol3.Projects.Item(j);
                            if (proj.Kind != ProjectKinds.vsProjectKindSolutionFolder)
                            {
                                continue;
                            }
                            if (sol3.Projects.Item(j).Name.Equals(foldName, StringComparison.CurrentCultureIgnoreCase))
                            {
                                isExistFolder = true;
                                break;
                            }
                        }
                        if (isExistFolder == false)
                        {
                            Project solFolder = sol3.AddSolutionFolder(rootNode.Tag as string);
                        }
                        for (int j = 0; j < rootNode.Nodes.Count; j++)
                        {
                            if (rootNode.Nodes[j].Checked)
                            {
                                string projPath = rootNode.Nodes[j].Tag as string;
                                bool isExist = false;
                                for (int k = 0; k < existProjs.Count; k++)
                                {
                                    if (existProjs[k].FileName.Equals(projPath, StringComparison.CurrentCultureIgnoreCase))
                                    {
                                        isExist = true;
                                        break;
                                    }
                                }
                                if (isExist == false)
                                {
                                    Project proj = sol3.AddFromFile(projPath, false);
                                }
                                else
                                {
                                    MsgBox.ShowTip(Path.GetFileNameWithoutExtension(projPath) + "已经加载");
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int j = 0; j < rootNode.Nodes.Count; j++)
                        {
                            if (rootNode.Nodes[j].Checked)
                            {
                                string projPath = rootNode.Nodes[j].Tag as string;
                                bool isExist = false;
                                for (int k = 0; k < existProjs.Count; k++)
                                {
                                    if (existProjs[k].FileName.Equals(projPath, StringComparison.CurrentCultureIgnoreCase))
                                    {
                                        isExist = true;
                                        break;
                                    }
                                }
                                if (isExist == false)
                                {
                                    Project proj = sol3.AddFromFile(projPath, false);
                                }
                                else
                                {
                                    MsgBox.ShowTip(Path.GetFileNameWithoutExtension(projPath) + "已经加载");
                                }
                            }
                        }
                    }
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch(Exception ex)
            {
                MsgBox.ShowTip(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void lblRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string rootDir = this.txtRootDir.Text.Trim();
                if (string.IsNullOrEmpty(rootDir) || Directory.Exists(rootDir) == false)
                {
                    return;
                }
                this.treeView1.Nodes.Clear();
                string[] csprojList = Directory.GetFiles(rootDir, "*.csproj", SearchOption.AllDirectories);
                if (csprojList == null || csprojList.Length < 1)
                {
                    return;
                }
                string[] filters = this.txtFilterStr.Text.Trim().Split(',');
                if (filters != null && filters.Length > 0)
                {
                    List<string> tempList = new List<string>();
                    for (int i = 0; i < csprojList.Length; i++)
                    {
                        for (int j = 0; j < filters.Length; j++)
                        {
                            string fileName = Path.GetFileNameWithoutExtension(csprojList[i]).ToUpper();
                            if (fileName.Contains(filters[j].ToUpper()))
                            {
                                tempList.Add(csprojList[i]);
                                break;
                            }
                        }
                    }
                    csprojList = tempList.ToArray();
                }

                Dictionary<string, List<string>> projDic = new Dictionary<string, List<string>>();
                List<string> keyList = new List<string>();
                for (int i = 0; i < csprojList.Length; i++)
                {
                    string fileName = Path.GetFileNameWithoutExtension(csprojList[i]);
                    string key = fileName;
                    if (fileName.IndexOf('.') > 0)
                    {
                        key = fileName.Substring(0, fileName.LastIndexOf('.'));
                    }
                    if (projDic.ContainsKey(key) == false)
                    {
                        List<string> temp = new List<string>();
                        temp.Add(csprojList[i]);
                        projDic.Add(key, temp);
                        keyList.Add(key);
                    }
                    else
                    {
                        projDic[key].Add(csprojList[i]);
                    }
                }
                keyList.Sort();
                for (int i = 0; i < keyList.Count; i++)
                {
                    List<string> fileList = projDic[keyList[i]];
                    TreeNode root = this.treeView1.Nodes.Add(keyList[i]);
                    root.Tag = keyList[i];
                    for (int j = 0; j < fileList.Count; j++)
                    {
                        string fileName = Path.GetFileName(fileList[j]);
                        TreeNode node = root.Nodes.Add(fileName);
                        node.Tag = fileList[j];
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowTip(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void rMenuExpandAll_Click(object sender, EventArgs e)
        {
            this.treeView1.ExpandAll();
        }

        private void rMenuCollapseAll_Click(object sender, EventArgs e)
        {
            this.treeView1.CollapseAll();
        }
       
    }
}
