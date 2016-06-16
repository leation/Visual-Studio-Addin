using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace Leation.VSAddin
{
    public class SaveText2Notepad
    {
        public static string SaveContext(List<string> contexts, bool open)
        {
            string tempPath = Path.Combine(Path.GetTempPath(), "Leation.VSAddin.Temp.txt");
            File.WriteAllLines(tempPath,contexts.ToArray(),Encoding.UTF8);
            if (open)
            {
                Process.Start(tempPath);
            }
            return tempPath;
        }

        public static string SaveContext(string context, bool open)
        {
            string tempPath = Path.Combine(Path.GetTempPath(), "Leation.VSAddin.Temp.txt");
            File.WriteAllText(tempPath, context, Encoding.UTF8);
            if (open)
            {
                Process.Start(tempPath);
            }
            return tempPath;
        }
    }
}
