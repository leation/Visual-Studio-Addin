namespace Leation.VSAddin
{
    partial class frmDllRefSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDllRefSetting));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnInfragisticsDir = new System.Windows.Forms.Button();
            this.txtInfragisticsDir = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDotNetBarDir = new System.Windows.Forms.Button();
            this.txtDotNetBarDir = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.combSolutionPlatform = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkProItemFirst = new System.Windows.Forms.CheckBox();
            this.btnLibRootDir = new System.Windows.Forms.Button();
            this.txtLibRootDir = new System.Windows.Forms.TextBox();
            this.combProjects = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rMenuModifySelection = new System.Windows.Forms.ToolStripMenuItem();
            this.rMenuModifyAll = new System.Windows.Forms.ToolStripMenuItem();
            this.rMenuAddRefs = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRemoveRefs = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.rMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnInfragisticsDir);
            this.panel1.Controls.Add(this.txtInfragisticsDir);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnDotNetBarDir);
            this.panel1.Controls.Add(this.txtDotNetBarDir);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.combSolutionPlatform);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.chkProItemFirst);
            this.panel1.Controls.Add(this.btnLibRootDir);
            this.panel1.Controls.Add(this.txtLibRootDir);
            this.panel1.Controls.Add(this.combProjects);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(673, 221);
            this.panel1.TabIndex = 1;
            // 
            // btnInfragisticsDir
            // 
            this.btnInfragisticsDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInfragisticsDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfragisticsDir.Location = new System.Drawing.Point(624, 135);
            this.btnInfragisticsDir.Name = "btnInfragisticsDir";
            this.btnInfragisticsDir.Size = new System.Drawing.Size(35, 23);
            this.btnInfragisticsDir.TabIndex = 19;
            this.btnInfragisticsDir.Text = "…";
            this.btnInfragisticsDir.UseVisualStyleBackColor = true;
            this.btnInfragisticsDir.Click += new System.EventHandler(this.btnInfragisticsDir_Click);
            // 
            // txtInfragisticsDir
            // 
            this.txtInfragisticsDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfragisticsDir.Location = new System.Drawing.Point(107, 137);
            this.txtInfragisticsDir.Name = "txtInfragisticsDir";
            this.txtInfragisticsDir.Size = new System.Drawing.Size(510, 21);
            this.txtInfragisticsDir.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "Infragistics：";
            // 
            // btnDotNetBarDir
            // 
            this.btnDotNetBarDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDotNetBarDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDotNetBarDir.Location = new System.Drawing.Point(624, 96);
            this.btnDotNetBarDir.Name = "btnDotNetBarDir";
            this.btnDotNetBarDir.Size = new System.Drawing.Size(35, 23);
            this.btnDotNetBarDir.TabIndex = 16;
            this.btnDotNetBarDir.Text = "…";
            this.btnDotNetBarDir.UseVisualStyleBackColor = true;
            this.btnDotNetBarDir.Click += new System.EventHandler(this.btnDotNetBarDir_Click);
            // 
            // txtDotNetBarDir
            // 
            this.txtDotNetBarDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDotNetBarDir.Location = new System.Drawing.Point(107, 98);
            this.txtDotNetBarDir.Name = "txtDotNetBarDir";
            this.txtDotNetBarDir.Size = new System.Drawing.Size(510, 21);
            this.txtDotNetBarDir.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "DotNetBar：";
            // 
            // combSolutionPlatform
            // 
            this.combSolutionPlatform.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combSolutionPlatform.FormattingEnabled = true;
            this.combSolutionPlatform.Location = new System.Drawing.Point(250, 178);
            this.combSolutionPlatform.Name = "combSolutionPlatform";
            this.combSolutionPlatform.Size = new System.Drawing.Size(157, 20);
            this.combSolutionPlatform.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "解决方案配置：";
            // 
            // chkProItemFirst
            // 
            this.chkProItemFirst.AutoSize = true;
            this.chkProItemFirst.Checked = true;
            this.chkProItemFirst.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkProItemFirst.Location = new System.Drawing.Point(12, 180);
            this.chkProItemFirst.Name = "chkProItemFirst";
            this.chkProItemFirst.Size = new System.Drawing.Size(96, 16);
            this.chkProItemFirst.TabIndex = 11;
            this.chkProItemFirst.Text = "优先引用项目";
            this.chkProItemFirst.UseVisualStyleBackColor = true;
            // 
            // btnLibRootDir
            // 
            this.btnLibRootDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLibRootDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLibRootDir.Location = new System.Drawing.Point(624, 57);
            this.btnLibRootDir.Name = "btnLibRootDir";
            this.btnLibRootDir.Size = new System.Drawing.Size(35, 23);
            this.btnLibRootDir.TabIndex = 5;
            this.btnLibRootDir.Text = "…";
            this.btnLibRootDir.UseVisualStyleBackColor = true;
            this.btnLibRootDir.Click += new System.EventHandler(this.btnLibRootDir_Click);
            // 
            // txtLibRootDir
            // 
            this.txtLibRootDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLibRootDir.Location = new System.Drawing.Point(107, 59);
            this.txtLibRootDir.Name = "txtLibRootDir";
            this.txtLibRootDir.Size = new System.Drawing.Size(510, 21);
            this.txtLibRootDir.TabIndex = 4;
            // 
            // combProjects
            // 
            this.combProjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combProjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combProjects.FormattingEnabled = true;
            this.combProjects.Location = new System.Drawing.Point(107, 17);
            this.combProjects.Name = "combProjects";
            this.combProjects.Size = new System.Drawing.Size(552, 20);
            this.combProjects.TabIndex = 3;
            this.combProjects.SelectedIndexChanged += new System.EventHandler(this.combProjects_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "项目列表：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lib根目录：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 404);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(673, 40);
            this.panel2.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(587, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "关闭";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(6, 227);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(73, 10, 3, 3);
            this.groupBox1.Size = new System.Drawing.Size(656, 161);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "项目dll引用列表：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(73, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(580, 134);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            this.dataGridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDown);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "dll名称";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 72;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "dll路径";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // rMenu
            // 
            this.rMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rMenuModifySelection,
            this.rMenuModifyAll,
            this.rMenuAddRefs,
            this.btnRemoveRefs});
            this.rMenu.Name = "rMenu";
            this.rMenu.Size = new System.Drawing.Size(276, 92);
            // 
            // rMenuModifySelection
            // 
            this.rMenuModifySelection.Name = "rMenuModifySelection";
            this.rMenuModifySelection.Size = new System.Drawing.Size(275, 22);
            this.rMenuModifySelection.Text = "所选dll修改为引用Lib根目录下的dll";
            this.rMenuModifySelection.Click += new System.EventHandler(this.rMenuModifySelection_Click);
            // 
            // rMenuModifyAll
            // 
            this.rMenuModifyAll.Name = "rMenuModifyAll";
            this.rMenuModifyAll.Size = new System.Drawing.Size(275, 22);
            this.rMenuModifyAll.Text = "全部项目修改为引用Lib根目录下的dll";
            this.rMenuModifyAll.Click += new System.EventHandler(this.rMenuModifyAll_Click);
            // 
            // rMenuAddRefs
            // 
            this.rMenuAddRefs.Name = "rMenuAddRefs";
            this.rMenuAddRefs.Size = new System.Drawing.Size(275, 22);
            this.rMenuAddRefs.Text = "添加引用";
            this.rMenuAddRefs.Click += new System.EventHandler(this.rMenuAddRefs_Click);
            // 
            // btnRemoveRefs
            // 
            this.btnRemoveRefs.Name = "btnRemoveRefs";
            this.btnRemoveRefs.Size = new System.Drawing.Size(275, 22);
            this.btnRemoveRefs.Text = "删除引用";
            this.btnRemoveRefs.Click += new System.EventHandler(this.btnRemoveRefs_Click);
            // 
            // frmDllRefSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(673, 444);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDllRefSetting";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改项目dll引用";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDllRefSetting_FormClosing);
            this.Load += new System.EventHandler(this.frmDllRefSetting_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.rMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ContextMenuStrip rMenu;
        private System.Windows.Forms.ComboBox combProjects;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLibRootDir;
        private System.Windows.Forms.ToolStripMenuItem rMenuModifyAll;
        private System.Windows.Forms.ToolStripMenuItem rMenuModifySelection;
        private System.Windows.Forms.Button btnLibRootDir;
        private System.Windows.Forms.ToolStripMenuItem rMenuAddRefs;
        private System.Windows.Forms.ToolStripMenuItem btnRemoveRefs;
        private System.Windows.Forms.CheckBox chkProItemFirst;
        private System.Windows.Forms.ComboBox combSolutionPlatform;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button btnInfragisticsDir;
        private System.Windows.Forms.TextBox txtInfragisticsDir;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDotNetBarDir;
        private System.Windows.Forms.TextBox txtDotNetBarDir;
        private System.Windows.Forms.Label label4;
    }
}