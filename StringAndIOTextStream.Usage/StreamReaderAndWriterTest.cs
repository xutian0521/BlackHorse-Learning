using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace StringAndIOTextStream.Usage
{
    /// <summary>
    /// 
    /// </summary>
    public class StreamReaderAndWriterTest
    {
        /// <summary>
        /// StreamReader和 StreamWriter 文本流用法测试
        /// </summary>
        public void Test(string source, string target)
        {
            using (StreamReader sr = new StreamReader(source, Encoding.Default))
            {
                using (StreamWriter sw = new StreamWriter(target, false, Encoding.GetEncoding("gb2312")))
                {
                    string result;
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    int i = 0;
                    while ((result = sr.ReadLine()) != null)
                    {
                        i++;//记录读取的行数
                        sw.WriteLine(result);
                    }
                    stopwatch.Stop();
                    Console.WriteLine(stopwatch.Elapsed);
                    Console.WriteLine(i);
                    Console.WriteLine(result);

                    Console.ReadKey();
                }
            }
        }
    }
}
