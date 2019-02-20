using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace StreamStringIO.Usage
{
    public class FileCopyTest
    {
        /// <summary>
        /// 文件拷贝 用法测试
        /// </summary>
        public void Test(string source, string target)
        {
            Environment.GetEnvironmentVariable("windir");//获取系统环境变量
            Process.Start(Environment.GetEnvironmentVariable("systemroot") + @"\System32\cmd.exe");
            Console.WriteLine(File.Exists(@"C:\age.txt"));
            Console.ReadKey();
            Stopwatch stopwathc = new Stopwatch();
            stopwathc.Start();
            File.Copy(source, target, true);
            stopwathc.Stop();
            Console.WriteLine(stopwathc.Elapsed);
            Console.ReadKey();
        }
    }
}
