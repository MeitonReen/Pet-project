using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace Layer0_Client.Shared.Transceiver
{
	public abstract class TCPTransceiverAbstract : ITransceiver
	{
		private BinaryFormatter BF = null;

		protected string IP = "127.0.0.1";
		protected int Port = 5000;

		public void Send(object data)
		{
			CreateBF();
			BF.Serialize(GetStream(), data);
		}
		public object Receive()
		{
			CreateBF();
			object ReceivedData = BF.Deserialize(GetStream());

			return ReceivedData;
		}

		public void Stop()
		{
			BF = null;
			Close();
		}

		public TCPTransceiverAbstract(string iP = "127.0.0.1", int port = 5000)
		{
			IP = iP;
			Port = port;
		}
		private void CreateBF()
		{
			if (BF == null)
			{
				BF = new BinaryFormatter();
			}
		}

		protected abstract NetworkStream GetStream();
		public abstract void Close();
	}
}
