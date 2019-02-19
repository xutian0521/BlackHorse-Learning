using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExtEditorInterface
{
    //接口
    public interface IEditor
    {
        /// <summary>
        /// 是一个只读属性，里面储存的是插件的名称
        /// </summary>
        string Name
        {
            get;
        }
        //启动插件
        void StartProgram(TextBox txtBox);
    }
}
