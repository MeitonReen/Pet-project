
using Layer1_CommunicatorsBtwLvl1AndLvl3.
	DataAboutResponsesToClientRequests;

namespace Layer1_CommunicatorsBtwLvl1AndLvl3.
	InterfacesForReceiverOfResponsesToClient
{
	public interface IReceiverOfResponsesToClient
	{
		public void Receive(DataOfResponseToClient ResponseData);
	}
}
