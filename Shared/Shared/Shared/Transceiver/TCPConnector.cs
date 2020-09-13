using System.Net.Sockets;

namespace Shared.Transceiver
{
	public class TCPConnector : TCPTransceiverAbstract
	{
		private TcpClient TCPClient = null;

		public TCPConnector(string iP = "127.0.0.1", int port = 5000)
			: base(iP, port)
		{ }

		public override void Close()
		{
			TCPClient.Close();
			TCPClient = null;
		}
		protected override NetworkStream GetStream()
		{
			if (TCPClient == null)
			{
				TCPClient = new TcpClient(IP, Port);
			}

			return TCPClient.GetStream();
		}
	}
}
