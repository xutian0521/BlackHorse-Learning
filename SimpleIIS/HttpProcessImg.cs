using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleIIS
{
    public class HttpProcessImg:IHttpHandler
    {
        public void ProcessReqeust(HttpContext context)
        {
            //获取请求 图片的 物理路径
            string phyPath = context.Server.MapPath(context.Request.Url);
            //先检查 浏览器请求的 图片 是否存在，如果不存在 则抛出 404错误
            if (!System.IO.File.Exists(phyPath))
            {
                throw new Http404Exception();
            }
            else//如果存在，就读取图片，并直接设置给 Response的Content
            {
                //读取文件内容
                context.Response.Content = System.IO.File.ReadAllBytes(phyPath);
            }
        }
    }
}
