using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TalkCli
{
    public partial class MainForm : Form
    {
		CliCore cliMain = new CliCore();
		public static MainForm mainForm = null;

		public MainForm()
        {
            InitializeComponent();
			mainForm = this;
        }
		private void buttonSendMsg_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBoxSetSendName.Text)) cliMain.SendMsg(textBoxMsgToSend.Text);
			else
			{
				cliMain.SendMsgToUser(textBoxMsgToSend.Text, textBoxSetSendName.Text);
			}
		}

		private void buttonConnectSrv_Click(object sender, EventArgs e)
		{
			cliMain.ConnectSrv(textBoxSetSrvIP.Text, textBoxSetSrvPort.Text);
			return;
		}

		private void buttonCloseConnectionToSrv_Click(object sender, EventArgs e)
		{
			cliMain.CloseSrvConnection();
			return;
		}

		private delegate void GiveMsgCallback(string msg);
		public void GiveMsg(string msg)
		{
			msg = msg + '\n';
			if (this.textBoxShowMsg.InvokeRequired)
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
