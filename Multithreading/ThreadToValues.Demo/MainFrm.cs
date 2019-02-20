using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 多线程之间传值
{
    public delegate void MyDelegate(string text);
    public partial class MainFrm : Form
    {
        public MyDelegate MySetCotrolTxt4otherThreadDel;
        public MainFrm()
        {
            InitializeComponent();
            this.Text = "线程"+Thread.CurrentThread.ManagedThreadId;
            //允许其他线程来访问 当前线程创建的 控件:control
            //Control.CheckForIllegalCrossThreadCalls = false;
            MySetCotrolTxt4otherThreadDel = new MyDelegate(this.setText4otherThread);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ChildFrm child = new ChildFrm();
            //child.SetTextDel = setval;
            //child.Show();

            Thread thread = new Thread( delegate(){
                ChildFrm child = new ChildFrm();
                child.SetTextDel = setval;
                child.ShowDialog();
            });
            thread.Name = "fuck";
            thread.IsBackground = true;
            thread.Start();
            

        }
        void setval(string text)
        {
            //InvokeRequired 当前执行到此的时候,校验一些textBox1是哪个线程创建的
            //如果是自己创建的InvokeRequired ：fasle 反之true
            if (this.button2.InvokeRequired)
            {
                this.Invoke(MySetCotrolTxt4otherThreadDel,text);
                MessageBox.Show(this.Text);
            }
            else
            {
                textBox1.Text = text;
            }
        }
        public void setText4otherThread(string strTxt)
        {
            this.textBox1.Text = strTxt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            setval("自己操作的");
        }

    }
}
