using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleIIS
{
    public class PageProcessFactory
    {
        #region 1.0 根据请求的文件后缀， 返回一个 页面处理类 对象 +IHttpHandler GetPageProcessInstance(HttpReqeust request)
        /// <summary>
        /// 根据请求的文件后缀， 返回一个 页面处理类 对象
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static IHttpHandler GetPageProcessInstance(HttpReqeust request)
        {
            IHttpHandler handler = null;
            //根据请求的文件后缀
            switch (request.UrlExtention)
            {
                case ".jpg":
                case ".gif":
                case ".png":
                case".mp3":
                    handler = new HttpProcessImg();//处理图片的 处理程序
                    break;
                case ".aspx":
                case ".jsp":
                case ".php":
                case ".gzitcast":
                    handler = new HttpProcessDyn();//处理动态 页面的 处理程序
                    break;
                case ".html":
                case ".htm":
                case ".css":
                case ".js":
                case".txt":
                    handler = new HttpProcessStatic();//处理静态页面的处理程序
                    break;
            }
            return handler;
        } 
        #endregion
    }
}
