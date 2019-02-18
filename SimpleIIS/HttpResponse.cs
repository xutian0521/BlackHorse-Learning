using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleIIS
{
    /*
        HTTP/1.1 200 OK
        Date: Thu, 25 Apr 2013 07:43:59 GMT
        Content-Length: 4075
        Content-Type: text/html
        Last-Modified: Wed, 10 Aug 2011 06:59:35 GMT
        Accept-Ranges: bytes
        ETag: "2a2951102b57cc1:16d9e"
        Server: Microsoft-IIS/6.0
        X-Powered-By: ASP.NET

        ?!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
        <html xmlns="http://www.w3.org/1999/xhtml">
        <head>
     */

    /// <summary>
    /// 响应报文类
    /// </summary>
    public class HttpResponse
    {
        HttpReqeust request;
        public HttpResponse(HttpReqeust request)
        {
            this.request = request;
            this.HttpVersion = request.HttpVersion;

            dictStatu.Add(200, "ok");
            dictStatu.Add(403, "Forbidden");
            dictStatu.Add(404, "File Not Found");
            dictStatu.Add(500, "Internal Server Error");
        }

        /// <summary>
        /// 状态码和状态文本 字典
        /// </summary>
        private Dictionary<int, string> dictStatu = new Dictionary<int, string>();

        /// <summary>
        /// 版本号
        /// </summary>
        public string HttpVersion { get; set; }
        /// <summary>
        /// 状态码
        /// </summary>
        private int statuCode = 200;

        public int StatuCode
        {
            get { return statuCode; }
            set { statuCode = value; }
        }
        /// <summary>
        /// 状态文本
        /// </summary>
        public string Statu
        {
            get 
            {
                return dictStatu[StatuCode];
            }
        }

        /// <summary>
        /// 响应报文体 长度
        /// </summary>
        public int ContentLength
        {
            get {
                return content.Length;
            }
        }

        private byte[] content = new byte[0];
        /// <summary>
        /// 响应报文体
        /// </summary>
        public byte[] Content
        {
            get { return content; }
            set { content = value; }
        }

        private string contentType;
        /// <summary>
        /// 响应报文体格式
        /// </summary>
        public string ContentType
        {
            get
            {
                switch (request.UrlExtention)
                { 
                    case ".jpg":
                        contentType = "image/jpeg";
                        break;
                    case ".gif":
                        contentType = "image/gif";
                        break;
                    case ".png":
                        contentType = "image/png";
                        break;
                    case ".html":
                    case".htm":
                    case ".aspx":
                    case ".jsp":
                    case ".php":
                    case ".gzitcast":
                        contentType = "text/html";
                        break;
                    case ".css":
                        contentType = "text/css";
                        break;
                    case ".js":
                        contentType = "application/javascript";
                        break;
                    case".txt":
                        contentType = "text/plain";
                        break;
                }
                return contentType; 
            }
            set { contentType = value; }
        }

        #region 向响应报文体 中 追加 字符串
        /// <summary>
        /// 向响应报文体 中 追加 字符串
        /// </summary>
        /// <param name="strContent"></param>
        public void Write(string strContent)
        {
            //获取 新内容的 字节数组
            byte[] arrContent = System.Text.Encoding.GetEncoding("utf-8").GetBytes(strContent);
            //创建 一个 新数组，长度 为 原有数组长度 和 新增数据 长度 的 总和
            byte[] arrNew = new byte[content.Length + arrContent.Length];
            //将 原有数据 存入  新数组
            content.CopyTo(arrNew, 0);
            //将 新增数据 从 指定位置 存入 新数组
            arrContent.CopyTo(arrNew, content.Length);

            content = arrNew;
        } 
        #endregion

        public byte[] ToResponseByteArr()
        {
            //1.准备 相应报文头 字符串
            System.Text.StringBuilder sbHeader = new StringBuilder(300);
            sbHeader.Append(HttpVersion + " " + StatuCode + " " + Statu + "\r\n");
            sbHeader.Append("Content-Length: " + ContentLength + "\r\n");
            sbHeader.Append("Content-Type: " + ContentType + ";charset=utf-8\r\n");
            sbHeader.Append("Server: GZItCastMiniIIS-4.0\r\n\r\n");

            byte[] arrHead = System.Text.Encoding.GetEncoding("utf-8").GetBytes(sbHeader.ToString());

            //2.创建响应报文 数组（相应报文头+响应报文体）
            byte[] arrResponse = new byte[arrHead.Length + ContentLength];

            //3.分别把 相应报文头  和 响应报文体 赋值到 报文数组中
            arrHead.CopyTo(arrResponse, 0);
            content.CopyTo(arrResponse, arrHead.Length);

            //4.返回 响应报文体
            return arrResponse;
        }

    }
}
