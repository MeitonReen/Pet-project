namespace Layer0_Client.Shared
{
	public interface ITransceiver
	{
		object Receive();
		void Send(object data);
		void Stop();
	}
}
