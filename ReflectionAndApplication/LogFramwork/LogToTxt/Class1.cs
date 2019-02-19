using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LogToTxt
{
    public class Class1
    {
        public void WriteLog(string msg)
        {
            string currentDir = System.IO.Directory.GetCurrentDirectory();
            using (StreamWriter sw=File.AppendText(currentDir +@"\mylogger.txt"))
            {
                sw.WriteLine(msg);
            }
        }
    }
}
