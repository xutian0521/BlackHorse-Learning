namespace SimpleIIS
{
    partial class FormMiniIIS
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtWebRootPath = new System.Windows.Forms.TextBox();
            this.btnChoose = new System.Windows.Forms.Button();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.btnStartListen = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtWebRootPath
            // 
            this.txtWebRootPath.Location = new System.Drawing.Point(3, 401);
            this.txtWebRootPath.Name = "txtWebRootPath";
            this.txtWebRootPath.Size = new System.Drawing.Size(593, 21);
            this.txtWebRootPath.TabIndex = 21;
            this.txtWebRootPath.Text = "C:\\Users\\Lenovo\\Desktop\\SimpleIIS\\SimpleIIS\\bin\\Debug\\web";
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(602, 399);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(75, 23);
            this.btnChoose.TabIndex = 20;
            this.btnChoose.Text = "浏 览";
            this.btnChoose.UseVisualStyleBackColor = true;
            // 
            // txtMsg
            // 
            this.txtMsg.BackColor = System.Drawing.Color.White;
            this.txtMsg.Location = new System.Drawing.Point(2, 30);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ReadOnly = true;
            this.txtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMsg.Size = new System.Drawing.Size(675, 355);
            this.txtMsg.TabIndex = 19;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(190, 3);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(42, 21);
            this.txtPort.TabIndex = 18;
            this.txtPort.Text = "50001";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(84, 3);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(100, 21);
            this.txtIP.TabIndex = 17;
            this.txtIP.Text = "192.168.1.104";
            // 
            // btnStartListen
            // 
            this.btnStartListen.Location = new System.Drawing.Point(3, 3);
            this.btnStartListen.Name = "btnStartListen";
            this.btnStartListen.Size = new System.Drawing.Size(75, 23);
            this.btnStartListen.TabIndex = 16;
            this.btnStartListen.Text = "启动监听";
            this.btnStartListen.UseVisualStyleBackColor = true;
            this.btnStartListen.Click += new System.EventHandler(this.btnStartListen_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(266, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "断开";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormMiniIIS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 442);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtWebRootPath);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.btnStartListen);
            this.Name = "FormMiniIIS";
            this.Text = "徐天设计IIS服务器 V1.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtWebRootPath;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Button btnStartListen;
        private System.Windows.Forms.Button button1;
    }
}

