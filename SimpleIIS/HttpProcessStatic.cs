using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleIIS
{
    /// <summary>
    /// 处理静态页面
    /// </summary>
    public class HttpProcessStatic:IHttpHandler
    {
        #region 1.0 处理静态文件的处理 +void ProcessReqeust(HttpContext context)
        /// <summary>
        /// 处理静态文件的处理
        /// </summary>
        /// <param name="context"></param>
        public void ProcessReqeust(HttpContext context)
        {
            //获取请求 文件的 物理路径
            string phyPath = context.Server.MapPath(context.Request.Url);
            //先检查 浏览器请求的 静态文件 是否存在，如果不存在 则抛出 404错误
            if (!System.IO.File.Exists(phyPath))
            {
                throw new Http404Exception();
            }
            else//如果存在，就读取静态文件
            {
                //读取文件内容
                string fileContent = System.IO.File.ReadAllText(phyPath);
                //将内容 写入 响应报文对象
                context.Response.Write(fileContent);
            }
        } 
        #endregion
    }
}
