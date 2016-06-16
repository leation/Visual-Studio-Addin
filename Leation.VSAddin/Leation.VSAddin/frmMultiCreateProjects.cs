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
    public partial class frmMultiCreateProjects : Form
    {
        private DTE2 _app = null;

        public frmMultiCreateProjects(DTE2 app)
        {
            InitializeComponent();

            _app = app;           
        }

        private void frmMultiCreateProjects_Load(object sender, EventArgs e)
        {
            Solution3 sol3 = _app.Solution as Solution3;
            if (sol3 == null || string.IsNullOrEmpty(sol3.FileName))
            {
                return;
            }
            string slnPath = Path.GetDirectoryName(sol3.FileName);
            this.txtSaveDir.Text = slnPath;
            this.txtRootDir.Text = Path.GetFileNameWithoutExtension(sol3.FileName);
        }

        private void btnBrowseSaveDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "选择目录保存位置";
            string saveDir = this.txtSaveDir.Text.Trim();
            if (string.IsNullOrEmpty(saveDir) == false && Directory.Exists(saveDir))
            {
                fbd.SelectedPath = saveDir;
            }
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                this.txtSaveDir.Text = fbd.SelectedPath;
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
                string saveDir = this.txtSaveDir.Text.Trim();
                if (string.IsNullOrEmpty(saveDir)||Directory.Exists(saveDir)==false)
                {
                    MsgBox.ShowTip("请选择项目保存位置");
                    return;
                }
                string rootDir = this.txtRootDir.Text.Trim();
                rootDir = rootDir.TrimEnd('.');
                if (string.IsNullOrEmpty(rootDir))
                {
                    MsgBox.ShowTip("根名字空间不能为空");
                    return;
                }
                bool isExistFolder = false;
                for (int j = 1; j < sol3.Projects.Count; j++)
                {
                    Project proj = sol3.Projects.Item(j);
                    if (proj.Kind != ProjectKinds.vsProjectKindSolutionFolder)
                    {
                        continue;
                    }
                    if (sol3.Projects.Item(j).Name.Equals(rootDir, StringComparison.CurrentCultureIgnoreCase))
                    {
                        isExistFolder = true;
                        break;
                    }
                }
                if (isExistFolder == false)
                {
                    Project solFolder = sol3.AddSolutionFolder(rootDir);
                }
                List<Project> existProjs = ProjectUtility.GetAllProjects(_app);
                for (int i = 0; i < this.richTextBox1.Lines.Length; i++)
                {
                    string subDir = this.richTextBox1.Lines[i].Trim();
                    subDir = subDir.TrimStart('.').TrimEnd('.');
                    if (string.IsNullOrEmpty(subDir))
                    {
                        continue;
                    }
                    subDir = rootDir + "." + subDir;

                    string projPath = Path.Combine(saveDir, subDir + "\\" + subDir + ".csproj");
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
                        if (File.Exists(projPath))
                        {
                            DialogResult rlt = MsgBox.ShowOkCancel("项目保存位置下已经存在:" + subDir + "，是否需要加载？");
                            if (rlt == DialogResult.OK)
                            {
                                sol3.AddFromFile(projPath, false);
                            }
                            continue;
                        }
                        string templatePath = sol3.GetProjectTemplate("ClassLibrary.zip", "CSharp");
                        Project proj = sol3.AddFromTemplate(templatePath, Path.Combine(saveDir, subDir), subDir, true);
                    }
                    else
                    {
                        MsgBox.ShowTip(subDir + "已经存在");
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

    }
}
