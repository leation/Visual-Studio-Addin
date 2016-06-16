using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Leation.VSAddin
{
    /// <summary>
    /// 自定义的目录对象
    /// </summary>
    public class DirectoryModel
    {
        private string _directoryPath = string.Empty;
        /// <summary>
        /// 当前目录的路径
        /// </summary>
        public string DirectoryPath
        {
            get
            {
                return _directoryPath;
            }
            set
            {
                _directoryPath = value;
            }
        }

        private string _directoryName = string.Empty;
        public string DirectoryName
        {
            get
            {
                if (_directoryName == string.Empty)
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(_directoryPath);
                    _directoryName = dirInfo.Name;
                }
                return _directoryName;
            }
        }

        private List<string> _files = new List<string>();
        /// <summary>
        /// 当前文件夹下的文件
        /// </summary>
        public List<string> Files
        {
            get
            {
                return _files;
            }
            set
            {
                _files = value;
            }
        }

        private List<DirectoryModel> _directoryList = new List<DirectoryModel>();
        /// <summary>
        /// 当前文件夹下的子文件夹
        /// </summary>
        public List<DirectoryModel> DirectoryList
        {
            get
            {
                return _directoryList;
            }
            set
            {
                _directoryList = value;
            }
        }

        public List<string> GetFilesByExtension(string extension)
        {
            List<string> rlts = new List<string>();
            for (int i = 0; i < _files.Count; i++)
            {
                string ex = Path.GetExtension(_files[i]);
                if (ex.Equals(extension, StringComparison.CurrentCultureIgnoreCase))
                {
                    rlts.Add(_files[i]);
                }
            }
            return rlts;
        }

        public List<string> GetFilesByExtension(string[] extensions)
        {
            List<string> rlts = new List<string>();
            if (extensions != null && extensions.Length > 0)
            {
                for (int i = 0; i < _files.Count; i++)
                {
                    string ex = Path.GetExtension(_files[i]);
                    for (int j = 0; j < extensions.Length; j++)
                    {
                        if (ex.Equals(extensions[j], StringComparison.CurrentCultureIgnoreCase))
                        {
                            rlts.Add(_files[i]);
                            break;
                        }
                    }
                }
            }
            return rlts;
        }

        public List<string> GetFilesByFilter(string filter)
        {
            List<string> rlts = new List<string>();
            for (int i = 0; i < _files.Count; i++)
            {
                if (_files[i].Contains(filter))
                {
                    rlts.Add(_files[i]);
                }
            }
            return rlts;
        }

        public List<string> GetFilesByFilter(string[] filters)
        {
            List<string> rlts = new List<string>();
            if (filters != null && filters.Length > 0)
            {
                for (int i = 0; i < _files.Count; i++)
                {
                    for (int j = 0; j < filters.Length; j++)
                    {
                        if (_files[i].Contains(filters[j]))
                        {
                            rlts.Add(_files[i]);
                            break;
                        }
                    }
                }
            }
            return rlts;
        }

        public List<DirectoryModel> GetDirectoriesByNotEqual(string dirName)
        {
            List<DirectoryModel> rlts = new List<DirectoryModel>();
            for (int i = 0; i < _directoryList.Count; i++)
            {
                if (_directoryList[i].DirectoryName.Equals(dirName, StringComparison.CurrentCultureIgnoreCase) == false)
                {
                    rlts.Add(_directoryList[i]);
                }
            }
            return rlts;
        }

        public List<DirectoryModel> GetDirectoriesByEqual(string dirName)
        {
            List<DirectoryModel> rlts = new List<DirectoryModel>();
            for (int i = 0; i < _directoryList.Count; i++)
            {
                if (_directoryList[i].DirectoryName.Equals(dirName, StringComparison.CurrentCultureIgnoreCase))
                {
                    rlts.Add(_directoryList[i]);
                }
            }
            return rlts;
        }

        public List<DirectoryModel> GetDirectoriesByNotEqual(string[] dirNames)
        {
            List<DirectoryModel> rlts = new List<DirectoryModel>();
            if (dirNames != null && dirNames.Length > 0)
            {
                for (int i = 0; i < _directoryList.Count; i++)
                {
                    bool isEqual = false;
                    for (int j = 0; j < dirNames.Length; j++)
                    {
                        if (_directoryList[i].DirectoryName.Equals(dirNames[j], StringComparison.CurrentCultureIgnoreCase))
                        {
                            isEqual = true;
                            break;
                        }
                    }
                    if (isEqual == false)
                    {
                        rlts.Add(_directoryList[i]);
                    }
                }
            }
            return rlts;
        }

        public List<DirectoryModel> GetDirectoriesByEqual(string[] dirNames)
        {
            List<DirectoryModel> rlts = new List<DirectoryModel>();
            if (dirNames != null && dirNames.Length > 0)
            {
                for (int i = 0; i < _directoryList.Count; i++)
                {
                    for (int j = 0; j < dirNames.Length; j++)
                    {
                        if (_directoryList[i].DirectoryName.Equals(dirNames[j], StringComparison.CurrentCultureIgnoreCase))
                        {
                            rlts.Add(_directoryList[i]);
                            break;
                        }
                    }
                }
            }
            return rlts;
        }

        public DirectoryModel()
        {
        }

        public DirectoryModel(string directoryPath)
        {
            _directoryPath = directoryPath;
        }

    }
}
