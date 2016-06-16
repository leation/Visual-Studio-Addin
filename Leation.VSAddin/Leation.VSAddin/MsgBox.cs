using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Leation.VSAddin
{
    /// <summary>
    /// 提供统一风格的MessageBox对话框
    /// </summary>
    internal static class MsgBox
    {
        private static readonly string Caption = "李仙伟的VS扩展插件";

        /// <summary>
        /// 显示错误信息
        /// </summary>
        /// <param name="msg">错误信息</param>
        public static void ShowTip(string msg)
        {
            MessageBox.Show(msg, Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 显示OkCancel对话框
        /// </summary>
        /// <param name="msg">提示信息</param>
        public static DialogResult ShowOkCancel(string msg)
        {
            return MessageBox.Show(msg, Caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }

    }
}
