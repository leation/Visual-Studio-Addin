namespace Leation.VSAddin
{
    partial class SQLCreatorUI
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCreateXML = new System.Windows.Forms.Button();
            this.combDestCodeFld = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.combSheet = new System.Windows.Forms.ComboBox();
            this.combSrcCodeFld = new System.Windows.Forms.ComboBox();
            this.lblExampleExcelFile = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExcelFile = new System.Windows.Forms.TextBox();
            this.btnXmlDir = new System.Windows.Forms.Button();
            this.txtXmlDir = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtStringArray = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnCreateStrArray = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.combSQLType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRlt = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreateXML
            // 
            this.btnCreateXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateXML.BackColor = System.Drawing.Color.Transparent;
            this.btnCreateXML.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCreateXML.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(154)))), ((int)(((byte)(153)))));
            this.btnCreateXML.Location = new System.Drawing.Point(652, 125);
            this.btnCreateXML.Name = "btnCreateXML";
            this.btnCreateXML.Size = new System.Drawing.Size(92, 30);
            this.btnCreateXML.TabIndex = 17;
            this.btnCreateXML.Text = "生成XML";
            this.btnCreateXML.UseVisualStyleBackColor = false;
            // 
            // combDestCodeFld
            // 
            this.combDestCodeFld.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combDestCodeFld.FormattingEnabled = true;
            this.combDestCodeFld.Location = new System.Drawing.Point(478, 135);
            this.combDestCodeFld.Name = "combDestCodeFld";
            this.combDestCodeFld.Size = new System.Drawing.Size(115, 20);
            this.combDestCodeFld.TabIndex = 15;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(218)))), ((int)(((byte)(250)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(758, 293);
            this.dataGridView1.TabIndex = 0;
            // 
            // combSheet
            // 
            this.combSheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combSheet.FormattingEnabled = true;
            this.combSheet.Location = new System.Drawing.Point(63, 135);
            this.combSheet.Name = "combSheet";
            this.combSheet.Size = new System.Drawing.Size(122, 20);
            this.combSheet.TabIndex = 16;
            // 
            // combSrcCodeFld
            // 
            this.combSrcCodeFld.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combSrcCodeFld.FormattingEnabled = true;
            this.combSrcCodeFld.Location = new System.Drawing.Point(262, 135);
            this.combSrcCodeFld.Name = "combSrcCodeFld";
            this.combSrcCodeFld.Size = new System.Drawing.Size(116, 20);
            this.combSrcCodeFld.TabIndex = 16;
            // 
            // lblExampleExcelFile
            // 
            this.lblExampleExcelFile.AutoSize = true;
            this.lblExampleExcelFile.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(154)))), ((int)(((byte)(153)))));
            this.lblExampleExcelFile.Location = new System.Drawing.Point(19, 99);
            this.lblExampleExcelFile.Name = "lblExampleExcelFile";
            this.lblExampleExcelFile.Size = new System.Drawing.Size(53, 12);
            this.lblExampleExcelFile.TabIndex = 14;
            this.lblExampleExcelFile.TabStop = true;
            this.lblExampleExcelFile.Text = "示例文件";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(407, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "目标编号：";
            // 
            // txtExcelFile
            // 
            this.txtExcelFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExcelFile.Location = new System.Drawing.Point(92, 14);
            this.txtExcelFile.Name = "txtExcelFile";
            this.txtExcelFile.ReadOnly = true;
            this.txtExcelFile.Size = new System.Drawing.Size(611, 21);
            this.txtExcelFile.TabIndex = 12;
            // 
            // btnXmlDir
            // 
            this.btnXmlDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXmlDir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(154)))), ((int)(((byte)(153)))));
            this.btnXmlDir.Location = new System.Drawing.Point(709, 54);
            this.btnXmlDir.Name = "btnXmlDir";
            this.btnXmlDir.Size = new System.Drawing.Size(35, 23);
            this.btnXmlDir.TabIndex = 13;
            this.btnXmlDir.Text = "…";
            this.btnXmlDir.UseVisualStyleBackColor = true;
            // 
            // txtXmlDir
            // 
            this.txtXmlDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtXmlDir.Location = new System.Drawing.Point(92, 56);
            this.txtXmlDir.Name = "txtXmlDir";
            this.txtXmlDir.ReadOnly = true;
            this.txtXmlDir.Size = new System.Drawing.Size(611, 21);
            this.txtXmlDir.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "Sheet：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "XML目录：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "源编号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "excel文件：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 454);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtStringArray);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 454);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "字符串数组";
            // 
            // txtStringArray
            // 
            this.txtStringArray.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStringArray.Location = new System.Drawing.Point(3, 17);
            this.txtStringArray.Name = "txtStringArray";
            this.txtStringArray.Size = new System.Drawing.Size(268, 434);
            this.txtStringArray.TabIndex = 0;
            this.txtStringArray.Text = "a\nb\nc";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(280, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(520, 454);
            this.panel2.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnCreateStrArray);
            this.splitContainer1.Panel1.Controls.Add(this.btnCreate);
            this.splitContainer1.Panel1.Controls.Add(this.combSQLType);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtRlt);
            this.splitContainer1.Size = new System.Drawing.Size(520, 454);
            this.splitContainer1.SplitterDistance = 55;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnCreateStrArray
            // 
            this.btnCreateStrArray.BackColor = System.Drawing.Color.Transparent;
            this.btnCreateStrArray.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCreateStrArray.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(154)))), ((int)(((byte)(153)))));
            this.btnCreateStrArray.Location = new System.Drawing.Point(357, 12);
            this.btnCreateStrArray.Name = "btnCreateStrArray";
            this.btnCreateStrArray.Size = new System.Drawing.Size(124, 30);
            this.btnCreateStrArray.TabIndex = 19;
            this.btnCreateStrArray.Text = "反生成字符串数组";
            this.btnCreateStrArray.UseVisualStyleBackColor = false;
            this.btnCreateStrArray.Click += new System.EventHandler(this.btnCreateStrArray_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.Transparent;
            this.btnCreate.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCreate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(154)))), ((int)(((byte)(153)))));
            this.btnCreate.Location = new System.Drawing.Point(244, 12);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(92, 30);
            this.btnCreate.TabIndex = 18;
            this.btnCreate.Text = "生成SQL";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // combSQLType
            // 
            this.combSQLType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combSQLType.FormattingEnabled = true;
            this.combSQLType.Items.AddRange(new object[] {
            "用,分割",
            "用\',分割",
            "用\",分割",
            "delete from"});
            this.combSQLType.Location = new System.Drawing.Point(83, 17);
            this.combSQLType.Name = "combSQLType";
            this.combSQLType.Size = new System.Drawing.Size(120, 20);
            this.combSQLType.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "SQL类型：";
            // 
            // txtRlt
            // 
            this.txtRlt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRlt.Location = new System.Drawing.Point(0, 0);
            this.txtRlt.Name = "txtRlt";
            this.txtRlt.Size = new System.Drawing.Size(520, 395);
            this.txtRlt.TabIndex = 1;
            this.txtRlt.Text = "a,b,c";
            // 
            // SQLCreatorUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "SQLCreatorUI";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Size = new System.Drawing.Size(806, 466);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateXML;
        private System.Windows.Forms.ComboBox combDestCodeFld;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox combSheet;
        private System.Windows.Forms.ComboBox combSrcCodeFld;
        private System.Windows.Forms.LinkLabel lblExampleExcelFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExcelFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXmlDir;
        private System.Windows.Forms.TextBox txtXmlDir;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox txtStringArray;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox txtRlt;
        private System.Windows.Forms.ComboBox combSQLType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCreateStrArray;
    }
}
