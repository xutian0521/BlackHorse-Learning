using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleIIS
{
    /// <summary>
    /// HttpApplication工厂 类
    /// </summary>
    public class HttpApplicationFactory
    {
        #region 1.0 获取 一个 HttpApplication 对象 + static IHttpHandler GetApplicationInstance()
        /// <summary>
        /// 从容器中 获取 一个 HttpApplication 对象 ，并初始化 这个对象
        /// </summary>
        /// <returns></returns>
        public static IHttpHandler GetApplicationInstance()
        {
            //1.维护一个 HttpApplication 池,创建一个 HttpApplication 对象
            HttpApplication application = new HttpApplication();
            //2.根据 配置文件 反射生成过滤器 对象，并 调用过滤器对象的 Init方法，为 HttpApplication里的事件注册用户方法
            //3.返回Application对象
            return application;
        } 
        #endregion
    }
}
