using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TalkSrv
{
	public partial class MainForm : Form
    {
		SrvCore srvMain = new SrvCore();
		public static MainForm mainForm =null;

        public MainForm()
        {
            InitializeComponent();
			mainForm = this;
        }
		private void buttonSendMsg_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBoxSetSendName.Text)) srvMain.SendMsg(textBoxMsgToSend.Text);
			else srvMain.SendMsgToUser(textBoxMsgToSend.Text, textBoxSetSendName.Text);
		}

		private void buttonStartSrv_Click(object sender, EventArgs e)
		{
			srvMain.StartSrv(textBoxSetSrvIP.Text, textBoxSetSrvPort.Text, 10);
			return;
		}

		private void buttonShutdownSrv_Click(object sender, EventArgs e)
		{
			srvMain.ShutdownSrv();
			return;
		}

		public delegate void GiveMsgCallback(string msg);
		public void GiveMsg(string msg)
		{
			msg = msg + '\n';
			if (textBoxShowMsg.InvokeRequired)
			{
				GiveMsgCallback d = new GiveMsgCallback(GiveMsg);
				this.Invoke(d, new object[] { msg });
			}
			else
			{
				textBoxShowMsg.AppendText(msg);
			}
			return;
		}
	}
}
