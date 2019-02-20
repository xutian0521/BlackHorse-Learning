using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace AspNetGeneralHandler
{
    /// <summary>
    /// ValidCodeLogin 的摘要说明
    /// </summary>
    public class ValidCodeLogin : IHttpHandler
    {
        public char[] charArr;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/jpeg";
            //初始化 要随机生成的字符
            charArr = new char[10] { 'a', 'b', 'c', 'd', 'e', '1', '2', '3', '4', '5' };
            //生成随机验证码字符串
            string code = getRanCode();
            
            using(Image img=new Bitmap(80,23))
            {
                //FromImage相当于 画家那img当纸
                using (Graphics g=Graphics.FromImage(img))
                {
                    //把背景画成 白色 的
                    g.Clear(Color.White);
                    DrawGanRaoDian(20, g, img);
                    g.DrawRectangle(new Pen(Brushes.Black),new Rectangle(0,0,img.Width-1,img.Height-1));
                    g.DrawString(code, new Font("华文行楷", 20), Brushes.Red, 1, 1);
                }
                //将生成 图片 保存到 响应报文体流中，以jpg图片格式保存
                img.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
        #region  画干扰点 -DrawGanRaoDian(int count, Graphics g, Image img)
        void DrawGanRaoDian(int count, Graphics g, Image img)
        {
            for (int i = 0; i < count; i++)
            {
                Point p1 = new Point(ran.Next(img.Width - 5), ran.Next(img.Height));
                Point p2 = new Point(p1.X - ran.Next(10), p1.Y - ran.Next(5));
                g.DrawLine(Pens.Black, p1, p2);
            }

        } 
        #endregion

        Random ran = new Random();
        /// <summary>
        /// 从定义的charArr数组中字符 随机生成验证码
        /// </summary>
        /// <returns></returns>
        public string getRanCode()
        {
            System.Text.StringBuilder sbCode = new System.Text.StringBuilder();
            int index;
            for (int i = 0; i < 4; i++)
            {
                index = ran.Next(0, charArr.Length-1);
                char tempCode= charArr[index];
                sbCode.Append(tempCode);
            }
            return sbCode.ToString();

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