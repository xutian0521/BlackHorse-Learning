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

namespace DoubleColorBall.Demo
{
    public delegate void Mydel();
    public partial class Form1 : Form
    {
        List<Label> lblist = new List<Label>();
        public bool start=true;
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //启动另外一个线程去 改变 lable 的值
            if (start)
            {
                start = false;
                button1.Text = "结束";
                //启动另外一个线程去 改变 lable 的值
                new Thread(() =>
                {
                    Random random = new Random();
                    while (!start)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            //闭包导致了 i的作用域变大了。出现了一些异常的情况
                            //Thread thead = new Thread((a) => SetText(a),i);
                            lblist[i].Text = random.Next(0, 9).ToString();

                        }
                        Thread.Sleep(50);
                    }
                }).Start();
            }
            else
            {
                start = true;
                button1.Text = "开始";

            }
        }
        public void SetText(int i)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //动态加载label
            for (int i = 0; i < 6; i++)
            {
                Label label = new Label();
                label.Text = i.ToString();
                label.AutoSize = true;
                label.Location = new Point(100 +i*20, 50);
                lblist.Add(label);
                this.Controls.Add(label);
            }
        }
    }
}
