using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetWebFromHandler
{
    public partial class Execute和Transfer执行循序 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(" 我 我SExecute 的后台  页面 Begin</br>");
            //Server.Execute("Transfer test.aspx");
            Response.Write(" 我 我SExecute 的后台  页面 End</br>");
        }
    }
}