using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExtEditorInterface;

namespace NotepadConvertToUpper
{
    public class Class1:IEditor
    {

        public string Name
        {
            get { return "转换大写"; }
        }

        public void StartProgram(System.Windows.Forms.TextBox txtBox)
        {
            txtBox.Text=txtBox.Text.ToUpper();
        }
    }
}
