using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EnvDTE80;
using EnvDTE;
using VSLangProj;

namespace Leation.VSAddin
{
    public partial class frmNetFrameworkSetting : Form
    {
        private DTE2 _app = null;

        public frmNetFrameworkSetting(DTE2 app)
        {
            InitializeComponent();

            _app = app;

            this.combFramework.SelectedIndex = 0;

            List<Project> pros = ProjectUtility.GetAllProjects(_app);
            if (pros != null && pros.Count > 0)
            {
                this.dataGridView1.Rows.Add(pros.Count);
                for (int i = 0; i < pros.Count; i++)
                {
                    this.dataGridView1[0, i].Value = true;
                    this.dataGridView1[1, i].Value = pros[i].Name;

                    string frameworkId=pros[i].Properties.Item("TargetFramework").Value.ToString();
                    this.dataGridView1[2, i].Value = GetFrameworkString(frameworkId);

                    this.dataGridView1.Rows[i].Tag = pros[i];
                }
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

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.rMenu.Show(this.dataGridView1, e.Location);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Solution sol = _app.Solution as Solution;
            if (sol == null || string.IsNullOrEmpty(sol.FileName))
            {
                MsgBox.ShowTip("请先打开已有解决方案或者新建一个解决方案");
                return;
            }
            if (this.combFramework.SelectedItem == null)
            {
                MsgBox.ShowTip("请先选择解决平台");
                return;
            }
            DialogResult rlt = MsgBox.ShowOkCancel("您确定要批量修改.NET Framework版本吗？");
            if (rlt == DialogResult.Cancel)
            {
                return;
            }
            string framework = this.combFramework.SelectedItem.ToString();
            int num = 0;
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                object obj = this.dataGridView1[0, i].Value;
                bool isSel = (bool)obj;
                if (isSel == false)
                {
                    continue;
                }
                Project proj = this.dataGridView1.Rows[i].Tag as Project;
                if (proj != null)
                {
                    proj.Properties.Item("TargetFramework").Value = this.GetFrameworkId(framework);
                    this.dataGridView1[2, i].Value = framework;
                    num++;
                }
            }
            MsgBox.ShowTip(string.Format("修改输出路径完成，总共修改{0}个项目",num));
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private string GetFrameworkString(string id)
        {
            string name = string.Empty;
            switch (id)
            {
                case "131072":
                    name = ".NET Framework 2.0";
                    break;
                case "196608":
                    name = ".NET Framework 3.0";
                    break;
                case "196613":
                    name = ".NET Framework 3.5";
                    break;
                case "262144":
                    name = ".NET Framework 4.0";
                    break;
                case "262149":
                    name = ".NET Framework 4.5";
                    break;
                default:
                    break;
            }
            return name;
        }

        private string GetFrameworkId(string frameworkName)
        {
            string id = string.Empty;
            switch (frameworkName)
            {
                case ".NET Framework 2.0":
                    id = "131072";
                    break;
                case ".NET Framework 3.0":
                    id = "196608";
                    break;
                case ".NET Framework 3.5":
                    id = "196613";
                    break;
                case ".NET Framework 4.0":
                    id = "262144";
                    break;
                case ".NET Framework 4.5":
                    id = "262149";
                    break;
                default:
                    break;
            }
            return id;
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

        private void btnRemoveEmptyDllRef_Click(object sender, EventArgs e)
        {
            Solution sol = _app.Solution as Solution;
            if (sol == null || string.IsNullOrEmpty(sol.FileName))
            {
                MsgBox.ShowTip("请先打开已有解决方案或者新建一个解决方案");
                return;
            }
            DialogResult rlt = MsgBox.ShowOkCancel("您确定要移除dll引用路径为空的引用吗？");
            if (rlt == DialogResult.Cancel)
            {
                return;
            }
            int num = 0;
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                object obj = this.dataGridView1[0, i].Value;
                bool isSel = (bool)obj;
                if (isSel == false)
                {
                    continue;
                }
                Project proj = this.dataGridView1.Rows[i].Tag as Project;
                if (proj != null)
                {
                    try
                    {
                        VSProject vsProj = proj.Object as VSProject;
                        if (vsProj == null)
                        {
                            continue;
                        }
                        References dllRefs = vsProj.References;
                        foreach (Reference dllRef in dllRefs)
                        {
                            if (string.IsNullOrEmpty(dllRef.Path))
                            {
                                dllRef.Remove();
                                num++;
                            }
                        }
                    }
                    catch
                    {

                    }
                }
            }
            MsgBox.ShowTip(string.Format("移除空引用完成，总共移除{0}个空引用", num));
        }

    }
}
