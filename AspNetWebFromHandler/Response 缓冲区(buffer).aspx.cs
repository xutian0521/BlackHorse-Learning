using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetWebFromHandler
{
    public partial class Response_缓存_buffer_ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //关闭缓冲区  可以实现 不停的像网页中写内容
            //Response.BufferOutput = false;

            //默认开启 缓冲区   开启缓冲区用另外一种方法也可以
            //Flush() 立即输出response缓冲区里的内容
            Response.BufferOutput = true;
            int i;
            for (i = 0; i < 10; i++)
            {
                
                Thread.Sleep(200);
                Response.Write(i+"哈哈~~！</br>");
                Response.Flush();
                if (i == 5)
                {
                    
                    Response.End();
                }

            }
        }
    }
}