using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SimpleIIS
{
    /// <summary>
    /// 通信管理类 - 负责维护 与某个 浏览器 通信的过程
    /// </summary>
    public class MsgConnection
    {
        /// <summary>
        /// 与某个 客户端通信的套接字
        /// </summary>
        Socket sokMsg = null;
        /// <summary>
        /// 通信线程
        /// </summary>
        Thread thrMsg = null;
        /// <summary>
        /// 在窗体显示消息的方法
        /// </summary>
        Action<string> dgShow = null;
        /// <summary>
        /// 关闭 客户端连接 方法
        /// </summary>
        Action<string> dgCloseConn = null;

        #region 0.0 构造函数 初始化 变量 +MsgConnection(Socket sokMsg, Action<string> dgShowMsg)
        public MsgConnection(Socket sokMsg, Action<string> dgShowMsg)
        {
            this.sokMsg = sokMsg;
            this.dgShow = dgShowMsg;
            //实例化通信管理线程
            thrMsg = new Thread(RecieveMsg);
            thrMsg.IsBackground = true;
            thrMsg.Start();
        } 
        #endregion

        #region 1.0 循环接收 浏览器发来的 请求报文 -void RecieveMsg()
        /// <summary>
        /// 循环接收 浏览器发来的 请求报文
        /// </summary>
        void RecieveMsg()
        {
            try
            {
                //请求报文缓冲区
                byte[] arrRequest = new byte[1024 * 1024 * 1];
                //接收浏览器发来的请求报文，并获取真实 报文长度
                int realLength = sokMsg.Receive(arrRequest);
                //将数组 转成 请求报文字符串
                string strReqeustContent = System.Text.Encoding.UTF8.GetString(arrRequest, 0, realLength);
                //显示到 窗体
                dgShow(strReqeustContent);
                //处理请求
                ProcessRequestInternal(strReqeustContent);
            }
            catch (Exception ex)
            {
                dgShow("浏览器断开~~！");
                sokMsg.Close();
                sokMsg = null;
            }
        } 
        #endregion

        #region 2.0 处理请求报文
        /// <summary>
        /// 处理请求报文
        /// </summary>
        /// <param name="strReqeustContent"></param>
        void ProcessRequestInternal(string strReqeustContent)
        {
            //创建web处理器 对象
            WebProcessor webPro = new WebProcessor(strReqeustContent);
            //web请求处理器 处理请求后 生成 响应报文对象
            byte[] arrResponse = webPro.ProcessReqeust();
            //发送生成相应报文 字节数组
            sokMsg.Send(arrResponse);
            //关闭通信套接字，销毁与当前浏览器的 tcp 连接
            sokMsg.Close();
            sokMsg = null;
        } 
        #endregion


    }
}
