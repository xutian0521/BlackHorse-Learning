using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleIIS
{
    public interface IHttpHandler
    {
        void ProcessReqeust(HttpContext context);
    }
}
