using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Leation.VSAddin
{
    public partial class GuidCreatorUI : UserControl
    {
        public GuidCreatorUI()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.txtRlt.Clear();
            int num = (int)(this.numericUpDown1.Value);
            for (int i = 0; i < num; i++)
            {
                string guidStr = Guid.NewGuid().ToString();
                if (this.chkUpper.Checked)
                {
                    guidStr = guidStr.ToUpper();
                }
                this.txtRlt.AppendText(guidStr);
                this.txtRlt.AppendText("\n");
            }
        }

        private void GuidCreatorUI_Load(object sender, EventArgs e)
        {
            this.btnCreate_Click(null, null);
        }  
    }
}
