using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace AspNetGeneralHandler
{
    /// <summary>
    /// ModifyHandler 的摘要说明
    /// </summary>
    public class ModifyHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            if (context.Request.HttpMethod=="GET")
            {
                context.Response.ContentType = "text/html";
                string id = context.Request.QueryString["id"];
                DataTable dt = DbHelperSQL.GetDataTable("select * from TblClass where classid=@id", new SqlParameter("@id", id));
                DataRow dr = null;
                StringBuilder sbHtml = new StringBuilder();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];
                    sbHtml.Append("<td><input type='text' name='classid' value='" + dr["classid"] + "'></input></td>");
                    sbHtml.Append("<td><input type='text' name='clsname' value='" + dr["clsname"] + "'></input></td>");
                    sbHtml.Append("<td><input type='text' name='clsdesc' value='" + dr["clsdesc"] + "'></td>");
                    sbHtml.Append("<td><input type='submit' value='修改'></input></td>");
                }
                string PhyPath = context.Request.MapPath("ModifyPage.html");
                string html = PageHelper.ReadFile(PhyPath);
                html = html.Replace("{@trs}", sbHtml.ToString());
                context.Response.Write(html); 
            }
            if (context.Request.HttpMethod == "POST")
            {
                context.Response.ContentType = "text/html";
                NameValueCollection from = context.Request.Form;
                string classid = from.Get("classid");
                string clsname= from.Get("clsname");
                string clsdesc = from.Get("clsdesc");
                DataTable dt = DbHelperSQL.GetDataTable("update TblClass set clsname=@name,clsdesc=@desc where classid=@id", new SqlParameter[]{
                    new SqlParameter("@id",classid),
                    new SqlParameter("@name",clsname),
                    new SqlParameter("@desc",clsdesc)
                });
                DataRow dr = null;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr= dt.Rows[i];
                    context.Response.Write(dr[0].ToString()+"\r\n");
                    context.Response.Write(dr[1].ToString());
                }
            }
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