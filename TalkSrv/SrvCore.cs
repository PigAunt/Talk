using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace TalkSrv
{
    class SrvCore
    {
		Thread threadSrvListen = null;
		Socket socketSrvListen = null;
		Dictionary<string, Socket> dicSocket = new Dictionary<string, Socket>();
		Dictionary<string, Thread> dicThread = new Dictionary<string, Thread>();

		public void StartSrv(String srvIP, string srvPort, int srvQueueSize)
		{
			socketSrvListen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			IPAddress srvAddr = null;
			IPEndPoint srvEndPoint = null;
			try
			{
				srvAddr = IPAddress.Parse(srvIP);
				srvEndPoint = new IPEndPoint(srvAddr, int.Parse(srvPort));
			}
			catch (SocketException ex)
			{
				ReportMsg("创建服务器套接字地址时出现异常: " + ex.Message);
				return;
			}
			catch (Exception ex)
			{
				ReportMsg("创建服务器套接字地址时出现异常: " + ex.Message);
				return;
			}
			try
			{
				socketSrvListen.Bind(srvEndPoint);
			}
			catch (SocketException ex)
			{
				ReportMsg("绑定服务器IP时出现异常: " + ex.Message);
				return;
			}
			catch (Exception ex)
			{
				ReportMsg("绑定服务器IP时出现异常: " + ex.Message);
				return;
			}
			socketSrvListen.Listen(srvQueueSize);
			threadSrvListen = new Thread(WatchConnection);
			threadSrvListen.IsBackground = true;
			threadSrvListen.Start();
			ReportMsg("服务器成功启动");
			return;
		}

		public void ShutdownSrv()
		{
			bool flgAbort = true;
			threadSrvListen.Abort();
			socketSrvListen.Close();
			foreach (Thread tmpThread in dicThread.Values)
			{
				try
				{
					tmpThread.Abort();
				}
				catch (ThreadStateException ex)
				{
					ReportMsg("关闭服务器线程时出现异常: " + ex.Message);
					flgAbort = false;
					break;
				}
				catch (Exception ex)
				{
					ReportMsg("关闭服务器线程时出现异常: " + ex.Message);
					flgAbort = false;
					break;
				}
			}
			foreach (Socket tmpSocket in dicSocket.Values)
			{
				try
				{
					tmpSocket.Close();
				}
				catch (ThreadStateException ex)
				{
					ReportMsg("关闭服务器套接字时出现异常: " + ex.Message);
					flgAbort = false;
					break;
				}
				catch (Exception ex)
				{
					ReportMsg("关闭服务器套接字时出现异常: " + ex.Message);
					flgAbort = false;
					break;
				}
			}
			if (flgAbort == true)
				ReportMsg("服务器成功关闭.");
			else ReportMsg("服务器无法关闭.");
			return;
		}

		public void WatchConnection()
		{
			while (true)
			{
				Socket socketConnection = null;
				try
				{
					socketConnection = socketSrvListen.Accept();
				}
				catch (SocketException ex)
				{
					ReportMsg("连接客户端时出现异常: " + ex.Message);
					break;
				}
				catch (Exception ex)
				{
					ReportMsg("连接客户端时出现异常: " + ex.Message);
					break;
				}
				dicSocket.Add(socketConnection.RemoteEndPoint.ToString(), socketConnection);
				Thread threadCommunicate = new Thread(ReceiveMsg);
				threadCommunicate.IsBackground = true;
				threadCommunicate.Start(socketConnection);
				dicThread.Add(socketConnection.RemoteEndPoint.ToString(), threadCommunicate);
				ReportMsg(string.Format("{0}于{1}上线.", socketConnection.RemoteEndPoint.ToString(), DateTime.Now));
			}
			return;
		}

		public void SendMsgToUser(string msg, string userToSend)
		{
			msg = msg.Trim();
			byte[] arrSendMsg = Encoding.UTF8.GetBytes(msg);
			try
			{
				dicSocket[userToSend].Send(arrSendMsg);
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
			return;
		}

		public void SendMsg(string msg)
		{
			bool flgSend = false;
			msg = msg.Trim();
			byte[] arrSendMsg = Encoding.UTF8.GetBytes(msg);
			foreach (Socket tmpSocket in dicSocket.Values)
			{
				try
				{
					tmpSocket.Send(arrSendMsg);
					flgSend = true;
				}
				catch (SocketException ex)
				{
					ReportMsg("发送信息时出现异常: " + ex.Message);
					break;
				}
				catch (Exception ex)
				{
					ReportMsg("发送信息时出现异常: " + ex.Message);
					break;
				}
			}
			if(flgSend==true)
				ReportMsg(string.Format("向所有人发送了消息: {0}.", msg));
		}

		public void ReceiveMsg(object socketClientPara)
		{
			Socket socketCli = socketClientPara as Socket;
			while (true)
			{
				byte[] arrRevMsg = new byte[1024 * 1024];
				int lthArrRevMsg = 0;
				try
				{
					lthArrRevMsg = socketCli.Receive(arrRevMsg);
				}
				catch (SocketException ex)
				{
					ReportMsg("与客户端 " + socketCli.RemoteEndPoint + " 通信时出现异常: " + ex.Message);
					dicSocket.Remove(socketCli.RemoteEndPoint.ToString());
					dicThread.Remove(socketCli.RemoteEndPoint.ToString());
					break;
				}
				catch (Exception ex)
				{
					ReportMsg("与客户端通信时出现异常: " + ex.Message);
					break;
				}
				string cliRevMsg = Encoding.UTF8.GetString(arrRevMsg, 0, lthArrRevMsg);
				string userToSend = null;
				foreach (Match match in Regex.Matches(cliRevMsg, @"(\S+)_(\S+)"))
				{
					userToSend = match.Groups[1].Value;
					cliRevMsg = match.Groups[2].Value;
				}
				switch(userToSend)
				{
					case "ALL":SendMsg(cliRevMsg);break;
					default:SendMsgToUser(cliRevMsg, userToSend);break;
				}
				ReportMsg(string.Format("{0}@{1}: {2}.", socketCli.RemoteEndPoint.ToString(), DateTime.Now, cliRevMsg));
			}
			return;
		}

		void ReportMsg(string msg)
		{
			MainForm.mainForm.GiveMsg(msg);
			return;
		}
	}
}
