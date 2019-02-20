using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AspNetGeneralHandler
{
    /// <summary>
    /// Handler2 的摘要说明
    /// </summary>
    public class Handler2 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
           
            //1.找到 列表模版 的物理路径
             //MapPath 把虚拟路径转换成物理路径
            string strPhyPath = context.Request.MapPath("Handler2.html");
            //2.读取列表模版页面内容(html -带占位符) 
            string html = PageHelper.ReadFile(strPhyPath);

            //3.读取数据库 获取班级表数据前10行
            DataTable dt = DbHelperSQL.GetDataTable("select top 10 * from TblClass where isdel=1");
            //4.便利表格行 生成HTML 表格 行
            System.Text.StringBuilder sbHtml = new System.Text.StringBuilder();
            DataRow dr = null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                sbHtml.Append("<tr>");
                sbHtml.Append("<td>"+dr["classid"]+"</td>");
                sbHtml.Append("<td>" + dr["clsname"] + "</td>");

                sbHtml.Append("<td><a href='javascript:void()' onclick=dodel(" + dr["classid"] + ")>删除</a>");
                sbHtml.Append("<a href='Desc.ashx?cid="+dr["classid"]+"'>查看</a></td>");
                sbHtml.Append("<td><a href='ModifyHandler.ashx?id="+dr["classid"]+"' onclick=modify()>修改</a></td>");
                sbHtml.Append("</tr>");
            }
            //5.将根据数据库生成的tr标签字符串，替换 到模版字符串中的占位符 处，并且接收被替换之后的 新模版 字符串
            html= html.Replace("{@trs}", sbHtml.ToString());
            //6.保存到response中
            context.Response.Write(html);
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