
using Layer2_ApplicationUseCases.
	DataAboutClientRequest;

namespace Layer1_CommunicatorsBtwLvl1AndLvl3.
	InterfacesForControllerOfClientRequests
{
	public interface IReceiverDataOfClientRequest
	{
		public int Receive(DataOfClientRequest _dataClientRequest);
	}
}
