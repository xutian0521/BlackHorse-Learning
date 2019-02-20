using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetGeneralHandler
{
    /// <summary>
    /// 强制另存为 的摘要说明
    /// </summary>
    public class 强制另存为 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //浏览器地址输入 http://localhost:22349/强制另存为.ashx?n=images/1.jpg 可强制下载


            //1.获取要下载的文件路径
            string strFilePath = context.Request.QueryString["n"];
            //2.转成物理路径
            strFilePath = context.Request.MapPath(strFilePath);

            //关键 添加一个相应头
            context.Response.AddHeader("Content-Disposition", "attachment;filename-gzitcast.jpg");

            //3.将文件读取并输出给浏览器
            context.Response.WriteFile(strFilePath);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}