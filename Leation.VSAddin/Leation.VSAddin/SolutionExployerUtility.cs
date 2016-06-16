using System;
using System.Collections.Generic;
using System.Text;
using EnvDTE80;
using EnvDTE;
using VSLangProj;

namespace Leation.VSAddin
{
    public class SolutionExployerUtility
    {
        private DTE2 _app = null;
        private UIHierarchy _rootNode = null;

        public SolutionExployerUtility(DTE2 app)
        {
            _app = app;
            _rootNode = _app.ToolWindows.SolutionExplorer;
        }

        public void LoadAllProjectNodes()
        {
            string solutionName = _app.Solution.Properties.Item("Name").Value.ToString();
            UIHierarchyItems items = _rootNode.GetItem(solutionName).UIHierarchyItems;
            foreach (UIHierarchyItem topItem in items)
            {
                topItem.UIHierarchyItems.Expanded = true;
            }
        }

        public List<UIHierarchyItem> GetProjectNodes()
        {
            string solutionName = _app.Solution.Properties.Item("Name").Value.ToString();
            UIHierarchyItems topLevlItems = _rootNode.GetItem(solutionName).UIHierarchyItems;
            
            List<UIHierarchyItem> items = new List<UIHierarchyItem>();
            foreach (UIHierarchyItem topItem in topLevlItems)
            {
                if (IsProject(topItem))
                {
                    items.Add(topItem);
                }
                else if (IsSolutionFolder(topItem))
                {
                    this.GetProjectNodesInSolutionFolder(topItem,ref items);
                }
            }
            return items;
        }

        private void GetProjectNodesInSolutionFolder(UIHierarchyItem topLevelItem, ref List<UIHierarchyItem> projNodes)
        {
            if (IsSolutionFolder(topLevelItem))
            {
                foreach (UIHierarchyItem subItem in topLevelItem.UIHierarchyItems)
                {
                    if (IsProject(subItem))
                    {
                        projNodes.Add(subItem);
                    }
                    else
                    {
                        this.GetProjectNodesInSolutionFolder(subItem, ref projNodes);
                    }
                }
            }
        }

        /// <summary>
        /// 判断节点是否为解决方案目录
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool IsSolutionFolder(UIHierarchyItem item)
        {
            bool isFolder = false;

            //解决方案目录为顶级
            Project proj = item.Object as Project;
            if (proj != null && proj.Kind == ProjectKinds.vsProjectKindSolutionFolder)
            {
                isFolder = true;
            }
            else if (proj == null)
            {
                //解决方案目录不是顶级目录
                ProjectItem projItem = item.Object as ProjectItem;
                if (projItem != null)
                {
                    proj = projItem.Object as Project;
                    if(proj!=null && proj.Kind == ProjectKinds.vsProjectKindSolutionFolder)
                    {
                        isFolder=true;
                    }
                }
            }
            return isFolder;
        }

        /// <summary>
        /// 判断结点是否为项目
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool IsProject(UIHierarchyItem item)
        {
            bool isProject = false;

            //结点为顶级项目
            Project proj = item.Object as Project;
            if (proj != null && proj.Kind != ProjectKinds.vsProjectKindSolutionFolder)
            {
                isProject = true;
            }
            else if (proj == null)
            {
                //结点为非顶级项目，即项目父节点为解决方案目录
                ProjectItem proItem = item.Object as ProjectItem;
                if (proItem != null)
                {
                    Project subPro = proItem.Object as Project;
                    if (subPro != null && subPro.Kind != ProjectKinds.vsProjectKindSolutionFolder)
                    {
                        isProject = true;
                    }
                }
            }
            return isProject;
        }

        /// <summary>
        /// 折叠全部
        /// </summary>
        public void CollapseAll()
        {
            List<UIHierarchyItem> itemNodes = this.GetProjectNodes();
            if (itemNodes != null && itemNodes.Count > 0)
            {
                for (int i = 0; i < itemNodes.Count; i++)
                {
                    Project proj = itemNodes[i].Object as Project;
                    //项目为非顶级项目
                    if (proj == null)
                    {
                        ProjectItem projItem = itemNodes[i].Object as ProjectItem;
                        if (projItem != null && itemNodes[i].UIHierarchyItems.Expanded)
                        {

                            itemNodes[i].Select(vsUISelectionType.vsUISelectionTypeSelect);
                            _rootNode.DoDefaultAction();
                        }
                    }
                    else
                    {
                        //项目为顶级项目
                        itemNodes[i].UIHierarchyItems.Expanded = false;
                    }

                }
            }
            //折叠顶级项目
            string solutionName = _app.Solution.Properties.Item("Name").Value.ToString();
            UIHierarchyItems items = _rootNode.GetItem(solutionName).UIHierarchyItems;
            foreach (UIHierarchyItem topItem in items)
            {
                topItem.UIHierarchyItems.Expanded = false;
            }
        }

        /// <summary>
        /// 展开全部
        /// </summary>
        public void ExpandAll()
        {
            //加载所有的项目
            this.LoadAllProjectNodes();

            List<UIHierarchyItem> itemNodes = this.GetProjectNodes();
            if (itemNodes != null && itemNodes.Count > 0)
            {
                for (int i = 0; i < itemNodes.Count; i++)
                {
                    Project proj = itemNodes[i].Object as Project;
                    //项目为非顶级项目
                    if (proj == null)
                    {
                        ProjectItem projItem = itemNodes[i].Object as ProjectItem;
                        if (projItem != null && itemNodes[i].UIHierarchyItems.Expanded == false)
                        {
                            itemNodes[i].Select(vsUISelectionType.vsUISelectionTypeSelect);
                            _rootNode.DoDefaultAction();
                        }
                    }
                    else
                    {
                        //项目为顶级项目
                        itemNodes[i].UIHierarchyItems.Expanded = true;
                    }
                }
            }
        }

        /// <summary>
        /// 通过读取SolutionExplorer的UIHierarchyItems也可以得到所有的Project
        /// </summary>
        /// <param name="app"></param>
        public List<Project> GetAllProject()
        {
            List<Project> projs = new List<Project>();

            this.LoadAllProjectNodes();

            List<UIHierarchyItem> itemNodes = this.GetProjectNodes();
            if (itemNodes != null && itemNodes.Count > 0)
            {
                for (int i = 0; i < itemNodes.Count; i++)
                {
                    Project proj = itemNodes[i].Object as Project;
                    if (proj == null)
                    {
                        ProjectItem projItem = itemNodes[i].Object as ProjectItem;
                        if (projItem != null)
                        {
                            proj = projItem.Object as Project;
                        }
                        if (proj == null)
                        {
                            continue;
                        }
                    }
                    projs.Add(proj);
                }
            }
            this.CollapseAll();

            //剔除projs[i].Object不是VSProject的特殊项目
            for (int i = 0; i < projs.Count; i++)
            {
                VSProject vsProj = projs[i].Object as VSProject;
                if (vsProj == null)
                {
                    projs.RemoveAt(i);
                    i--;
                }
            }

            return projs;
        }
    }
}
