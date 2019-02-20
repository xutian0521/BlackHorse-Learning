using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetGeneralHandler
{
    public static class PageHelper
    {
        public static string ReadFile(string path)
        {
            return System.IO.File.ReadAllText(path);
        }
    }
}