using Layer2.Shared;
using Shared;

namespace Layer1.Shared.PresentersOfDataToOutput
{
	public abstract class AbstractPresenterOfDataToOutput :
		IPresentersOfDataToOutput, IHandler
	{
		public object PresentAndSend(object data)
		{
			return Present(data);
		}

		public object Handle(object data)
		{
			return PresentAndSend(data); ;
		}

		protected abstract object Present(object data);

		public void SetSharedCommunication(object reference)
		{
		}

		public void MulticastSendServiceData(object data)
		{
		}
	}
}
