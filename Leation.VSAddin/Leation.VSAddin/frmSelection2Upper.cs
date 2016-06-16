using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Leation.VSAddin
{
    public partial class frmSelection2Upper : Form
    {
        public Button BtnSelection2Upper
        {
            get
            {
                return this.btnSelection2Upper;
            }
        }

        public Button BtnSelection2Lower
        {
            get
            {
                return this.btnSelection2Lower;
            }
        }

        public frmSelection2Upper()
        {
            InitializeComponent();
        }
    }
}
