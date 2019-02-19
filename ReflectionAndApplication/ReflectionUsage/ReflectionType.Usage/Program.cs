using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace ReflectionType.Usage
{
    class Program
    {
        static void Main(string[] args)
        {

            //1.动态加载程序集
            string currentDir = System.IO.Directory.GetCurrentDirectory();
            Assembly asm = Assembly.LoadFile(currentDir + @"\ReflectionTestLib.dll");

            //2.1获取chinese类型的Type
            Type typChinese = asm.GetType("ReflectionTestLib.Chinese");

            //2.2获取Person类型的Type
            Type typPerson = asm.GetType("ReflectionTestLib.Person");

            //2.3获取接口类型的Type
            Type typIXiuFu = asm.GetType("ReflectionTestLib.IZiWoXiuFu");

            //2.4获取抽象类myAbsClass的Type
            Type typmyAbsClass = asm.GetType("ReflectionTestLib.myAbsClass");
            //2.5 获取静态类myStaticClass的Type
            Type typmyStaticClass = asm.GetType("ReflectionTestLib.myStaticClass");
            #region IsAssignableFrom
            //3.验证Person类型是不是Chinese类型的父类。
            bool b = typPerson.IsAssignableFrom(typChinese);
            bool c = typIXiuFu.IsAssignableFrom(typChinese);
            Console.WriteLine(b);
            Console.WriteLine(c);
            #endregion

            #region IsInstanceofType
            //创建一个typchinese类型的对象obj
            object obj = Activator.CreateInstance(typChinese);

            //验证obj是不是typChinese类型的对象
            bool b2 = typChinese.IsInstanceOfType(obj);

            //验证obj是不是typePerson类型的对象
            bool b3 = typPerson.IsInstanceOfType(obj);
            Console.WriteLine(b2);
            Console.WriteLine(b3);
            #endregion
            #region IsSubclassof
            //验证typChinese是否是typperson的子类
            bool b4 = typChinese.IsSubclassOf(typPerson);
            Console.WriteLine(b4);

            //判断typChinese是否是typIXiuFu的子类
            //IsSubclassof 不考虑接口，只考虑子父类关系。
            bool b5= typChinese.IsSubclassOf(typIXiuFu);
            Console.WriteLine(b5);
            #endregion
            #region  IsAbstract 判断某个类型是否是一个抽象类。

            Console.WriteLine(typChinese.IsAbstract);
            Console.WriteLine(typmyAbsClass.IsAbstract);
            Console.WriteLine(typPerson.IsAbstract);
            Console.WriteLine(typIXiuFu.IsAbstract);
            Console.WriteLine(typmyStaticClass.IsAbstract);

            #endregion
            Console.ReadKey();
        }
    }
}
