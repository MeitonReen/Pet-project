namespace Layer1.Shared
{
	public interface ITransceiver
	{
		object Receive();
		void Send(object data);
		void Stop();
	}
}
