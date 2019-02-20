using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetWebFromHandler
{
    public partial class Transfer_test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("我是02 Transfer 后台页面 Begin</br>");
            Server.Transfer("Execute和Transfer执行循序.aspx");
            Response.Write("我是02 Transfer 后台页面 End</br>");
        }
    }
}