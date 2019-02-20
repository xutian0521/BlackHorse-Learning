using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetWebFromHandler
{

    public partial class WebForm1 : System.Web.UI.Page
    {
        public System.Text.StringBuilder sbHtml = new System.Text.StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            string strPhyPath = Request.MapPath("Handler2.html"); 

            //3.读取数据库 获取班级表数据前10行
            DataTable dt = DbHelperSQL.GetDataTable("select top 10 * from TblClass where isdel=1");
            //4.便利表格行 生成HTML 表格 行
            
            DataRow dr = null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                sbHtml.Append("<tr>");
                sbHtml.Append("<td>" + dr["classid"] + "</td>");
                sbHtml.Append("<td>" + dr["clsname"] + "</td>");

                sbHtml.Append("<td><a href='javascript:void()' onclick=dodel(" + dr["classid"] + ")>删除</a>");
                sbHtml.Append("<a href='Desc.ashx?cid=" + dr["classid"] + "'>查看</a></td>");
                sbHtml.Append("<td><a href='ModifyHandler.ashx?id=" + dr["classid"] + "' onclick=modify()>修改</a></td>");
                sbHtml.Append("</tr>");
            }

        }
    }
}