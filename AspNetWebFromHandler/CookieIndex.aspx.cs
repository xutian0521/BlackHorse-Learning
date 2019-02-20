using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetWebFromHandler
{
    public partial class CookieIndex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["cname"];
            if (cookie != null)
            {
                Response.Write("欢迎！(Cookie)：" + cookie.Value);
            }
            else
            {
                Response.Write("<script>alert('你还没i月登录！！~');window.location='CookieLogin.aspx'</script>");
                Response.End();
            }
        }
    }
}