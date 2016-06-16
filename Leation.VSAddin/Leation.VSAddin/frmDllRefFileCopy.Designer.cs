namespace Leation.VSAddin
{
    partial class frmDllRefFileCopy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDllRefFileCopy));
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkCopyHideRefDlls = new System.Windows.Forms.CheckBox();
            this.lblSetHideRefStrategy = new System.Windows.Forms.LinkLabel();
            this.btnDestDir = new System.Windows.Forms.Button();
            this.txtDestDir = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkDeepCopy = new System.Windows.Forms.CheckBox();
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
            this.rMenuCopySelRefDlls = new System.Windows.Forms.ToolStripMenuItem();
            this.rMenuCopyAllRefDlls = new System.Windows.Forms.ToolStripMenuItem();
            this.rMenuBrowseSelPrjDllRef = new System.Windows.Forms.ToolStripMenuItem();
            this.rMenuBrowseDllRef = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.rMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkCopyHideRefDlls);
            this.panel1.Controls.Add(this.lblSetHideRefStrategy);
            this.panel1.Controls.Add(this.btnDestDir);
            this.panel1.Controls.Add(this.txtDestDir);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.chkDeepCopy);
            this.panel1.Controls.Add(this.btnLibRootDir);
            this.panel1.Controls.Add(this.txtLibRootDir);
            this.panel1.Controls.Add(this.combProjects);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(734, 171);
            this.panel1.TabIndex = 1;
            // 
            // chkCopyHideRefDlls
            // 
            this.chkCopyHideRefDlls.AutoSize = true;
            this.chkCopyHideRefDlls.Location = new System.Drawing.Point(450, 133);
            this.chkCopyHideRefDlls.Name = "chkCopyHideRefDlls";
            this.chkCopyHideRefDlls.Size = new System.Drawing.Size(108, 16);
            this.chkCopyHideRefDlls.TabIndex = 12;
            this.chkCopyHideRefDlls.Text = "拷贝隐藏依赖项";
            this.chkCopyHideRefDlls.UseVisualStyleBackColor = true;
            // 
            // lblSetHideRefStrategy
            // 
            this.lblSetHideRefStrategy.AutoSize = true;
            this.lblSetHideRefStrategy.Location = new System.Drawing.Point(571, 135);
            this.lblSetHideRefStrategy.Name = "lblSetHideRefStrategy";
            this.lblSetHideRefStrategy.Size = new System.Drawing.Size(149, 12);
            this.lblSetHideRefStrategy.TabIndex = 11;
            this.lblSetHideRefStrategy.TabStop = true;
            this.lblSetHideRefStrategy.Text = "设置隐藏的依赖项拷贝策略";
            this.lblSetHideRefStrategy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSetHideRefStrategy_LinkClicked);
            // 
            // btnDestDir
            // 
            this.btnDestDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDestDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDestDir.Location = new System.Drawing.Point(686, 94);
            this.btnDestDir.Name = "btnDestDir";
            this.btnDestDir.Size = new System.Drawing.Size(35, 23);
            this.btnDestDir.TabIndex = 10;
            this.btnDestDir.Text = "…";
            this.btnDestDir.UseVisualStyleBackColor = true;
            this.btnDestDir.Click += new System.EventHandler(this.btnDestDir_Click);
            // 
            // txtDestDir
            // 
            this.txtDestDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestDir.Location = new System.Drawing.Point(90, 96);
            this.txtDestDir.Name = "txtDestDir";
            this.txtDestDir.Size = new System.Drawing.Size(589, 21);
            this.txtDestDir.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "目标路径：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(82, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(335, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "（迭代所有dll的引用，包括依赖项的引用，可能迭代几十次）";
            // 
            // chkDeepCopy
            // 
            this.chkDeepCopy.AutoSize = true;
            this.chkDeepCopy.Checked = true;
            this.chkDeepCopy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDeepCopy.Location = new System.Drawing.Point(14, 133);
            this.chkDeepCopy.Name = "chkDeepCopy";
            this.chkDeepCopy.Size = new System.Drawing.Size(72, 16);
            this.chkDeepCopy.TabIndex = 6;
            this.chkDeepCopy.Text = "深层拷贝";
            this.chkDeepCopy.UseVisualStyleBackColor = true;
            // 
            // btnLibRootDir
            // 
            this.btnLibRootDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLibRootDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLibRootDir.Location = new System.Drawing.Point(685, 57);
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
            this.txtLibRootDir.Location = new System.Drawing.Point(89, 59);
            this.txtLibRootDir.Name = "txtLibRootDir";
            this.txtLibRootDir.Size = new System.Drawing.Size(589, 21);
            this.txtLibRootDir.TabIndex = 4;
            // 
            // combProjects
            // 
            this.combProjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combProjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combProjects.FormattingEnabled = true;
            this.combProjects.Location = new System.Drawing.Point(89, 17);
            this.combProjects.Name = "combProjects";
            this.combProjects.Size = new System.Drawing.Size(631, 20);
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
            this.panel2.Location = new System.Drawing.Point(0, 440);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(734, 40);
            this.panel2.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(648, 9);
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
            this.groupBox1.Location = new System.Drawing.Point(6, 177);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(73, 10, 3, 3);
            this.groupBox1.Size = new System.Drawing.Size(717, 247);
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
            this.dataGridView1.Size = new System.Drawing.Size(641, 220);
            this.dataGridView1.TabIndex = 0;
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
            this.rMenuCopySelRefDlls,
            this.rMenuCopyAllRefDlls,
            this.rMenuBrowseSelPrjDllRef,
            this.rMenuBrowseDllRef});
            this.rMenu.Name = "rMenu";
            this.rMenu.Size = new System.Drawing.Size(185, 92);
            // 
            // rMenuCopySelRefDlls
            // 
            this.rMenuCopySelRefDlls.Name = "rMenuCopySelRefDlls";
            this.rMenuCopySelRefDlls.Size = new System.Drawing.Size(184, 22);
            this.rMenuCopySelRefDlls.Text = "拷贝所选dll的引用";
            this.rMenuCopySelRefDlls.Click += new System.EventHandler(this.rMenuCopySelRefDlls_Click);
            // 
            // rMenuCopyAllRefDlls
            // 
            this.rMenuCopyAllRefDlls.Name = "rMenuCopyAllRefDlls";
            this.rMenuCopyAllRefDlls.Size = new System.Drawing.Size(184, 22);
            this.rMenuCopyAllRefDlls.Text = "拷贝所有项目的引用";
            this.rMenuCopyAllRefDlls.Click += new System.EventHandler(this.rMenuCopyAllRefDlls_Click);
            // 
            // rMenuBrowseSelPrjDllRef
            // 
            this.rMenuBrowseSelPrjDllRef.Name = "rMenuBrowseSelPrjDllRef";
            this.rMenuBrowseSelPrjDllRef.Size = new System.Drawing.Size(184, 22);
            this.rMenuBrowseSelPrjDllRef.Text = "查看当前项目的引用";
            this.rMenuBrowseSelPrjDllRef.Click += new System.EventHandler(this.rMenuBrowseSelPrjDllRef_Click);
            // 
            // rMenuBrowseDllRef
            // 
            this.rMenuBrowseDllRef.Name = "rMenuBrowseDllRef";
            this.rMenuBrowseDllRef.Size = new System.Drawing.Size(184, 22);
            this.rMenuBrowseDllRef.Text = "查看所有项目引用";
            this.rMenuBrowseDllRef.Click += new System.EventHandler(this.rMenuBrowseDllRef_Click);
            // 
            // frmDllRefFileCopy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(734, 480);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDllRefFileCopy";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "拷贝dll的引用(依赖项)";
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
        private System.Windows.Forms.Button btnLibRootDir;
        private System.Windows.Forms.CheckBox chkDeepCopy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem rMenuCopySelRefDlls;
        private System.Windows.Forms.ToolStripMenuItem rMenuCopyAllRefDlls;
        private System.Windows.Forms.Button btnDestDir;
        private System.Windows.Forms.TextBox txtDestDir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem rMenuBrowseDllRef;
        private System.Windows.Forms.LinkLabel lblSetHideRefStrategy;
        private System.Windows.Forms.CheckBox chkCopyHideRefDlls;
        private System.Windows.Forms.ToolStripMenuItem rMenuBrowseSelPrjDllRef;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}