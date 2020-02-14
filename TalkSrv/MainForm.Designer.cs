namespace TalkSrv
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.textBoxShowMsg = new System.Windows.Forms.TextBox();
            this.textBoxSetSendName = new System.Windows.Forms.TextBox();
            this.labelShowSendTo = new System.Windows.Forms.Label();
            this.buttonSendMsg = new System.Windows.Forms.Button();
            this.textBoxMsgToSend = new System.Windows.Forms.TextBox();
            this.textBoxSetSrvIP = new System.Windows.Forms.TextBox();
            this.textBoxSetSrvPort = new System.Windows.Forms.TextBox();
            this.labelShowServerIP = new System.Windows.Forms.Label();
            this.labelShowServerPort = new System.Windows.Forms.Label();
            this.buttonStartSrv = new System.Windows.Forms.Button();
            this.buttonShutdownSrv = new System.Windows.Forms.Button();
            this.pictureBoxShowLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShowLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxShowMsg
            // 
            this.textBoxShowMsg.AcceptsReturn = true;
            resources.ApplyResources(this.textBoxShowMsg, "textBoxShowMsg");
            this.textBoxShowMsg.Name = "textBoxShowMsg";
            this.textBoxShowMsg.ReadOnly = true;
            // 
            // textBoxSetSendName
            // 
            resources.ApplyResources(this.textBoxSetSendName, "textBoxSetSendName");
            this.textBoxSetSendName.Name = "textBoxSetSendName";
            // 
            // labelShowSendTo
            // 
            resources.ApplyResources(this.labelShowSendTo, "labelShowSendTo");
            this.labelShowSendTo.Name = "labelShowSendTo";
            // 
            // buttonSendMsg
            // 
            resources.ApplyResources(this.buttonSendMsg, "buttonSendMsg");
            this.buttonSendMsg.Name = "buttonSendMsg";
            this.buttonSendMsg.UseVisualStyleBackColor = true;
            this.buttonSendMsg.Click += new System.EventHandler(this.buttonSendMsg_Click);
            // 
            // textBoxMsgToSend
            // 
            resources.ApplyResources(this.textBoxMsgToSend, "textBoxMsgToSend");
            this.textBoxMsgToSend.Name = "textBoxMsgToSend";
            // 
            // textBoxSetSrvIP
            // 
            resources.ApplyResources(this.textBoxSetSrvIP, "textBoxSetSrvIP");
            this.textBoxSetSrvIP.Name = "textBoxSetSrvIP";
            // 
            // textBoxSetSrvPort
            // 
            resources.ApplyResources(this.textBoxSetSrvPort, "textBoxSetSrvPort");
            this.textBoxSetSrvPort.Name = "textBoxSetSrvPort";
            // 
            // labelShowServerIP
            // 
            resources.ApplyResources(this.labelShowServerIP, "labelShowServerIP");
            this.labelShowServerIP.Name = "labelShowServerIP";
            // 
            // labelShowServerPort
            // 
            resources.ApplyResources(this.labelShowServerPort, "labelShowServerPort");
            this.labelShowServerPort.Name = "labelShowServerPort";
            // 
            // buttonStartSrv
            // 
            resources.ApplyResources(this.buttonStartSrv, "buttonStartSrv");
            this.buttonStartSrv.Name = "buttonStartSrv";
            this.buttonStartSrv.UseVisualStyleBackColor = true;
            this.buttonStartSrv.Click += new System.EventHandler(this.buttonStartSrv_Click);
            // 
            // buttonShutdownSrv
            // 
            resources.ApplyResources(this.buttonShutdownSrv, "buttonShutdownSrv");
            this.buttonShutdownSrv.Name = "buttonShutdownSrv";
            this.buttonShutdownSrv.UseVisualStyleBackColor = true;
            this.buttonShutdownSrv.Click += new System.EventHandler(this.buttonShutdownSrv_Click);
            // 
            // pictureBoxShowLogo
            // 
            this.pictureBoxShowLogo.Image = global::TalkSrv.Properties.Resources.talkpic_srv;
            resources.ApplyResources(this.pictureBoxShowLogo, "pictureBoxShowLogo");
            this.pictureBoxShowLogo.Name = "pictureBoxShowLogo";
            this.pictureBoxShowLogo.TabStop = false;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBoxShowLogo);
            this.Controls.Add(this.buttonShutdownSrv);
            this.Controls.Add(this.buttonStartSrv);
            this.Controls.Add(this.labelShowServerPort);
            this.Controls.Add(this.labelShowServerIP);
            this.Controls.Add(this.textBoxSetSrvPort);
            this.Controls.Add(this.textBoxSetSrvIP);
            this.Controls.Add(this.textBoxMsgToSend);
            this.Controls.Add(this.buttonSendMsg);
            this.Controls.Add(this.labelShowSendTo);
            this.Controls.Add(this.textBoxSetSendName);
            this.Controls.Add(this.textBoxShowMsg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShowLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxShowMsg;
        private System.Windows.Forms.TextBox textBoxSetSendName;
        private System.Windows.Forms.Label labelShowSendTo;
        private System.Windows.Forms.Button buttonSendMsg;
        private System.Windows.Forms.TextBox textBoxMsgToSend;
        private System.Windows.Forms.TextBox textBoxSetSrvIP;
        private System.Windows.Forms.TextBox textBoxSetSrvPort;
        private System.Windows.Forms.Label labelShowServerIP;
        private System.Windows.Forms.Label labelShowServerPort;
        private System.Windows.Forms.Button buttonStartSrv;
        private System.Windows.Forms.Button buttonShutdownSrv;
        private System.Windows.Forms.PictureBox pictureBoxShowLogo;
    }
}

