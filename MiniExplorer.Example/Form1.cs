using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MiniExplorer.Example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string path = @"D:\Document\如鹏网\微服务\";
        string ext = "*.txt";
        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Text = "添加文件夹";
            button1.Text = "添加文件";

            DirectoryInfo dir = new DirectoryInfo(path);//创建一个文件夹对象“360云盘”此对象可以操作“360云盘”下所以文件和文件夹
            DirectoryInfo[] dirarray = dir.GetDirectories();//GetDirectories方法获得“360云盘”下的所以文件夹，返回DirectoryInfo[]数组。
            string[] file = Directory.GetFiles(path, ext, SearchOption.TopDirectoryOnly);//用GetFiles方法再获取“360云盘”下的所有.txt文件
                                                                                                     //返回string数组
            for (int i = 0; i < file.Length; i++)//遍历文件数组中所以的string添加到treeview控件node节点上
            {
                TreeNode nodefile =treeView1.Nodes.Add(Path.GetFileName(file[i]));
                //treeView1为什么能点出来就应为他treeView类中有Nodes这个属性，为什么Nodes能点出来Add，就就应为treeView1.Nodess
                //属性返回是TreeNodeCollection类，他里面有Add方法，treeView里面是没有Add这个方法的，treeView1.Nodes被计算后就相当于
                //一个TreeNodeCollection类，所以才能点出来Add方法。
                nodefile.Tag = file[i];
                //创建一个TreeNode的指针指向treeView1.Nodes.Add返回的一个TreeNode类，把每一个file[i]的完整路径放到TreeNode类中nodefile
                //变量的Tag属性中去。方便以后取出来用。

            }
            for (int i = 0; i < dirarray.Length; i++)//遍历DirectoryInfo[]数组中的文件目录名
            {
                TreeNode treenode=treeView1.Nodes.Add(dirarray[i].ToString());
                findfile(path + dirarray[i].ToString(), treenode);//调用递归方法findfile遍历F:\360云盘\下面所有文件和文件夹
            }
        }
        public void findfile(string dirname, TreeNode treenode)//递归方法
        {
            //TreeNode treenode这个类传进来把递归的所以文件夹和文件夹添加到treenode指向的TreeNode类中。
            //通用方法搜索dirname文件目录下的所以文件。
            string[] file = Directory.GetFiles(dirname, ext, SearchOption.TopDirectoryOnly);
            for (int i = 0; i < file.Length; i++)//遍历添加每个子节点下每个txt文件。因为文件下不可能在用文件了只有文件夹下可以有
                //文件或文件夹，所以文件下就不用掉自己 实行递归了
            {
                TreeNode nodefile=  treenode.Nodes.Add (Path.GetFileName(file[i]));
                nodefile.Tag = file[i];

            }
            DirectoryInfo dirf = new DirectoryInfo( dirname);
            DirectoryInfo[] dira = dirf.GetDirectories();
            for (int i = 0; i < dira.Length; i++)//遍历子节点下所有文件夹，在递归调用自己，再实习搜索下面的文件和文件夹，如此
                //重复，到最后总有文件夹下没有一个文件和文件夹，这时候for循环就不会在循环了，递归调用自己就会停止，所以这个递归
                //有停止条件，不会死循环。
            {
                TreeNode treenode2 = treenode.Nodes.Add(dira[i].ToString());
                findfile(Path.Combine(dirname, dira[i].ToString()), treenode2);
            }
            
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Node.Tag!=null)
            {
                textBox1.Text=  File.ReadAllText(e.Node.Tag.ToString(), Encoding.Default);
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if(result==DialogResult.OK)//选择文件的对话框，获取用户选择的文件夹。
            {
                textBox2.Text = openFileDialog1.FileName;
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            //选择文件夹的对话框，可以获取用户选择的文件夹。
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = dlg.SelectedPath;
                findfile(dlg.SelectedPath, treeView1.Nodes.Add(dlg.SelectedPath));
            }
        }
    }
}
