namespace Leation.VSAddin
{
    partial class frmSelection2Upper
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
            this.btnSelection2Upper = new System.Windows.Forms.Button();
            this.btnSelection2Lower = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSelection2Upper
            // 
            this.btnSelection2Upper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSelection2Upper.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelection2Upper.ForeColor = System.Drawing.Color.Black;
            this.btnSelection2Upper.Location = new System.Drawing.Point(13, 13);
            this.btnSelection2Upper.Name = "btnSelection2Upper";
            this.btnSelection2Upper.Size = new System.Drawing.Size(114, 39);
            this.btnSelection2Upper.TabIndex = 0;
            this.btnSelection2Upper.Text = "转为大写";
            this.btnSelection2Upper.UseVisualStyleBackColor = true;
            // 
            // btnSelection2Lower
            // 
            this.btnSelection2Lower.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSelection2Lower.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelection2Lower.ForeColor = System.Drawing.Color.Black;
            this.btnSelection2Lower.Location = new System.Drawing.Point(146, 14);
            this.btnSelection2Lower.Name = "btnSelection2Lower";
            this.btnSelection2Lower.Size = new System.Drawing.Size(114, 39);
            this.btnSelection2Lower.TabIndex = 1;
            this.btnSelection2Lower.Text = "转为小写";
            this.btnSelection2Lower.UseVisualStyleBackColor = true;
            // 
            // frmSelection2Upper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 65);
            this.Controls.Add(this.btnSelection2Lower);
            this.Controls.Add(this.btnSelection2Upper);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelection2Upper";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSelection2Upper;
        private System.Windows.Forms.Button btnSelection2Lower;
    }
}