using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace StreamStringIO.Usage
{
    class Program
    {
        static void Main(string[] args)
        {
            //StreamReader和 StreamWriter 用法测试
            new StreamReaderAndWriterTest().Test(@"c:\1.txt", @"c:\2.txt");

            //文件拷贝 用法测试 --适合小文件
            new FileCopyTest().Test(@"c:\1.jpg", @"c:\2.jpg");

            string source = @"c:\4.wmv";
            string target = @"c:\5.wmv";
            //拷贝大文件 用法测试  --适合大文件
            new FileStreamTest().CopyBigFile(source , target);

            //-------------------------------一些类的用法--------------------------------------------
            //System.string 类的用法
            new StringUsage().TestUsage();
            //正则表达式 用法测试
            new RegexUsage().TestUsage();
        }
    }
}
