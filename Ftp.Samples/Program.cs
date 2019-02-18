using Lvl.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftp.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 下载
            FtpClient fc = new FtpClient("ftp://192.168.1.107/", "xt", "xt123456");
            fc.Download("/1/2.gif", @"c:\4.jpg");
            Console.WriteLine("下载完成！");
            Console.ReadKey();
            #endregion

            #region 上传
            FtpClient fc2 = new FtpClient("ftp://192.168.1.107/", "xt", "xt123456");
            FileInfo fi=new FileInfo(@"c:\4.jpg");
            fc.Upload(fi, "/1/5.jpg");
            Console.WriteLine("上传完毕！");
            Console.ReadKey();
            #endregion
            
        }
    }
}
