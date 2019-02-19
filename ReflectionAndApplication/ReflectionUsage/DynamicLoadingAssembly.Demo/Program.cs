using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace DynamicLoadingAssembly.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.加载当前运行目录下的 ReflectionTestLib.dll程序集
            //现在asm就是ReflectionTestLib.dll程序集
            string currentDir = System.IO.Directory.GetCurrentDirectory();
            Assembly asm = Assembly.LoadFile(currentDir + @"\ReflectionTestLib.dll");

            #region 加载指定的程序集，并且获取该程序集中的所有类型。


            //获取asm这个程序集中的所有的类型
            //Type[] types= asm.GetTypes();

            //获取程序集中所有的public的类型
            Type[] types = asm.GetExportedTypes();
            foreach (Type item in types)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadKey();
            #endregion
            #region 加载程序集，获取class1下面的所有方法
            //1.加载程序集

            //2.获取class1这个类型
            //typeclass1就是表示描述class1类的type，里面储存的就是class1的一些相关信息，就可以理解成class1的元数据
            Type typeClass1 = asm.GetType("ReflectionTestLib.class1");

            //3.获取class1中的所有的方法
            MethodInfo[] minfos = typeClass1.GetMethods();

            //4.遍历每个方法，把每个方法的名称打印出来
            foreach (MethodInfo methodItem in minfos)
            {
                Console.WriteLine(methodItem.Name);
            }
            Console.ReadKey();
            #endregion

            #region 加载程序集，获取class1下面的所有SyaHi方法，并调用
            //1.加载程序集


            //2.获取class1这个类型
            //typeclass2就是表示描述class1类的type，里面储存的就是class1的一些相关信息，就可以理解成class1的元数据
            Type typeClass2 = asm.GetType("ReflectionTestLib.class1");

            //3.获取class1中的所有的方法
            MethodInfo menthod = typeClass2.GetMethod("SyaHi");
            //4.输出方法名
            Console.WriteLine(menthod.Name);

            //创建class1类型的对象
            Object obj = Activator.CreateInstance(typeClass2);
            //5.调用该方法
            menthod.Invoke(obj, null);
            Console.ReadKey();
            #endregion

        }
    }
}
