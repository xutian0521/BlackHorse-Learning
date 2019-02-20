using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace AspNetGeneralHandler
{
    /// <summary>
    /// Desc 的摘要说明
    /// </summary>
    public class Desc : IHttpHandler
    {
        
        public void ProcessRequest(HttpContext context)
        {
            //从url中 获取cid参数
            string strClassId = context.Request.QueryString["cid"];
            context.Response.ContentType = "text/html";
            int id=0;
            if(!int.TryParse(strClassId,out id))
            {
                context.Response.Write("参数不正确~~！");
            }
            else
            {
                //1.根据id 去数据库查询 班级下的描述
                DataTable dt = DbHelperSQL.GetDataTable("select  * from TblClass where classid=@id",new SqlParameter("@id",strClassId));
                //2.遍历生成表格行
                DataRow dr = null;
                StringBuilder sbHtml = new StringBuilder();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];//取出第一行
                    sbHtml.Append("<tr>");
                    sbHtml.Append("<td>" + dr["classid"] + "</td>");
                    sbHtml.Append("<td>" + dr["clsname"] + "</td>");
                    sbHtml.Append("<td>" + dr["clsdesc"] + "</td>");
                    sbHtml.Append("</tr>");
                }
                //3.读取描述页面模版
                string html= PageHelper.ReadFile(context.Request.MapPath("Desc.html"));
                //4.替换模版里的占位符
                html= html.Replace("{@trs}", sbHtml.ToString());
                //5.保存到response中
                context.Response.Write(html);
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