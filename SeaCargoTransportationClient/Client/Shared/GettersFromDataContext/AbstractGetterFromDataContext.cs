
using Shared;

namespace Layer0_Client.Shared.ClientPresenters
{
	public abstract class AbstractGetterFromDataContext : IHandler
	{

		protected abstract object GetFromDataContext();

		public object Handle(object data)
		{
			return GetFromDataContext();
		}

		public void SetSharedCommunication(object reference)
		{
		}

		public void MulticastSendServiceData(object data)
		{
		}
	}
}
