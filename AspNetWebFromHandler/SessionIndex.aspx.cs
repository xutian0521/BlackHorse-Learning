using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetWebFromHandler
{
    public partial class SessionIndex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //如果 cname 不等于 null 且也不等于空字符串
            if (Session["cname"] != null&&!string.IsNullOrEmpty( Session["cname"].ToString()))
            {
                Response.Write("欢迎！(Session)：" + Session["cname"].ToString());
            }
            else
            {
                Response.Write("<script>alert('你还没i月登录！！~');window.location='SessionLogin.aspx'</script>");
                Response.End();
            }
        }
    }
}