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
    
    public partial class ChildFrm : Form
    {
        public MyDelegate SetTextDel;
        public ChildFrm()
        {
            InitializeComponent();
            this.Text ="线程" +Thread.CurrentThread.ManagedThreadId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetTextDel(textBox2.Text);
            
        }

    }
}
