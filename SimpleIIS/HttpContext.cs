using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleIIS
{
    /// <summary>
    /// 请求上下文类 - 包含 整个请求过程中 所有需要使用的 成员（请求报文对象，响应报文对象，服务端工具对象）
    /// </summary>
    public class HttpContext
    {
        IHttpHandler mapHandler = null;
        /// <summary>
        /// 本次请求 的 动态页面类 对象
        /// </summary>
        public IHttpHandler MapHandler
        {
            get { return mapHandler; }
            set { mapHandler = value; }
        }

        HttpServerUtility server = new HttpServerUtility();
        /// <summary>
        /// 服务器帮助对象
        /// </summary>
        public HttpServerUtility Server
        {
            get { return server; }
            set { server = value; }
        }

        HttpReqeust request;
        /// <summary>
        /// 请求报文对象
        /// </summary>
        public HttpReqeust Request
        {
            get { return request; }
            set { request = value; }
        }

        private HttpResponse response;
        /// <summary>
        /// 响应报文对象
        /// </summary>
        public HttpResponse Response
        {
            get { return response; }
            set { response = value; }
        }


        /// <summary>
        /// 请求上下文 构造函数，传入请求报文
        /// </summary>
        /// <param name="strRequestContent"></param>
        public HttpContext(string strRequestContent)
        {
            //生成请求报文对象（实际就是 分析请求报文字符串，将数据封装到 请求报文对象中，方便调用）
            request = new HttpReqeust(strRequestContent);
            //生成相应报文对象
            response = new HttpResponse(request);
        }
    }
}
