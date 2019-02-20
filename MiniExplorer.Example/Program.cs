using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MiniExplorer.Example
{
    static class Program
    {
        /*MiniExplorer.Example 迷你版文件资料管理器*/
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
