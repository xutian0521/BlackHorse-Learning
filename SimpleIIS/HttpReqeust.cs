using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleIIS
{
    /*GET /login.html HTTP/1.1
      Accept: text/html, application/xhtml+xml, * /*
      Referer: http://www.oumind.com/index.html
      Accept-Language: zh-Hans-CN,zh-Hans;q=0.5
      User-Agent: Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)
      Accept-Encoding: gzip, deflate
      Host: www.oumind.com
      DNT: 1
      Connection: Keep-Alive
      Cookie: CNZZDATA2832680=cnzz_eid%3D17750356-1358664275-%26ntime%3
     */

    /// <summary>
    /// 请求报文类
    /// </summary>
    public class HttpReqeust
    {
        public string Method { get; set; }
        /// <summary>
        /// 请求的url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 请求url的后缀
        /// </summary>
        public string UrlExtention { get; set; }

        /// <summary>
        /// http协议版本
        /// </summary>
        public string HttpVersion { get; set; }

        #region 0.0 构造函数- 获取请求报文字符串，分解并将重要信息 存入 当前对象的响应属性
        /// <summary>
        /// 构造函数- 获取请求报文字符串，分解并将重要信息 存入 当前对象的响应属性
        /// </summary>
        /// <param name="strReqeuestContent"></param>
        public HttpReqeust(string strReqeuestContent)
        {
            //分割请求报文字符串（根据换行符分割）
            string[] arrReqeust = strReqeuestContent.Split(new string[1] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            if (arrReqeust.Length > 0)
            {
                //获取第一行 里的 三个值（根据 空格 分割）
                string[] arrFirstRowCol = arrReqeust[0].Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                //分别将 请求报文 第一行 里的 3个值 赋给 当前对象的 三个属性
                Method = arrFirstRowCol[0];//获取请求方法
                Url = arrFirstRowCol[1];//获取请求 url
                HttpVersion = arrFirstRowCol[2];//获取 http 协议
                UrlExtention = System.IO.Path.GetExtension(Url).ToLower();//获取请求的文件后缀
            }
            else
            {
                throw new Exception();
            }
        } 
        #endregion


    }
}
