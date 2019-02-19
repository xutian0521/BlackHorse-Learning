using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NotepadTextStyle
{
    public partial class frmSetTextStyle : Form
    {
        public frmSetTextStyle()
        {
            InitializeComponent();
        }
        public frmSetTextStyle(TextBox txtBox):this()
        {
            _txtBox = txtBox;
        }
        private TextBox _txtBox;

        private void btnOk_Click(object sender, EventArgs e)
        {
            float size=float.Parse(cboFontSize.Text);
            _txtBox.Font = new Font(cboFontFamily.Text,size);
            this.Close();
        }
    }
}
