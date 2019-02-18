using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleIIS
{
    /// <summary>
    /// web请求处理类
    /// </summary>
    public class WebProcessor
    {
        /// <summary>
        /// 上下文对象
        /// </summary>
        HttpContext context;

        #region 0.0 构造函数（获取请求报文字符串）
        /// <summary>
        /// 构造函数（获取请求报文字符串）
        /// </summary>
        /// <param name="strRequestContent"></param>
        public WebProcessor(string strRequestContent)
        {
            //创建请求上下文对象 （包含 请求报文对象 和 响应报文 对象）
            context = new HttpContext(strRequestContent);
        }
        #endregion

        #region 2.0 处理结果，并生成 响应报文 字节数组 返回
        /// <summary>
        /// 处理结果，并生成 响应报文 字节数组 返回
        /// </summary>
        /// <returns></returns>
        internal byte[] ProcessReqeust()
        {
            //1.通过 HttpApplicationFactory 创建 HttpApplication 对象
            IHttpHandler application = HttpApplicationFactory.GetApplicationInstance();

            //2.调用HttpApplication对象ProcessReqeust方法，内部 使用 PageFactory 创建一个 页面对象，存入HttpContext
            application.ProcessReqeust(context);
            //3.返回 响应报文对象 生成  的 响应报文 数组
            return context.Response.ToResponseByteArr();
        } 
        #endregion
    }
}
