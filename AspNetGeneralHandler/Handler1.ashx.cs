using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AspNetGeneralHandler
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            DataTable dt=DbHelperSQL.GetDataTable("select top 10 * from TblClass");
            
            context.Response.ContentType = "text/html";
            context.Response.Write("<html>");
            context.Response.Write("<head>");
            context.Response.Write("<title>我爱广州小蛮腰~小蛮腰上太阳伤~~！</title>");
            context.Response.Write("</head>");
            context.Response.Write("<body>");
            context.Response.Write("<table>");

            DataRow dr = null;
            //遍历表格行 生成 html表格 行
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                context.Response.Write("<tr>");
                context.Response.Write("<td>"+dr["clsname"]+"</td>");
                context.Response.Write("<td>"+dr["clsdesc"]+"</td>");;
                context.Response.Write("</tr>");
            }

            context.Response.Write("</table>");
            context.Response.Write("</body>");
            context.Response.Write("</html>");
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