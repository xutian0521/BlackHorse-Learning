using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Shapes;

namespace Win32.Samples.Common
{
    
    public static class Win32ApiHelper //我自己定义的aip
    {
        
        const int WM_Lbutton = 0x0; //定义了鼠标的左键点击消息 
        const int WM_Close = 0x0010; //定义了关闭消息

        public const int USER = 0x000;// 是windows系统定义的用户消息 

        [DllImport("User32.dll", EntryPoint = "FindWindow")] //声明findwindow api
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "SendMessageA")]//声明sendmessage api
        private static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, string lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, ref Rectangle lParam);//重载

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        /// <summary>
        /// 发送关闭消息关闭一个指定窗口
        /// </summary>
        /// <param name="WindowName"></param>
        public static void CloseWindow(string WindowName)
        {
            //WindowName 指定要关闭窗口的名字 
            IntPtr hwnd; //定义句柄变量

            hwnd = FindWindow(null, WindowName);//findwindow 获取窗口句柄

            Console.WriteLine("提示:句柄" + hwnd.ToString() + "窗口" + WindowName + "即将关闭，点击确定关闭");

            SendMessage(hwnd, WM_Close, IntPtr.Zero, null);//sendmessage 发送关闭消息。

        }
        
    }
}
