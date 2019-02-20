using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;

namespace AspNetGeneralHandler
{
    public class DelClass : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string id = context.Request.QueryString["cid"];
            //软删除
            DataTable dt = DbHelperSQL.GetDataTable("update TblClass set isdel=0  where classid=@id", new SqlParameter("@id", id));
            DataRow dr = null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                context.Response.Write(dr["clsname"].ToString());
            }
            context.Response.Write("<script type='text/javascript'>alert('删除成功！');window.location='http://localhost:22349/handler2.ashx'</script>");
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