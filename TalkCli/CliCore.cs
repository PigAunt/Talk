using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TalkCli
{
    class CliCore
    {
		Thread threadCliConnect = null;
		Socket socketCliConnect = null;

		public void ConnectSrv(String srvIP, string srvPort)
		{
			socketCliConnect = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			IPAddress srvAddr = null;
			IPEndPoint srvEndPoint = null;
			try
			{
				srvAddr = IPAddress.Parse(srvIP);
				srvEndPoint = new IPEndPoint(srvAddr, int.Parse(srvPort));
			}
			catch (SocketException ex)
			{
				ReportMsg("创建客户端套接字地址时出现异常: " + ex.Message);
				return;
			}
			catch (Exception ex)
			{
				ReportMsg("创建客户端套接字地址时出现异常: " + ex.Message);
				return;
			}
			try
			{
				socketCliConnect.Connect(srvEndPoint);
			}
			catch (SocketException ex)
			{
				ReportMsg("连接服务器时出现异常: " + ex.Message);
				ReportMsg("无法连接到服务器");
				return;
			}
			catch (Exception ex)
			{
				ReportMsg("连接服务器时出现异常: " + ex.Message);
				ReportMsg("无法连接到服务器");
				return;
			}
			threadCliConnect = new Thread(ReceiveMsg);
			threadCliConnect.IsBackground = true;
			threadCliConnect.Start();
			ReportMsg("成功连接到服务器");
			return;
		}

		public void CloseSrvConnection()
		{
			threadCliConnect.Abort();
			ReportMsg("成功关闭连接");
			return;
		}

		public void SendMsgToUser(string msg,string userToSend)
		{
			msg = msg.Trim();
			msg = userToSend + "_" + msg;
			byte[] arrSendMsg = Encoding.UTF8.GetBytes(msg);
			try
			{
				socketCliConnect.Send(arrSendMsg);
				ReportMsg(string.Format("向{0}发送了消息: {1}.", userToSend, msg));
			}
			catch (SocketException ex)
			{
				ReportMsg("发送信息时出现异常: " + ex.Message);
				return;
			}
			catch (Exception ex)
			{
				ReportMsg("发送信息时出现异常: " + ex.Message);
				return;
			}
		}

		public void SendMsg(string msg)
		{
			msg = msg.Trim();
			byte[] arrSendMsg = null;
			try
			{
				ReportMsg(string.Format("向{0}发送了消息: {1}.", socketCliConnect.RemoteEndPoint.ToString(), msg));
				msg = "ALL" + "_" + msg;
				arrSendMsg = Encoding.UTF8.GetBytes(msg);
				socketCliConnect.Send(arrSendMsg);
			}
			catch (SocketException ex)
			{
				ReportMsg("发送信息时出现异常: " + ex.Message);
				return;
			}
			catch (Exception ex)
			{
				ReportMsg("发送信息时出现异常: " + ex.Message);
				return;
			}
		}

		public void ReceiveMsg()
		{
			while (true)
			{
				byte[] arrRevMsg = new byte[1024 * 1024];
				int lthArrRevMsg = -1;
				try
				{
					lthArrRevMsg = socketCliConnect.Receive(arrRevMsg);
				}
				catch (SocketException ex)
				{
					ReportMsg("与客户端 " + socketCliConnect.RemoteEndPoint + " 通信时出现异常: " + ex.Message);
					break;
				}
				catch (Exception ex)
				{
					ReportMsg("与客户端通信时出现异常: " + ex.Message);
					break;
				}
				string cliRevMsg = Encoding.UTF8.GetString(arrRevMsg, 0, lthArrRevMsg);
				ReportMsg(string.Format("{0}@{1}: {2}.", socketCliConnect.RemoteEndPoint.ToString(), DateTime.Now, cliRevMsg));
			}
			return;
		}

		private void ReportMsg(string msg)
		{
			MainForm.mainForm.GiveMsg(msg);
			return;
		}
	}
}
