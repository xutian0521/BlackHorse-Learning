using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Win32.Samples.Common;

namespace Win32.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("关闭【计算器】出口");
            Win32ApiHelper.CloseWindow("计时器");
            Console.ReadKey();
        }
    }
}
