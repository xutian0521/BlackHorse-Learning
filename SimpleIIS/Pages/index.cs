using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleIIS.Pages
{
    /// <summary>
    /// 首页 - 动态页面
    /// </summary>
    public class index:IHttpHandler
    {
        public void ProcessReqeust(HttpContext context)
        {
            context.Response.Write("<html>");
            context.Response.Write("<head>");
            context.Response.Write("<title>我爱广州小蛮腰~小蛮腰上太阳伤~~！</title>");
            context.Response.Write("</head>");
            context.Response.Write("<body>");
            context.Response.Write("<table>");
            for (int i = 0; i < 5; i++)
            {
                context.Response.Write("<tr>");
                context.Response.Write("<td>" + (i + 1 )+ "</td>");
                context.Response.Write("<td>" + i + "小蛮腰~~~！" + "</td>");
                context.Response.Write("</tr>");
            }
            context.Response.Write("</table>");
            context.Response.Write("</body>");
            context.Response.Write("</html>");
        }
    }
}
