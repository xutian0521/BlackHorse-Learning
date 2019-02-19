using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using ExtEditorInterface;

namespace Notepad.Main
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //主程序的窗体的加载事件
        private void Form1_Load(object sender, EventArgs e)
        {
            //1.检查plugings下目录下是否有dll文件
            //1.1获取当前执行的exe文件的绝对路径
            string exePath = Assembly.GetExecutingAssembly().Location;
            //获取了插件目录
            string pluginsPath = Path.Combine(Path.GetDirectoryName(exePath),"plugins");
            //2.如果有dll文件，则循环遍历，讲每个dll文件都通过Assembly.loadFile();加载进来
            //然后获取dll程序集中的类型

            //2.搜索pluginsPath目录下是否有对应的dll文件
            //返回值的一个sting数组，里面储存着每个dll文件的完整路径
            string[] dlls= Directory.GetFiles(pluginsPath, "*.dll");

            //循环遍历把每个插件dll 都加载进来
            foreach(string item in dlls)
            {
                //这里的每个item，就是每个dll的完整路径
                Assembly aesm = Assembly.LoadFile(item);

                //获取当前插件（当前的asem这个程序集中对应的类型，然后调用方法就可以了）

                //遍历asem这个（程序集）中的每个类型，找的那些public的类型，并且实现了
                //IEditor接口的那些类

                //获取所有的public类型
                Type[] types = aesm.GetExportedTypes();

                //获得接口的Type
                Type typIEditor = typeof(IEditor);

                //遍历每个类型看看这个类型是否实现了IEditor接口的类型
                foreach(Type typeclass in types)
                {
                    //判断当前类型typeClass，是否实现了IEditor接口
                    //
                    if( typIEditor.IsAssignableFrom(typeclass)&&!typeclass.IsAbstract)
                    {
                        //创建一个typeClass类型的对象
                        IEditor editor = (IEditor)Activator.CreateInstance(typeclass);

                        //在菜单栏中，讲该插件的名称增加进去
                       ToolStripItem tsiMenu=  this.格式ToolStripMenuItem.DropDownItems.Add(editor.Name);

                       tsiMenu.Tag = editor;
                        //为tsiMenu注册一个单击事件
                        tsiMenu.Click += new EventHandler(tsiMenu_Click);
                    }
                }
            }

        }
        //新增的插件的菜单的单击事件
        void tsiMenu_Click(object sender, EventArgs e)
        {
            //sender 就是当前单击的菜单项
            ToolStripItem tsi = (ToolStripItem)sender;
            IEditor editor = (IEditor)tsi.Tag;
            editor.StartProgram(textBox1);
        }
    }
}
