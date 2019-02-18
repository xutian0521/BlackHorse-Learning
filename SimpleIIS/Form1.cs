using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SimpleIIS
{
    public partial class FormMiniIIS : Form
    {
        public FormMiniIIS()
        {
            InitializeComponent();
            TextBox.CheckForIllegalCrossThreadCalls = false;
        }

        //服务端 监听套接字
        Socket sokWatch = null;
        //服务端 监听线程
        Thread thrWatch = null;
        //字典集合：保存 通信套接字
        Dictionary<string, Socket> dictCon = new Dictionary<string, Socket>();

        #region 1.0 启动服务器
        /// <summary>
        /// 启动服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartListen_Click(object sender, EventArgs e)
        {
            try
            {
                //1.创建【监听套接字】 使用 ip4协议，流式传输，TCP连接
                sokWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //2.绑定端口
                //2.1获取网络节点对象
                IPAddress address = IPAddress.Parse(txtIP.Text);
                IPEndPoint endPoint = new IPEndPoint(address, int.Parse(txtPort.Text));
                //2.2绑定端口（其实内部 就向系统的 端口表中 注册 了一个端口，并指定了当前程序句柄）
                sokWatch.Bind(endPoint);
                //2.3设置监听队列(指，限制 同时 处理的 连接请求数--即同时处理的客户端连接请求)
                sokWatch.Listen(10);
                //2.4开始监听,调用监听线程 执行 监听套接字的 监听方法
                thrWatch = new Thread(WatchConnecting);
                thrWatch.IsBackground = true;
                thrWatch.Start();
                ShowMsg("服务器启动啦~~！");

                HttpServerUtility.WebPath = txtWebRootPath.Text.Trim();
            }
            catch (SocketException sex)
            {
                MessageBox.Show("异常：" + sex);
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常：" + ex);
            }
        }
        #endregion

        bool isWatch = true;

        private void WatchConnecting()
        {
            while (isWatch)
            {
                //.1调用监听套接字的 Accept方法 循环监听 浏览器端的 连接请求，一旦连接上，就生成一个 与该浏览器 通信的 通信套接字
                Socket sokMsg = sokWatch.Accept();
                MsgConnection conn = new MsgConnection(sokMsg, ShowMsg);
            }
        }


        void ShowMsg(string strmsg)
        {
            this.txtMsg.AppendText(strmsg + "\r\n");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isWatch = false;
        }

    }
}
