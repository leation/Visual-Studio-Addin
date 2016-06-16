using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EnvDTE80;
using EnvDTE;

namespace Leation.VSAddin
{
    public partial class frmBuildEventSetting : Form
    {
        private DTE2 _app = null;

        public frmBuildEventSetting(DTE2 app)
        {
            InitializeComponent();

            _app = app;

            List<Project> pros = ProjectUtility.GetAllProjects(_app);
            if (pros != null && pros.Count > 0)
            {
                this.dataGridView1.Rows.Add(pros.Count);
                for (int i = 0; i < pros.Count; i++)
                {
                    this.dataGridView1[0, i].Value = false;
                    this.dataGridView1[1, i].Value = pros[i].Name;

                    this.dataGridView1[2, i].Value = pros[i].Properties.Item("PreBuildEvent").Value.ToString();
                    this.dataGridView1[3, i].Value = pros[i].Properties.Item("PostBuildEvent").Value.ToString();

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
            DialogResult rlt = MsgBox.ShowOkCancel("您确定要批量修改生成前事件和生成后事件吗？");
            if (rlt == DialogResult.Cancel)
            {
                return;
            }
            string preBuildEvent = this.txtPreBuildEvent.Text.Trim();
            string postBuildEvent = this.txtPostBuildEvent.Text.Trim();
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
                    proj.Properties.Item("PreBuildEvent").Value = preBuildEvent;
                    proj.Properties.Item("PostBuildEvent").Value = postBuildEvent;
                    this.dataGridView1[2, i].Value = preBuildEvent;
                    this.dataGridView1[3, i].Value = postBuildEvent;
                    num++;
                }
            }
            MsgBox.ShowTip(string.Format("修改输出路径完成，总共修改{0}个项目",num));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 3)
            {
                object obj = this.dataGridView1[e.ColumnIndex, e.RowIndex].Value;
                if (obj != null)
                {
                    string value = obj.ToString();
                    if (string.IsNullOrEmpty(value) == false)
                    {
                        SaveText2Notepad.SaveContext(value, true);
                    }
                }
            }
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

       
    }
}
