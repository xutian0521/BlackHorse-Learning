using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetWebFromHandler
{
    public partial class SessionLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //判断是否post请求
            if (Request.HttpMethod.ToLower() == "post")
            {
                string strN = Request.Form["txtN"];
                string strP = Request.Form["txtP"];
                //登陆成功
                if (strN == "admin" && strP == "123")
                {
                    //将用户名存入 session 中
                    //Context.Session 上下文中的session

                    Session.Add("cname", strN);
                    //也可以用下面这种写法
                    //Session["cname"] = strN;

                    //让浏览器 重定向 到首页
                    Response.Redirect("SessionIndex.aspx");
                }
            }

        }
    }
}