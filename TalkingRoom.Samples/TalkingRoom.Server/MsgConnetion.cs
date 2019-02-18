using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TalkingRoom.Server
{
    /// <summary>
    /// 通信管理类- 负责 处理 与某个客服端通信的过程
    /// </summary>
    public class MsgConnetion
    {
        /// <summary>
        /// 与某个 客服端的通信套接字
        /// </summary>
        Socket sokMsg = null;
        /// <summary>
        /// 通信线程
        /// </summary>
        Thread thrMsg = null;
        /// <summary>
        /// 显示消息到窗体的方法
        /// </summary>
        DGShowMsg dgShow = null;
        /// <summary>
        /// 关闭 客户端连接 的方法
        /// </summary>
        DGCloseConn dgCloseConn = null;
        #region 0.0 构造函数
        public MsgConnetion(Socket sokMsg, DGShowMsg dgShow, DGCloseConn dgCloseConn)
        {
            this.sokMsg = sokMsg;
            
            this.dgShow = dgShow;
            this.dgCloseConn = dgCloseConn;
            //创建通信线程 负责调用 通信套接字 来接受客户端消息
            thrMsg = new Thread(RecevieMsg);
            thrMsg.IsBackground = true;
            thrMsg.Start(this.sokMsg);
        } 
        #endregion

        #region 2.0 接收客户端消息
        bool isReceive = true;
        void RecevieMsg(object obj)
        {
            Socket sokMsg = obj as Socket;
            //3.通信套接字 监听 客服端的 消息
            //3.1创建 消息缓存区
            byte[] arrMsg = new byte[1024 * 1024 * 1];
            try
            {
                while (isReceive)
                {
                    //3.2接收到消息 并存入 缓冲区；Receive仿佛也会阻断当前线程
                    //   并返回 真实 接收到客服端 数据的 字节长度
                    int realLength = sokMsg.Receive(arrMsg);

                    //3.3 将接收到的消息 转换成字符串 并截取1到realLength 长度的真实长度
                    string strMsg = System.Text.Encoding.UTF8.GetString(arrMsg, 0, realLength);
                    //3.4 将消息 显示 到文本框
                    dgShow("客服端[" + sokMsg.RemoteEndPoint.ToString() + "]说：" + strMsg);
                }
            }
            //检查与客服端连接 异常则 认为客服端关闭 并抛异常
            catch (Exception ex)
            {
                //显示消息
                dgShow("客服[" + sokMsg.RemoteEndPoint + "]端断开连接~~！" );
                //调用 窗体类的 关闭移除方法
                dgCloseConn(sokMsg.RemoteEndPoint.ToString());
            }
        }
        #endregion

        #region 3.0 向客服端发送 文本消息 + public void SendMsg(string msg)
        /// <summary>
        /// 向客服端发送 文本消息
        /// </summary>
        /// <param name="msg"></param>
        public void SendMsg(string msg)
        {
            //使用 指定的 通信套接字 将字符串 发送到 指定的客服端
            byte[] arrMsg = System.Text.Encoding.UTF8.GetBytes(msg);
            try
            {
                byte[] newArr = MakeNew("str", arrMsg);
                sokMsg.Send(newArr);
            }
            catch (Exception ex)
            {

                dgShow("异常：" + ex.Message);
            }
        } 
        #endregion

        #region 4.0 向客户端 发送 文本文件
        /// <summary>
        /// 4.0 向客户端 发送 文件
        /// </summary>
        /// <param name="strFilePath"></param>
        public void SendFile(string strFilePath)
        {
            //6.2读取要发送的文件
            byte[] arrFile = System.IO.File.ReadAllBytes(strFilePath);
            //6.3 向客户端发送文件
            byte[] newArr=MakeNew("file",arrFile);
            sokMsg.Send(newArr);

        }
        #endregion

        #region 5.0 向客户端 发送抖屏命令
        /// <summary>
        /// 5.0 向客户端 发送抖屏命令
        /// </summary>
        public void SendShake()
        {
            sokMsg.Send(new byte[1] { 2 });
        } 
        #endregion

        #region 5.0 返回带标识的 新数组
        /// <summary>
        /// 返回带标识的 新数组
        /// </summary>
        /// <param name="type"></param>
        /// <param name="oldArr"></param>
        /// <returns></returns>
        public byte[] MakeNew(string type, byte[] oldArr)
        {

            //6.3创建一个新数组（是原数组长度+1）
            byte[] newArrFile = new byte[oldArr.Length + 1];
            //6.4 将原数组数据 复制到 新数组中（从新数组下标为1的位置开始放）
            oldArr.CopyTo(newArrFile, 1);
            //6.5 为新数组第一个元素 设置标识符
            switch (type.ToLower())
            {
                case "str":
                    newArrFile[0] = 0;
                    break;
                case "file":
                    newArrFile[0] = 1;
                    break;
                default:
                    newArrFile[0] = 2;
                    break;
            }

            return newArrFile;
        } 
        #endregion

        #region 4.0 关闭通信
        public void Close()
        {
            isReceive = false;
            sokMsg.Close();
            sokMsg = null;
        }
        #endregion 
        
    }
}
