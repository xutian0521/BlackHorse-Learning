using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Reflection;
using System.IO;

namespace LogFramwork.Main
{
    /*日志框架测试 主项目*/
    class Program
    {
        static void Main(string[] args)
        {
            //1.启动Main方法的时候记录日志
            Log(DateTime.Now.ToString() + "启动了Main方法。");

            Log(DateTime.Now.ToString()+"声明了一个int类型的变量n");
            int n = 10;
            SayHi();
            Console.ReadKey();
        }

        static void SayHi()
        {
            Console.WriteLine("hi~!!!");
        }
        static void Log(string msg)
        {
            //1.读取配置文件中的用户指定的dll文件
            string dllPath = ConfigurationManager.AppSettings["DllPath"];
            Assembly asm = Assembly.LoadFile(Path.GetFullPath(dllPath));
            string className = ConfigurationManager.AppSettings["ClassName"];
            Type type = asm.GetType(className);
            MethodInfo mehtod = type.GetMethod(ConfigurationManager.AppSettings["MethodName"]);
            if (mehtod != null)
            {
                mehtod.Invoke(Activator.CreateInstance(type), new Object[] { msg });
            }

        }
    }
}
