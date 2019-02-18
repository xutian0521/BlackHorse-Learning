using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleIIS
{
    public class HttpServerUtility
    {
        private static string webPath;
        public static string WebPath
        {
            get { return HttpServerUtility.webPath; }
            set { HttpServerUtility.webPath = value; }
        }

        #region 1.0 根据 页面相对路径 生成 在 服务器的物理路径
        /// <summary>
        /// 根据 页面相对路径 生成 在 服务器的物理路径
        /// </summary>
        /// <param name="strRelativePath"></param>
        /// <returns></returns>
        public string MapPath(string strRelativePath)
        {
            return webPath + "/" + strRelativePath;
        } 
        #endregion
    }
}
