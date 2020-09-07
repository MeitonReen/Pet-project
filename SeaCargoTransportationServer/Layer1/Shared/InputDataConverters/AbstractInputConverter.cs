using Layer2.Shared;
using Shared;

namespace Layer1.Shared.InputDataConverters
{
	public abstract class AbstractInputConverter : IHandler
	{
		protected abstract object Convert(object data);

		public object Handle(object data)
		{
			return Convert(data);
		}

		public void SetSharedCommunication(object reference)
		{
		}

		public void MulticastSendServiceData(object data)
		{
		}
	}
}
