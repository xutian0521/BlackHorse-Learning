using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExtEditorInterface;

namespace NotepadTextStyle
{
    public class SetTextStyle:IEditor
    {
        public string Name
        {
            get { return "字体设置"; }
        }

        public void StartProgram(System.Windows.Forms.TextBox txtBox)
        {
            frmSetTextStyle frm=new frmSetTextStyle(txtBox);
            frm.Show();
        }
    }
}
