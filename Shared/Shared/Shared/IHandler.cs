namespace Shared
{
	public interface IHandler
	{
		object Handle(object data);

		void SetSharedCommunication(object reference);
		void MulticastSendServiceData(object data);
	}
}
