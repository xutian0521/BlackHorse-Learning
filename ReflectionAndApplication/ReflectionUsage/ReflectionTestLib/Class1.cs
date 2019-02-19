using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReflectionTestLib
{
    public class class1
    {
        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public void SyaHi()
        {
            Console.WriteLine("大家好");
        }
    }
    public interface IFlyable
    {
        void Fly();
    }
    public delegate void MyDelegate();
    public enum good
    {
        白=0,
        富=1,
        美=2
    }
    internal class myclass
    { }
    public class Person
    {
        public string Name
        {
            get;
            set;
        }
        public int Age
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
    }
    public class Chinese : Person ,IZiWoXiuFu
    {
        //户口
        public string HuKouSouZaiDi
        {
            get;
            set;
        }

        public void XiuFu()
        {
            Console.WriteLine("以毒攻毒");
        }
    } 
    /// <summary>
    /// 自我修复接口
    /// </summary>
    public interface IZiWoXiuFu
    {
        void XiuFu();
    }
    public abstract class myAbsClass
    {
        public abstract void sayHello();
    }
    public static class myStaticClass
    { }
    
}
