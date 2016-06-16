using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Leation.VSAddin
{
    /// <summary>
    /// 写日志的实用类
    /// </summary>
    public static class LogoUtility
    {
        /// <summary>
        /// 写windows日志
        /// </summary>
        /// <param name="src">错误源</param>
        /// <param name="msg">错误信息</param>
        public static void Log(string src, string msg)
        {
            EventLog.WriteEntry(src, msg, EventLogEntryType.Error);
        }
    }
}
