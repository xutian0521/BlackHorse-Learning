using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetWebFromHandler
{
    public partial class CookieLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod.ToLower()=="post")
            {
                string strN = Request.Form["txtN"];
                string strP = Request.Form["txtP"];
                //登录成功
                if (strN == "admin" && strP == "123")
                {
                    HttpCookie cookie = new HttpCookie("cname", strN);
                    //设置Cookie的有效时间 如果没有设置默认为缓存Cookie
                    cookie.Expires = DateTime.Now.AddMinutes(2);
                    //如 设置Cookie路径  则 用户访问该文件夹下的所以页面 Cookie才有效
                    //cookie.Path = "admin";
                    Response.Cookies.Add(cookie);
                    Response.Write("<script type='text/javascript'>window.location='CookieIndex.aspx'</script>");
                    //或者让浏览器重定向 到首页
                    //Response.Redirect("CookieIndex.aspx");
                } 
            }
        }
    }
}