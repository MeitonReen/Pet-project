using System.Net;
using System.Net.Sockets;

namespace Layer0_Client.Shared.Transceiver
{
	public class TCPListener : TCPTransceiverAbstract
	{
		private TcpListener Server = null;
		private TcpClient TCPClient = null;

		public TCPListener(string iP = "127.0.0.1", int port = 5000)
			: base(iP, port)
		{
			Server = new TcpListener(IPAddress.Parse(IP), Port);
			Server.Start();
		}

		public override void Close()
		{
			TCPClient.Close();
			TCPClient = null;
		}

		protected override NetworkStream GetStream()
		{
			if (TCPClient == null)
			{
				TCPClient = Server.AcceptTcpClient();
			}

			return TCPClient.GetStream();
		}
	}
}
