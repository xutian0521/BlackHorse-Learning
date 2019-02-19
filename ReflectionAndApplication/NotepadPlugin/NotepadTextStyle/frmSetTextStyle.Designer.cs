﻿namespace NotepadTextStyle
{
    partial class frmSetTextStyle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboFontFamily = new System.Windows.Forms.ComboBox();
            this.cboFontSize = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择字体";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "选择字号";
            // 
            // cboFontFamily
            // 
            this.cboFontFamily.FormattingEnabled = true;
            this.cboFontFamily.Items.AddRange(new object[] {
            "宋体",
            "隶书",
            "微软雅黑",
            "华文行楷"});
            this.cboFontFamily.Location = new System.Drawing.Point(83, 44);
            this.cboFontFamily.Name = "cboFontFamily";
            this.cboFontFamily.Size = new System.Drawing.Size(121, 20);
            this.cboFontFamily.TabIndex = 2;
            // 
            // cboFontSize
            // 
            this.cboFontSize.FormattingEnabled = true;
            this.cboFontSize.Items.AddRange(new object[] {
            "10",
            "20",
            "30",
            "40",
            "50"});
            this.cboFontSize.Location = new System.Drawing.Point(83, 89);
            this.cboFontSize.Name = "cboFontSize";
            this.cboFontSize.Size = new System.Drawing.Size(121, 20);
            this.cboFontSize.TabIndex = 3;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(100, 145);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmSetTextStyle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cboFontSize);
            this.Controls.Add(this.cboFontFamily);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmSetTextStyle";
            this.Text = "选择字体与字号";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboFontFamily;
        private System.Windows.Forms.ComboBox cboFontSize;
        private System.Windows.Forms.Button btnOk;
    }
}