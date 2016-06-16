namespace Leation.VSAddin
{
    partial class frmMultiLoadProjects
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
            this.label4 = new System.Windows.Forms.Label();
            this.lblRefresh = new System.Windows.Forms.LinkLabel();
            this.btnBrowseRootDir = new System.Windows.Forms.Button();
            this.txtFilterStr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRootDir = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.rMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rMenuSelAll = new System.Windows.Forms.ToolStripMenuItem();
            this.rMenuSelReverse = new System.Windows.Forms.ToolStripMenuItem();
            this.rMenuUncheckedSolDir = new System.Windows.Forms.ToolStripMenuItem();
            this.rMenuExpandAll = new System.Windows.Forms.ToolStripMenuItem();
            this.rMenuCollapseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.rMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblRefresh);
            this.panel1.Controls.Add(this.btnBrowseRootDir);
            this.panel1.Controls.Add(this.txtFilterStr);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtRootDir);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 115);
            this.panel1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(129, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "如果有多个用逗号分隔";
            // 
            // lblRefresh
            // 
            this.lblRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRefresh.AutoSize = true;
            this.lblRefresh.Location = new System.Drawing.Point(739, 59);
            this.lblRefresh.Name = "lblRefresh";
            this.lblRefresh.Size = new System.Drawing.Size(29, 12);
            this.lblRefresh.TabIndex = 5;
            this.lblRefresh.TabStop = true;
            this.lblRefresh.Text = "刷新";
            this.lblRefresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblRefresh_LinkClicked);
            // 
            // btnBrowseRootDir
            // 
            this.btnBrowseRootDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseRootDir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBrowseRootDir.Location = new System.Drawing.Point(739, 13);
            this.btnBrowseRootDir.Name = "btnBrowseRootDir";
            this.btnBrowseRootDir.Size = new System.Drawing.Size(35, 23);
            this.btnBrowseRootDir.TabIndex = 4;
            this.btnBrowseRootDir.Text = "…";
            this.btnBrowseRootDir.UseVisualStyleBackColor = true;
            this.btnBrowseRootDir.Click += new System.EventHandler(this.btnBrowseRootDir_Click);
            // 
            // txtFilterStr
            // 
            this.txtFilterStr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilterStr.Location = new System.Drawing.Point(131, 55);
            this.txtFilterStr.Name = "txtFilterStr";
            this.txtFilterStr.Size = new System.Drawing.Size(602, 21);
            this.txtFilterStr.TabIndex = 3;
            this.txtFilterStr.Text = "ORM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "过滤项目：";
            // 
            // txtRootDir
            // 
            this.txtRootDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRootDir.Location = new System.Drawing.Point(131, 15);
            this.txtRootDir.Name = "txtRootDir";
            this.txtRootDir.Size = new System.Drawing.Size(602, 21);
            this.txtRootDir.TabIndex = 3;
            this.txtRootDir.TextChanged += new System.EventHandler(this.txtRootDir_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "项目存放根目录：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 479);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(786, 40);
            this.panel2.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(700, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(604, 9);
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
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.treeView1);
            this.groupBox1.Location = new System.Drawing.Point(6, 121);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(73, 10, 3, 3);
            this.groupBox1.Size = new System.Drawing.Size(769, 342);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "项目列表：";
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(33, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 270);
            this.label1.TabIndex = 1;
            this.label1.Text = "如果需要创建解决方案目录，请勾选项目的父节点";
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(73, 27);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(695, 315);
            this.treeView1.TabIndex = 0;
            this.treeView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView1_ItemDrag);
            this.treeView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView1_DragDrop);
            this.treeView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView1_DragEnter);
            this.treeView1.DragOver += new System.Windows.Forms.DragEventHandler(this.treeView1_DragOver);
            this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
            // 
            // rMenu
            // 
            this.rMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rMenuSelAll,
            this.rMenuSelReverse,
            this.rMenuUncheckedSolDir,
            this.rMenuExpandAll,
            this.rMenuCollapseAll});
            this.rMenu.Name = "rMenu";
            this.rMenu.Size = new System.Drawing.Size(197, 114);
            // 
            // rMenuSelAll
            // 
            this.rMenuSelAll.Name = "rMenuSelAll";
            this.rMenuSelAll.Size = new System.Drawing.Size(196, 22);
            this.rMenuSelAll.Text = "全选";
            this.rMenuSelAll.Click += new System.EventHandler(this.rMenuSelAll_Click);
            // 
            // rMenuSelReverse
            // 
            this.rMenuSelReverse.Name = "rMenuSelReverse";
            this.rMenuSelReverse.Size = new System.Drawing.Size(196, 22);
            this.rMenuSelReverse.Text = "全部反选";
            this.rMenuSelReverse.Click += new System.EventHandler(this.rMenuSelReverse_Click);
            // 
            // rMenuUncheckedSolDir
            // 
            this.rMenuUncheckedSolDir.Name = "rMenuUncheckedSolDir";
            this.rMenuUncheckedSolDir.Size = new System.Drawing.Size(196, 22);
            this.rMenuUncheckedSolDir.Text = "不选择解决方案文件夹";
            this.rMenuUncheckedSolDir.Click += new System.EventHandler(this.rMenuUncheckedSolDir_Click);
            // 
            // rMenuExpandAll
            // 
            this.rMenuExpandAll.Name = "rMenuExpandAll";
            this.rMenuExpandAll.Size = new System.Drawing.Size(196, 22);
            this.rMenuExpandAll.Text = "全部展开";
            this.rMenuExpandAll.Click += new System.EventHandler(this.rMenuExpandAll_Click);
            // 
            // rMenuCollapseAll
            // 
            this.rMenuCollapseAll.Name = "rMenuCollapseAll";
            this.rMenuCollapseAll.Size = new System.Drawing.Size(196, 22);
            this.rMenuCollapseAll.Text = "全部折叠";
            this.rMenuCollapseAll.Click += new System.EventHandler(this.rMenuCollapseAll_Click);
            // 
            // frmMultiLoadProjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(786, 519);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmMultiLoadProjects";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "批量加载项目";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.rMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ContextMenuStrip rMenu;
        private System.Windows.Forms.ToolStripMenuItem rMenuSelAll;
        private System.Windows.Forms.ToolStripMenuItem rMenuSelReverse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowseRootDir;
        private System.Windows.Forms.TextBox txtRootDir;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem rMenuUncheckedSolDir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel lblRefresh;
        private System.Windows.Forms.TextBox txtFilterStr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem rMenuExpandAll;
        private System.Windows.Forms.ToolStripMenuItem rMenuCollapseAll;
    }
}