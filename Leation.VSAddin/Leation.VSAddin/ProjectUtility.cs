using System;
using System.Collections.Generic;
using System.Text;
using EnvDTE80;
using EnvDTE;
using VSLangProj;

namespace Leation.VSAddin
{
    public static class ProjectUtility
    {
        /// <summary>
        /// 获取所有的项目
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static List<Project> GetAllProjects(DTE2 app)
        {
            List<Project> pros = new List<Project>();
            if (app.Solution != null)
            {
                Solution sol = app.Solution;
                if (sol.Projects != null && sol.Projects.Count > 0)
                {
                    foreach (Project topProj in sol.Projects)
                    {
                        GetAllChildProjects(topProj, ref pros);
                    }
                }
            }
            //剔除pros[i].Object不是VSProject的特殊项目
            for (int i = 0; i < pros.Count; i++)
            {
                VSProject vsProj = pros[i].Object as VSProject;
                if (vsProj == null)
                {
                    pros.RemoveAt(i);
                    i--;
                }
            }
            //按照项目名称进行排序
            List<string> nameList = new List<string>();
            for (int i = 0; i < pros.Count; i++)
            {
                nameList.Add(pros[i].Name);
            }
            nameList.Sort();
            List<Project> rlt = new List<Project>();
            for (int i = 0; i < nameList.Count; i++)
            {
                for (int j = 0; j < pros.Count; j++)
                {
                    if (pros[j].Name == nameList[i])
                    {
                        rlt.Add(pros[j]);
                        break;
                    }
                }
            }
            return rlt;
        }

        /// <summary>
        /// 迭代法获取所有项目
        /// </summary>
        /// <param name="topProj"></param>
        /// <param name="pros"></param>
        private static void GetAllChildProjects(Project topProj, ref List<Project> pros)
        {
            //顶级项目
            if (topProj != null && topProj.Kind != ProjectKinds.vsProjectKindSolutionFolder)
            {
                pros.Add(topProj);
            }
            else if (topProj != null && topProj.Kind == ProjectKinds.vsProjectKindSolutionFolder)
            {
                //非顶级项目
                if (topProj.ProjectItems != null && topProj.ProjectItems.Count > 0)
                {
                    for (int i = 1; i <= topProj.ProjectItems.Count; i++)
                    {
                        ProjectItem proItem = topProj.ProjectItems.Item(i);
                        Project subPro = proItem.Object as Project;
                        if (subPro != null)
                        {
                            GetAllChildProjects(subPro, ref pros);
                        }
                    }
                }
            }
        }

        public static void GetConfigrationKeys(DTE2 app)
        {
            List<Project> pros = GetAllProjects(app);
            if (pros != null && pros.Count > 0)
            {
                for (int i = 0; i < pros.Count; i++)
                {
                    Configuration config = pros[i].ConfigurationManager.ActiveConfiguration;
                    List<string> keyValueStrList = new List<string>();
                    keyValueStrList.Add("ConfigurationName:  " + config.ConfigurationName);
                    foreach (Property pro in config.Properties)
                    {
                        string proName = pro.Name;
                        string value = pro.Value.ToString();
                        keyValueStrList.Add(proName + ":     " + value);
                    }
                    SaveText2Notepad.SaveContext(keyValueStrList, true);
                }
            }
        }

        public static void GetProjecttKeys(DTE2 app)
        {
            List<Project> pros = GetAllProjects(app);
            if (pros != null && pros.Count > 0)
            {
                for (int i = 0; i < pros.Count; i++)
                {
                    List<string> keyValueStrList = new List<string>();
                    keyValueStrList.Add("ProjectName:  " + pros[i].Name);
                    foreach (Property pro in pros[i].Properties)
                    {
                        try
                        {
                            string proName = pro.Name;
                            string value = pro.Value.ToString();
                            keyValueStrList.Add(proName + ":     " + value);
                        }
                        catch
                        {
                        }
                    }
                    SaveText2Notepad.SaveContext(keyValueStrList, true);
                }
            }
        }
       
    }
}
