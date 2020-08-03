
using Layer1_CommunicatorsBtwLvl1AndLvl3.
	DataAboutResponsesToClientRequests;

namespace Layer1_CommunicatorsBtwLvl1AndLvl3.
	InterfacesForReceiversDataPresentation
{
	public interface IReceiverOfResponsesToClientRequests
	{
		public void Receive(DataOfResponseToClient ResponseData);
	}
}
