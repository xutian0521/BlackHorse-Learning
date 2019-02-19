using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace StringAndIOTextStream.Usage
{

    public class FileStreamTest
    {
        /// <summary>
        /// 拷贝大文件 用法测试
        /// </summary>
        /// <param name="source">源文件</param>
        /// <param name="target">目标文件</param>
        public void CopyBigFile(string source, string target)
        {

            //1.创建一个读取文件的流
            using (FileStream fsRead = new FileStream(source, FileMode.Open))
            {
                //2.创建一个写入文件的流
                using (FileStream fsWrite = new FileStream(target, FileMode.Create))
                {
                    //创建一个读取文件，写入文件的一个缓冲区
                    byte[] buffer = new byte[1024 * 1024 * 10];//1kb
                    //源文件的总字节数
                    double len = fsRead.Length;
                    double write;
                    double result;
                    Stopwatch watch = new Stopwatch();
                    watch.Start();
                    //开始读取文件

                    while (true)
                    {
                        //返回的r表示本次实际读取到的字节数。
                        int r = fsRead.Read(buffer, 0, buffer.Length);
                        if (r <= 0)//表示读取到了文件尾部
                        {
                            break;
                        }
                        else
                        {
                            //如果r>0，则表示本次读取到了内容
                            fsWrite.Write(buffer, 0, r);
                            write = fsWrite.Length;
                            result = write / len;

                            Console.Clear();
                            Console.WriteLine("{0}%", (int)(result * 100));
                        }

                    }
                    watch.Stop();
                    Console.WriteLine(watch.Elapsed);
                }
            }


            Console.WriteLine("文件拷贝完毕");
            Console.ReadKey();
        }
    }
}
