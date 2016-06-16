namespace Leation.VSAddin
{
    partial class frmNetFrameworkSetting
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.combFramework = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRemoveEmptyDllRef = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colProject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlatform = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rMenuChkSel = new System.Windows.Forms.ToolStripMenuItem();
            this.rMenuReverseSel = new System.Windows.Forms.ToolStripMenuItem();
            this.rMenuSelAll = new System.Windows.Forms.ToolStripMenuItem();
            this.rMenuSelReverse = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.rMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.combFramework);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(673, 55);
            this.panel1.TabIndex = 1;
            // 
            // combFramework
            // 
            this.combFramework.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combFramework.FormattingEnabled = true;
            this.combFramework.Items.AddRange(new object[] {
            ".NET Framework 2.0",
            ".NET Framework 3.0",
            ".NET Framework 3.5",
            ".NET Framework 4.0",
            ".NET Framework 4.5"});
            this.combFramework.Location = new System.Drawing.Point(105, 14);
            this.combFramework.Name = "combFramework";
            this.combFramework.Size = new System.Drawing.Size(208, 20);
            this.combFramework.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "目标Framework：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnRemoveEmptyDllRef);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 404);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(673, 40);
            this.panel2.TabIndex = 2;
            // 
            // btnRemoveEmptyDllRef
            // 
            this.btnRemoveEmptyDllRef.Location = new System.Drawing.Point(506, 9);
            this.btnRemoveEmptyDllRef.Name = "btnRemoveEmptyDllRef";
            this.btnRemoveEmptyDllRef.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveEmptyDllRef.TabIndex = 1;
            this.btnRemoveEmptyDllRef.Text = "移除空引用";
            this.btnRemoveEmptyDllRef.UseVisualStyleBackColor = true;
            this.btnRemoveEmptyDllRef.Click += new System.EventHandler(this.btnRemoveEmptyDllRef_Click);
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
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(425, 9);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(6, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(73, 10, 3, 3);
            this.groupBox1.Size = new System.Drawing.Size(656, 319);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "项目列表：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck,
            this.colProject,
            this.colPlatform});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(73, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(580, 292);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDown);
            // 
            // colCheck
            // 
            this.colCheck.HeaderText = "选择状态";
            this.colCheck.Name = "colCheck";
            this.colCheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colCheck.Width = 80;
            // 
            // colProject
            // 
            this.colProject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProject.HeaderText = "项目名称";
            this.colProject.Name = "colProject";
            this.colProject.ReadOnly = true;
            // 
            // colPlatform
            // 
            this.colPlatform.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPlatform.HeaderText = "当前Framework版本";
            this.colPlatform.Name = "colPlatform";
            this.colPlatform.ReadOnly = true;
            // 
            // rMenu
            // 
            this.rMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rMenuChkSel,
            this.rMenuReverseSel,
            this.rMenuSelAll,
            this.rMenuSelReverse});
            this.rMenu.Name = "rMenu";
            this.rMenu.Size = new System.Drawing.Size(125, 92);
            // 
            // rMenuChkSel
            // 
            this.rMenuChkSel.Name = "rMenuChkSel";
            this.rMenuChkSel.Size = new System.Drawing.Size(124, 22);
            this.rMenuChkSel.Text = "选择";
            this.rMenuChkSel.Click += new System.EventHandler(this.rMenuChkSel_Click);
            // 
            // rMenuReverseSel
            // 
            this.rMenuReverseSel.Name = "rMenuReverseSel";
            this.rMenuReverseSel.Size = new System.Drawing.Size(124, 22);
            this.rMenuReverseSel.Text = "反选";
            this.rMenuReverseSel.Click += new System.EventHandler(this.rMenuReverseSel_Click);
            // 
            // rMenuSelAll
            // 
            this.rMenuSelAll.Name = "rMenuSelAll";
            this.rMenuSelAll.Size = new System.Drawing.Size(124, 22);
            this.rMenuSelAll.Text = "全选";
            this.rMenuSelAll.Click += new System.EventHandler(this.rMenuSelAll_Click);
            // 
            // rMenuSelReverse
            // 
            this.rMenuSelReverse.Name = "rMenuSelReverse";
            this.rMenuSelReverse.Size = new System.Drawing.Size(124, 22);
            this.rMenuSelReverse.Text = "全部反选";
            this.rMenuSelReverse.Click += new System.EventHandler(this.rMenuSelReverse_Click);
            // 
            // frmNetFrameworkSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(673, 444);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmNetFrameworkSetting";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".NET Framework版本设置";
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ContextMenuStrip rMenu;
        private System.Windows.Forms.ToolStripMenuItem rMenuSelAll;
        private System.Windows.Forms.ToolStripMenuItem rMenuSelReverse;
        private System.Windows.Forms.ComboBox combFramework;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem rMenuChkSel;
        private System.Windows.Forms.ToolStripMenuItem rMenuReverseSel;
        private System.Windows.Forms.Button btnRemoveEmptyDllRef;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProject;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlatform;
    }
}