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

namespace TalkingRoom.Client
{
    public partial class FormClient : Form
    {
        public FormClient()
        {
            InitializeComponent();
            TextBox.CheckForIllegalCrossThreadCalls = false;
        }

        //客户端 通信套接字
        Socket sokMsg = null;
        //客户端 通信线程
        Thread thrMsg = null;

        #region 1.0 发送链接服务端请求
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                //1.创建监听 套接字 使用ip4协议,流式传输，tcp连接
                sokMsg = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //2.绑定端口
                //2.1获取网络节点对象
                IPAddress address = IPAddress.Parse(txtIP.Text);
                IPEndPoint endPoint = new IPEndPoint(address, int.Parse(txtPort.Text));
                //3.向服务器 发送链接请求
                sokMsg.Connect(endPoint);
                ShowMsg("连接服务器成功~~！");
                //4.开启通信线程

                thrMsg = new Thread(RecevieMsg);
                thrMsg.IsBackground = true;
                thrMsg.SetApartmentState(ApartmentState.STA);//win7 win8 需要设置 客户端通信线程 同步设置，才能在接收文件时 打开 文件选择框
                thrMsg.Start();
            }
            catch (Exception ex)
            {

                MessageBox.Show("链接服务器发生异常！请确认服务器已开启。");
            }
        } 
        #endregion
        #region 2.0接收服务器端消息
        /// <summary>
        /// 控制客服端是否在继续循环接收服务器消息
        /// </summary>
        bool isRec = true;
        void RecevieMsg()
        {
            //3.1创建 消息缓存区
            byte[] arrMsg = new byte[1024 * 1024 * 1];
            try
            {
                while (isRec)
                {
                    //此处 接收 服务器发来的数据中，因为包含了一个 标识符，所以内容的真实长度，应该 - 1
                    int realLength = sokMsg.Receive(arrMsg)-1;
                    switch (arrMsg[0])
                    {
                        case 0://接收文本消息
                            GetMsg(arrMsg, realLength);
                            break;
                        case 1:
                            GetFile(arrMsg, realLength);
                            break;
                        default:
                            ShakeWindow();
                            break;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                sokMsg.Close();
                sokMsg = null;
                ShowMsg("服务器断开连接！"+ex);
            }
        } 
        #endregion
        #region 2.1 接收服务器文本消息并显示
        /// <summary>
        /// 接收服务器文本消息并显示
        /// </summary>
        /// <param name="arrContent"></param>
        /// <param name="realLength"></param>
        public void GetMsg(byte[] arrContent, int realLength)
        {
            //获取 接收到的内容（去掉 第一个标识符）
            string strMsg = System.Text.Encoding.UTF8.GetString(arrContent, 1, realLength);
            int i = arrContent.Length;
            ShowMsg("服务器说：" + strMsg);
        } 
        #endregion

        #region 2.2 保存文件
        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="arrContent"></param>
        /// <param name="realLength"></param>
        public void GetFile(byte[] arrContent, int realLength)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string savePath = sfd.FileName;
                //使用文件流 保存文件
                using (System.IO.FileStream fs = new System.IO.FileStream(savePath, System.IO.FileMode.OpenOrCreate))
                {
                    //将收到的文件数据数组 从 下标为1的数据开始写入 硬盘，一共写真实数据长度
                    fs.Write(arrContent, 1, realLength);
                }
                ShowMsg("保存文件到【" + savePath + "】成功~！");
            }
        }
        #endregion

        Random ran = new Random();

        #region 2.3 窗体抖动 +void ShakeWindow()
        /// <summary>
        /// 窗体抖动
        /// </summary>
        public void ShakeWindow()
        {
            //1.保存窗体原来位置
            Point oldPoint = this.Location;
            for (int i = 0; i < 15; i++)
            {
                //2.随机生成一个新位置
                Point newPoint = new Point(oldPoint.X + ran.Next(18), oldPoint.Y + ran.Next(18));
                //3.将新位置 设置给 窗体
                this.Location = newPoint;
                //4.休息15毫秒
                System.Threading.Thread.Sleep(20);
                this.Location = oldPoint;
                //4.休息15毫秒
                System.Threading.Thread.Sleep(20);
            }
        }
        #endregion

        #region 3.0 发送消息
        private void btnSend_Click(object sender, EventArgs e)
        {
            //判断通信套接字是否为空 是否连接了服务器

            string strMsg = txtInput.Text.Trim();
            byte[] arrMsg = System.Text.Encoding.UTF8.GetBytes(strMsg);
            
            try
            {
                sokMsg.Send(arrMsg);
                ShowMsg("向客服端发送：" + strMsg);
            }
            catch (Exception ex)
            {
                ShowMsg("发送消息失败~！" + ex.Message);
            }
        } 
        #endregion

        void ShowMsg(string strMsg)
        {
            this.txtShow.AppendText(strMsg + "\r\n");
            
        }
        
    }
}
