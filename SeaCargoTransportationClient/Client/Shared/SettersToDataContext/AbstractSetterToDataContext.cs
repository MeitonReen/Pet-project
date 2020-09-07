using Shared;

namespace Layer0_Client.Shared.SettersToDataContext
{
	public abstract class AbstractSetterToDataContext : IHandler
	{
		public object Handle(object data)
		{
			return SetToDataContext(data);
		}

		public void MulticastSendServiceData(object data)
		{
		}

		public void SetSharedCommunication(object reference)
		{
		}

		protected abstract object SetToDataContext(object presentationData);
	}
}
