using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Leation.VSAddin
{
    public partial class frmSetHideRefStrategy : Form
    {
        private CopyStrategyModel _copyStrategy = null;
        public CopyStrategyModel CopyStrategy
        {
            get
            {
                return _copyStrategy;
            }
        }

        public frmSetHideRefStrategy(CopyStrategyModel copyStrategy)
        {
            InitializeComponent();

            _copyStrategy = copyStrategy;

            if (_copyStrategy != null)
            {
                if (_copyStrategy.DirStrategyList.Count > 0)
                {
                    this.txtDirStrategy.Text = this.GetCombainStr(_copyStrategy.DirStrategyList);
                }
                if (_copyStrategy.StrStrategyList.Count > 0)
                {
                    this.txtStrStrategy.Text = this.GetCombainStr(_copyStrategy.StrStrategyList);
                }
                this.chkDirStrategy.Checked = _copyStrategy.UseDirStrategy;
                this.chkStrStrategy.Checked = _copyStrategy.UseStrStrategy;
            }
        }

        private void combTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.combTemplate.SelectedIndex == 0)
            {
                this.txtStrStrategy.Text = ".ORM#.IDAL#.SQLDAL#.DAL#.Entity#.Factory#.IBLL#.BLL#.WebBLL#.DetailFactory#.DetailBLL";
            }
            else if (this.combTemplate.SelectedIndex == 1)
            {
                this.txtStrStrategy.Text = ".IDAL#.DAL#.OracleDAL#.OracleORM#.Entity#.Factory#.IBLL#.BLL#.WebBLL#.DetailFactory#.DetailBLL";
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _copyStrategy = new CopyStrategyModel();

            _copyStrategy.UseDirStrategy = this.chkDirStrategy.Checked;
            _copyStrategy.UseStrStrategy = this.chkStrStrategy.Checked;

            string str = this.txtDirStrategy.Text.Trim();
            string[] strArray = str.Split('#');
            if (strArray != null && strArray.Length > 0)
            {
                _copyStrategy.DirStrategyList.AddRange(strArray);
                _copyStrategy.DirStrategyList.Remove(string.Empty);
            }

            str = this.txtStrStrategy.Text.Trim();
            strArray = str.Split('#');
            if (strArray != null && strArray.Length > 0)
            {
                _copyStrategy.StrStrategyList.AddRange(strArray);
                _copyStrategy.StrStrategyList.Remove(string.Empty);
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private string GetCombainStr(List<string> strArray)
        {
            string rlt = string.Empty;
            if (strArray != null)
            {
                for (int i = 0; i < strArray.Count; i++)
                {
                    if (i == 0)
                    {
                        rlt += strArray[i];
                    }
                    else
                    {
                        rlt += "#" + strArray[i];
                    }
                }
            }
            return rlt;
        }

       
    }
}
