using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleIIS
{
    public class HttpProcessDyn:IHttpHandler
    {
        public void ProcessReqeust(HttpContext context)
        {
            //url: /index.aspx
            //1.获取请求页面的 对应的 类名
            string strClassName = System.IO.Path.GetFileNameWithoutExtension(context.Request.Url);
            string strFullClassName = "SimpleIIS.Pages." + strClassName;
            //2.反射创建页面类对象
            Type tPage = this.GetType().Assembly.GetType(strFullClassName);
            //3.创建页面类对象
            IHttpHandler handler = Activator.CreateInstance(tPage) as IHttpHandler;
            //4.将 页面对象 存入 上下文中
            context.MapHandler = handler;
        }
    }
}
