using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Notepad.Main
{
    /*记事本主程序开发_加插件_转换大写插件*/
    static class Program
    {
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
