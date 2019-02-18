using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleIIS
{
    /// <summary>
    /// HttpApplication 类 - 页面执行过程的管理类
    /// </summary>
    public class HttpApplication : IHttpHandler
    {
        #region 处理
        /// <summary>
        /// 负责 被请求页面的 整个处理流程！
        /// </summary>
        /// <param name="context"></param>
        public void ProcessReqeust(HttpContext context)
        {
            try
            {
                //1.根据上下文对象 里的请求报文 的url后缀 创建一个 页面请求处理对象
                IHttpHandler pageProcessor = PageProcessFactory.GetPageProcessInstance(context.Request);
                //2.处理对象进行处理，其中，如果是静态页面和图片，就已经生成响应报文内容 放在 context.Response中
                //  响应报文对象中就已经 包含了要返回 的响应报文对象了！
                pageProcessor.ProcessReqeust(context);

                //3.继续执行管道里的其它事件（现在还没写）

                //4.在第11-12事件之间 执行页面对象的 PR方法
                if (context.MapHandler != null)
                {
                    context.MapHandler.ProcessReqeust(context);
                }
            }
            catch (Http404Exception ex404)
            {
                context.Response.Write(ex404.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        #endregion
    }
}
