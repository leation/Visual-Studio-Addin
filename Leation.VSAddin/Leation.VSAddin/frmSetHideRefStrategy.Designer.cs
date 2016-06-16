namespace Leation.VSAddin
{
    partial class frmSetHideRefStrategy
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDirStrategy = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.combTemplate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStrStrategy = new System.Windows.Forms.TextBox();
            this.chkDirStrategy = new System.Windows.Forms.CheckBox();
            this.chkStrStrategy = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDirStrategy);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(6, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(515, 128);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lib根目录子文件夹下的所有文件";
            // 
            // txtDirStrategy
            // 
            this.txtDirStrategy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDirStrategy.Location = new System.Drawing.Point(3, 17);
            this.txtDirStrategy.Multiline = true;
            this.txtDirStrategy.Name = "txtDirStrategy";
            this.txtDirStrategy.Size = new System.Drawing.Size(509, 108);
            this.txtDirStrategy.TabIndex = 0;
            this.txtDirStrategy.Text = "Leation#GDAL";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.combTemplate);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtStrStrategy);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(6, 140);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(515, 141);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "所有包含以下字符串的dll(不含扩展名)";
            // 
            // combTemplate
            // 
            this.combTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combTemplate.FormattingEnabled = true;
            this.combTemplate.Items.AddRange(new object[] {
            "SQL",
            "Oracle"});
            this.combTemplate.Location = new System.Drawing.Point(83, 24);
            this.combTemplate.Name = "combTemplate";
            this.combTemplate.Size = new System.Drawing.Size(161, 20);
            this.combTemplate.TabIndex = 3;
            this.combTemplate.SelectedIndexChanged += new System.EventHandler(this.combTemplate_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "标准模板：";
            // 
            // txtStrStrategy
            // 
            this.txtStrStrategy.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtStrStrategy.Location = new System.Drawing.Point(3, 52);
            this.txtStrStrategy.Multiline = true;
            this.txtStrStrategy.Name = "txtStrStrategy";
            this.txtStrStrategy.Size = new System.Drawing.Size(509, 86);
            this.txtStrStrategy.TabIndex = 1;
            this.txtStrStrategy.Text = ".ORM#.IDAL#.SQLDAL#.DAL#.Entity#.Factory#.IBLL#.BLL#.WebBLL#.DetailFactory#.Detai" +
    "lBLL";
            // 
            // chkDirStrategy
            // 
            this.chkDirStrategy.AutoSize = true;
            this.chkDirStrategy.Location = new System.Drawing.Point(20, 299);
            this.chkDirStrategy.Name = "chkDirStrategy";
            this.chkDirStrategy.Size = new System.Drawing.Size(108, 16);
            this.chkDirStrategy.TabIndex = 2;
            this.chkDirStrategy.Text = "使用文件夹策略";
            this.chkDirStrategy.UseVisualStyleBackColor = true;
            // 
            // chkStrStrategy
            // 
            this.chkStrStrategy.AutoSize = true;
            this.chkStrStrategy.Location = new System.Drawing.Point(172, 299);
            this.chkStrStrategy.Name = "chkStrStrategy";
            this.chkStrStrategy.Size = new System.Drawing.Size(108, 16);
            this.chkStrStrategy.TabIndex = 2;
            this.chkStrStrategy.Text = "使用字符串策略";
            this.chkStrStrategy.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(442, 322);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "关闭";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(346, 322);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmSetHideRefStrategy
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(527, 352);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkStrStrategy);
            this.Controls.Add(this.chkDirStrategy);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmSetHideRefStrategy";
            this.Padding = new System.Windows.Forms.Padding(6, 12, 6, 0);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置隐藏依赖项拷贝策略";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDirStrategy;
        private System.Windows.Forms.TextBox txtStrStrategy;
        private System.Windows.Forms.CheckBox chkDirStrategy;
        private System.Windows.Forms.CheckBox chkStrStrategy;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox combTemplate;
        private System.Windows.Forms.Label label1;
    }
}