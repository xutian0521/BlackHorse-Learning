using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleIIS
{
    public class Http404Exception:Exception
    {
        public override string Message
        {
            get
            {
                return "<html><head>您要的页面已经去火星了！</head><body>404~~<div><h1>您要的页面已经去火星了！<h1></div></body></html>";
            }
        }
    }
}
