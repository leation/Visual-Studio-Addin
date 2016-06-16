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
    public partial class SQLCreatorUI : UserControl
    {
        public SQLCreatorUI()
        {
            InitializeComponent();

            this.combSQLType.SelectedIndex = 0;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string[] context = this.txtStringArray.Lines;
            if (context == null || context.Length < 1)
            {
                MsgBox.ShowTip("请先输入字符串数组,每个字符串占一行");
                return;
            }
            if (this.combSQLType.SelectedItem==null)
            {
                MsgBox.ShowTip("请选择SQL类型");
                return;
            }
            List<string> tempList = new List<string>();
            for (int i = 0; i < context.Length; i++)
            {
                if (string.IsNullOrEmpty(context[i].Trim()) == false)
                {
                    tempList.Add(context[i].Trim());
                }
            }
            if (tempList.Count < 1)
            {
                return;
            }
            context = tempList.ToArray();
            
            string rlt = string.Empty;
            string sqlType = this.combSQLType.SelectedItem.ToString().Trim('用','分','割');
            switch (sqlType)
            {
                case ",":
                    for (int i = 0; i < context.Length; i++)
                    {
                        if (i == 0)
                        {
                            rlt += context[i].Trim().Trim();
                        }
                        else
                        {
                            rlt += "," + context[i].Trim();
                        }
                    }
                    break;
                case "',":
                    for (int i = 0; i < context.Length; i++)
                    {
                        if (i == 0)
                        {
                            rlt += "'" + context[i].Trim()+"'";
                        }
                        else
                        {
                            rlt += ",'" + context[i].Trim() + "'";
                        }
                    }
                    break;
                case "\",":
                    for (int i = 0; i < context.Length; i++)
                    {
                        if (i == 0)
                        {
                            rlt += "\"" + context[i].Trim() + "\"";
                        }
                        else
                        {
                            rlt += ",\"" + context[i].Trim() + "\"";
                        }
                    }
                    break;
                case "delete from":
                    for (int i = 0; i < context.Length; i++)
                    {
                        if (string.IsNullOrEmpty(context[i].Trim()) == false)
                        {
                            rlt += "delete from " + context[i].Trim();
                            if (i != context.Length - 1)
                            {
                                rlt += "\ngo\n";
                            }
                            else
                            {
                                rlt += "\ngo";
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
            this.txtRlt.Text = rlt;
        }

        private void btnCreateStrArray_Click(object sender, EventArgs e)
        {
            string sqlType = this.combSQLType.SelectedItem.ToString();
            if (sqlType == "delete from")
            {
                this.txtStringArray.Clear();
                string context = this.txtRlt.Text;
                string[] splitChar = { "delete from","go"};
                string[] strArray = context.Split(splitChar, StringSplitOptions.None);
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (string.IsNullOrEmpty(strArray[i].Trim()) == false)
                    {
                        this.txtStringArray.AppendText(strArray[i].Trim());
                        if (i != strArray.Length - 1)
                        {
                            this.txtStringArray.AppendText("\n");
                        }
                    }
                }
            }
            else
            {
                this.txtStringArray.Clear();
                string context = this.txtRlt.Text;
                char[] splitChar = { '\'', '\"', ',', ';' };
                string[] strArray = context.Split(splitChar, StringSplitOptions.None);
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (string.IsNullOrEmpty(strArray[i].Trim()) == false)
                    {
                        this.txtStringArray.AppendText(strArray[i].Trim(splitChar));
                        if (i != strArray.Length - 1)
                        {
                            this.txtStringArray.AppendText("\n");
                        }
                    }
                }
            }
        }    
    }
}
