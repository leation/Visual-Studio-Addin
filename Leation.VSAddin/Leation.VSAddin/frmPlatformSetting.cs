using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EnvDTE80;
using EnvDTE;
using System.IO;

namespace Leation.VSAddin
{
    public partial class frmPlatformSetting : Form
    {
        private DTE2 _app = null;

        public frmPlatformSetting(DTE2 app)
        {
            InitializeComponent();

            _app = app;

            this.combPlatform.SelectedIndex = 0;

            List<Project> pros = ProjectUtility.GetAllProjects(_app);
            if (pros != null && pros.Count > 0)
            {
                this.dataGridView1.Rows.Add(pros.Count);
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

                    this.dataGridView1[0, i].Value = true;
                    this.dataGridView1[1, i].Value = pros[i].Name;

                    this.dataGridView1.Rows[i].Tag = pros[i];
                }
                if (this.combSolutionPlatform.Items.Count > 0)
                {
                    this.combSolutionPlatform.SelectedItem = activeConfigName;
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

        private void combSolutionPlatform_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.combSolutionPlatform.SelectedItem == null)
            {
                return;
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
                            this.dataGridView1[2, i].Value = config.Properties.Item("PlatformTarget").Value.ToString();
                            break;
                        }
                    }
                }
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

            if (this.combPlatform.SelectedItem == null)
            {
                MsgBox.ShowTip("请先选择目标平台");
                return;
            }
            if (this.combSolutionPlatform.SelectedItem == null)
            {
                MsgBox.ShowTip("请先选择解决平台");
                return;
            }
            string platform = this.combPlatform.SelectedItem.ToString();
            string solPlatform = this.combSolutionPlatform.SelectedItem.ToString();
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
                    foreach (Configuration config in proj.ConfigurationManager)
                    {
                        if (config.ConfigurationName == solPlatform)
                        {
                            config.Properties.Item("PlatformTarget").Value = platform;
                            this.dataGridView1[2, i].Value = platform;
                            num++;
                            break;
                        }
                    }
                }
            }
            MsgBox.ShowTip(string.Format("修改目标平台完成，总共修改{0}个项目",num));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
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
