using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Leation.VSAddin
{
    public static class FileDirUtility
    {
        public static DirectoryModel ReadAllDirAndFiles(string rootDir)
        {
            DirectoryModel rlt = new DirectoryModel(rootDir);

            GetAllFilesAndDirs(ref rlt);

            return rlt;
        }

        private static void GetAllFilesAndDirs(ref DirectoryModel dirModel)
        {
            if (dirModel.DirectoryName == ".svn")
            {
                return;
            }
            string[] files = GetFiles(dirModel.DirectoryPath);
            if (files != null && files.Length > 0)
            {
                dirModel.Files.AddRange(files);
            }
            string[] subDirs = GetSubDirs(dirModel.DirectoryPath);
            if (subDirs != null)
            {
                for (int i = 0; i < subDirs.Length; i++)
                {
                    if (subDirs[i].EndsWith(".svn"))
                    {
                        continue;
                    }
                    DirectoryModel model = new DirectoryModel(subDirs[i]);
                    dirModel.DirectoryList.Add(model);

                    GetAllFilesAndDirs(ref model);
                }
            }
        }

        private static string[] GetFiles(string dir)
        {
            string[] files = Directory.GetFiles(dir);
            return files;
        }

        private static string[] GetSubDirs(string dir)
        {
            string[] dirs = Directory.GetDirectories(dir);
            return dirs;
        }
    }
}
