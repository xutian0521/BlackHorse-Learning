using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
namespace TalkingRoom.Server
{
    public partial class FormServer : Form
    {
        public FormServer()
        {
            InitializeComponent();
            TextBox.CheckForIllegalCrossThreadCalls = false;
        }
        //服务端 监听套接字
        Socket sokWatch = null;
        //服务端 监听线程
        Thread thrWatch = null;
        //z字典集合：保存 通信套接字
        Dictionary<string, MsgConnetion> dictCon = new Dictionary<string, MsgConnetion>();

        #region 1.0 启动监听
        private void btnStartListen_Click(object sender, EventArgs e)
        {
            try
            {
                //1.创建监听 套接字 使用ip4协议,流式传输，tcp连接
                sokWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //2.绑定端口
                //2.1获取网络节点对象
                IPAddress address = IPAddress.Parse(txtIP.Text);
                IPEndPoint endPoint = new IPEndPoint(address, int.Parse(txtPort.Text));

                //2.2绑定端口(其实内部 就向系统的端口表中 注册了一个端口,并指定当前程序句柄 )
                sokWatch.Bind(endPoint);
                //2.3设置监听队列(指,限制 同时处理的 连接请求--即同时处理的客服端连接请求)
                sokWatch.Listen(10);
                //2.4开始监听：此方法会阻断当前线程，直到有 其他程序连接锅里，才执行完毕
                thrWatch = new Thread(WatchConnection);
                thrWatch.IsBackground = true;
                thrWatch.Start();
                ShowMsg("服务器启动了！！");
            }
            catch (SocketException sex)
            {
                ShowMsg("异常:" + sex);
            }
            catch (Exception ex)
            {

                ShowMsg("异常：" + ex);
            }
        } 
        #endregion
        #region 2.0 服务端监听方法 WatchConnection()
        /// <summary>
        /// 用来控制是否中断循环监听的变量
        /// </summary>
        bool isWatch = true;
        /// <summary>
        /// 服务端监听方法
        /// </summary>
        void WatchConnection()
        {
            try
            {
                //循环监听 客服端的 连接请求
                while (isWatch)
                {
                    //2.4开始监听：此方法会阻断当前线程，直到有 其他程序连接锅里，才执行完毕
                    Socket sokMsg = sokWatch.Accept();
                    //2.5创建通信管理类
                    MsgConnetion conn = new MsgConnetion(sokMsg,ShowMsg,RemoveClient);
                    //将当前连接成功的[与客服端通信的套接字] 的标志 保存起来
                    //将 远程服务端的 ip和端口 字符串 存入 列表
                    lbOnline.Items.Add(sokMsg.RemoteEndPoint.ToString());
                    //将 服务端的通信套接字 存入 字典集合
                    dictCon.Add(sokMsg.RemoteEndPoint.ToString(), conn);

                    ShowMsg("客服端[" + sokMsg.RemoteEndPoint + "]连接了~~！");
                }
            }
            catch (Exception ex)
            {
                
                ShowMsg("异常:"+ex);
            }
        }
        #endregion


        
        #region 3.0 服务端 向指定的客服端 发送消息
        /// <summary>
        /// 3.0 服务端 向指定的客服端 发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            string strClient = lbOnline.Text;
            if (dictCon.ContainsKey(strClient))
            {
                string strMsg = txtInput.Text.Trim();
                ShowMsg("向客服端[" + strClient + "]说：" + strMsg);

                //使用 指定的 通信套接字 将字符串 发送到 指定的客服端
                try
                {
                    dictCon[strClient].SendMsg(strMsg);
                }
                catch (Exception ex)
                {

                    ShowMsg("异常：" + ex.Message);
                }
            } 
        

        }
        #endregion

        #region 4.0 根据 要中断的 客户端 ipPort 关闭连接
        /// <summary>
        /// 根据 要中断的 客户端 ipPort 关闭连接
        /// </summary>
        /// <param name="clientIpPort"></param>
        public void RemoveClient(string clientIpPort)
        {
            //1.移除列表中的项
            lbOnline.Items.Remove(clientIpPort);
            //2.关闭通信管理类
            dictCon[clientIpPort].Close();
            //3.从字典中 移除 对应的通信管理类 项
            dictCon.Remove(clientIpPort);

        } 
        #endregion
        
        #region 5.0 选择要发送的文件
        /// <summary>
        /// 选择要发送的文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //将选中要发送的文件路径 显示到 文本框中
                txtFilePath.Text = ofd.FileName;
            }
        }
        #endregion 

        #region 6.0 发送文件
        /// <summary>
        /// 6.0 发送文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendFile_Click(object sender, EventArgs e)
        {
            string strClient = lbOnline.Text;
            //6.1 获取要发送的文件路径
            string strFilePath = txtFilePath.Text;
            if (dictCon.ContainsKey(strClient))
            {
                try
                {
                    //6.2发送文件
                    dictCon[strClient].SendFile(strFilePath);
                }
                catch (Exception ex)
                {
                    
                    ShowMsg("异常："+ex);
                }
            }
        } 
        #endregion

        #region 7.0 向指定的客户端发送抖屏命令
        /// <summary>
        /// 7.0 向指定的客户端发送抖屏命令！
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShack_Click(object sender, EventArgs e)
        {
            //获取选中 要发送的客户端 的地址 endPoint
            string strClient = lbOnline.Text;
            //判断dictCon中是否包含strClient指定的地址
            if (dictCon.ContainsKey(strClient))
            {
                try
                {
                    //调用 MsgConnetion类SendShake()方法发送抖屏
                    dictCon[strClient].SendShake();
                }
                catch (Exception ex)
                {
                    
                    ShowMsg("异常"+ex);
                }
            }
        } 
        #endregion

        /// <summary>
        /// 在服务器窗口中显示消息
        /// </summary>
        /// <param name="strMsg"></param>
        void ShowMsg(string strMsg)
        {
            this.txtShow.AppendText(strMsg + "\r\n");
        }
    }
}
