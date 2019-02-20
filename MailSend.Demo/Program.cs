using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailSend.Demo
{
    class Program
    {
        /*SmtpClient 发送邮件 演示*/
        static void Main(string[] args)
        {
            #region  普通文本的
            ////1.MailMessage
            ////1.创建一封邮件
            //MailMessage msg = new MailMessage();
            //msg.From = new MailAddress("xutian0521@126.com");
            //msg.To.Add(new MailAddress("xutian0521@qq.com"));
            ////add这里设置添加要发送的 邮箱
            //msg.Subject = "生日快乐！";
            ////msg.Body = "猪你生日快乐 猪你生日快乐哈哈  哈哈哈！";
            //msg.SubjectEncoding = Encoding.GetEncoding("UTF-8");

            ////带HTML格式的邮件
            //msg.Body = "在上午<font color=\"red\"><h1>12:00</h1></font>之前把饭送过来";
            ////设置文本正文是否是HTML 格式的。
            //msg.IsBodyHtml = true;





            ////2.SmtpClient
            //SmtpClient smtp = new SmtpClient();
            //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //smtp.Host = "smtp.126.com";

            //smtp.Credentials = new NetworkCredential("xutian0521@126.com", "xt62628899");
            //smtp.Send(msg);
            //Console.WriteLine("发送完毕！");
            #endregion

            Console.ReadKey();
            #region  带图片和附件 的
            //1.MailMessage
            //1.创建一封邮件
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("xutian0521@126.com");
            msg.To.Add(new MailAddress("xutian0521@qq.com"));
            //add这里设置添加要发送的 邮箱
            msg.Subject = "生日快乐！";


            //带HTML格式的邮件
            msg.Body = "=================================你好======================================";
            //创建一个HTML格式的文档
            AlternateView aview = AlternateView.CreateAlternateViewFromString("在中文<h1><font color=\"red\">12:00</font></h1>把饭.<br><img src=\"cid:img001\"/>", Encoding.UTF8, "text/html");

            //为邮件中增加一张图片
            LinkedResource resourec = new LinkedResource("11.jpg");
            resourec.ContentId = "img001";

            aview.LinkedResources.Add(resourec);
            msg.AlternateViews.Add(aview);

            //为邮件中增加一些附件
            Attachment attchFile1 = new Attachment("22.zip");
            msg.Attachments.Add(attchFile1);


            //2.SmtpClient  这是负责发送邮件的类
            SmtpClient smtp = new SmtpClient();
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Host = "smtp.126.com";

            smtp.Credentials = new NetworkCredential("xutian0521@126.com", "xt62628899");
            smtp.Send(msg);
            Console.WriteLine("发送完毕！");

            #endregion
        }
    }
}
