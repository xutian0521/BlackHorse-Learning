using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading.Example
{
    public  delegate void mydel(int a);
    public delegate int MyAddFunDel(int a,int b);
    class Program
    {
        static void Main(string[] args)
        {
            #region 多线程演示
            Console.WriteLine("------------------------多线程演示------------------------------");
            //获取当前线程
            Thread mainThread = Thread.CurrentThread;
            Console.WriteLine("主线程的id是：{0}", Thread.CurrentThread.ManagedThreadId);

            //创建一个线程
            Thread thread = new Thread(Dowork);
            //设置线程名
            thread.Name = "shir";
            //设置后台线程
            thread.IsBackground = true;
            //启动一个线程（不是正真启动，告诉cpu我当前这个线程可以执行了）
            thread.Start();
            int inum = 0;
            while (inum <= 10)
            {
                inum++;
                Thread.Sleep(1000);
                Console.WriteLine("主线程。。{0}", Thread.CurrentThread.ManagedThreadId);
                if (inum == 5)
                {
                    thread.Abort();
                }
            }
            Console.ReadKey();

            #endregion

            #region 带参数的线程
            Console.WriteLine("------------------------带参数的线程------------------------------");
            Thread thread2 = new Thread((a) =>
            {
                int j = 0;
                while ( j <= 4)
                {
                    j++;
                    Thread.Sleep(1000);
                    Console.WriteLine("带参数子线程。。{0}参数是:{1}", Thread.CurrentThread.ManagedThreadId, a);
                }
            });
            thread2.IsBackground = true;
            thread2.Start("Id");
            Console.ReadKey();



            #endregion

            #region 异步委托
            Console.WriteLine("------------------------异步委托演示------------------------------");
            Console.WriteLine("主线程是：{0}", Thread.CurrentThread.ManagedThreadId);
            MyAddFunDel myDel = new MyAddFunDel(AddStatic);

            //myDel(1, 3); 同步的 直接调用
            //异步的 IAsyncResult并记录异步状态
            IAsyncResult delResult= myDel.BeginInvoke(3, 4, null, null);
           

            while (!delResult.IsCompleted)
            {
                //主线程干其他事情
               
            }

            //获取另外一个线程执行 的结果
            int addResult = myDel.EndInvoke(delResult);
            Console.WriteLine("主线程获得子线程的结果是:{0}", addResult);
            Console.ReadKey();
            #endregion
        }
        static void Dowork()
        {
            while (true)
            {
                Thread.Sleep(1000);
                Console.WriteLine("子线程。。{0}", Thread.CurrentThread.ManagedThreadId);
            }
        }
        static void Test(int a)
        {
            Thread.Sleep(1000);
            Console.WriteLine("带参数子线程。。{0}参数是:{1}", Thread.CurrentThread.ManagedThreadId,a);
        }
        static int AddStatic(int a, int b)
        {
            Console.WriteLine("AddStatic 执行了..." + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(3000);
            return a + b;
        }
    }
}
