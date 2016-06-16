using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

namespace Leation.VSAddin
{
    public static class DllRefReflectUtility
    {
        /// <summary>
        /// 获取依赖的程序集名称，该方法采用Assembly.LoadFile(string path)方法，该方法最为简单，但是程序集加载后无法释放，dll文件一直被占用
        /// </summary>
        /// <param name="dllPath">dll路径</param>
        /// <returns></returns>
        public static List<string> GetRefDllsOld(string dllPath)
        {
            List<string> rlts = new List<string>();

            Assembly ass = Assembly.LoadFile(dllPath);
            AssemblyName[] refAss = ass.GetReferencedAssemblies();
            if (refAss != null)
            {
                for (int i = 0; i < refAss.Length; i++)
                {
                    string dllName = refAss[i].Name;
                    rlts.Add(dllName);
                }
            }
            return rlts;
        }

        /// <summary>
        /// 获取依赖的程序集名称,，该方法采用Assembly.Load(byte[] rawAssembly)方法，该方法解决了dll文件被占用的问题，但是依然没有释放资源，会导致visual studio内存极速增加，直到接近100%
        /// </summary>
        /// <param name="dllPath">dll路径</param>
        /// <returns></returns>
        public static List<string> GetRefDllsPlus(string dllPath)
        {
            List<string> rlts = new List<string>();

            try
            {
                byte[] bs = File.ReadAllBytes(dllPath);
                Assembly ass = Assembly.Load(bs);
                AssemblyName[] refAss = ass.GetReferencedAssemblies();
                if (refAss != null)
                {
                    for (int i = 0; i < refAss.Length; i++)
                    {
                        string dllName = refAss[i].Name;
                        rlts.Add(dllName);
                    }
                }
                bs = null;
                refAss = null;
                ass = null;
            }
            catch (Exception ex)
            {
                LogoUtility.Log("Leation.VSAddin.GetRefDllsPlus", ex.Message);
            }
            return rlts;
        }

        //临时存放dll的根目录
        private static string TempDir = Path.Combine(Path.GetTempPath(), "LeationVSAdinns");
        /// <summary>
        /// 临时存放dll的子目录(GUID)
        /// </summary>
        public static string SubDirGuid = Guid.NewGuid().ToString();

        /// <summary>
        /// 获取依赖的程序集名称,该方法采用Assembly.LoadFile(string path)方法，该方法虽然没有解决dll文件被占用和资源释放的问题，但是通过拷贝文件到临时目录，间接地解决了内存不断极速增加的问题。
        /// </summary>
        /// <param name="dllPath">dll路径</param>
        /// <returns></returns>
        public static List<string> GetRefDlls(string dllPath)
        {
            List<string> rlts = new List<string>();
            try
            {
                string tempDllDir = Path.Combine(TempDir, SubDirGuid);
                if (Directory.Exists(tempDllDir) == false)
                {
                    Directory.CreateDirectory(tempDllDir);
                }
                string tempDllPath = Path.Combine(tempDllDir, Path.GetFileName(dllPath));
                if (File.Exists(tempDllPath) == false)
                {
                    File.Copy(dllPath, tempDllPath);
                }
                Assembly ass = Assembly.LoadFile(tempDllPath);
                AssemblyName[] refAss = ass.GetReferencedAssemblies();
                if (refAss != null)
                {
                    for (int i = 0; i < refAss.Length; i++)
                    {
                        string dllName = refAss[i].Name;
                        rlts.Add(dllName);
                    }
                }
            }
            catch (Exception ex)
            {
                LogoUtility.Log("Leation.VSAddin.GetRefDlls", ex.Message);
            }
            return rlts;
        }

        /// <summary>
        /// 清理临时文件
        /// </summary>
        public static void ClearTempFiles()
        {
            if (Directory.Exists(TempDir) == false)
            {
                return;
            }
            string[] dirs = Directory.GetDirectories(TempDir);
            if (dirs == null || dirs.Length < 1)
            {
                return;
            }
            for (int i = 0; i < dirs.Length; i++)
            {
                try
                {
                    Directory.Delete(dirs[i],true);
                }
                catch
                {
                }
            }
        }
    }
}
