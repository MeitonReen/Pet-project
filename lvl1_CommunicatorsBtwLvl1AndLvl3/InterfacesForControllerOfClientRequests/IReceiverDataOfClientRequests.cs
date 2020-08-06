
using Layer2_ApplicationUseCases.
	DataAboutClientRequest;

namespace Layer1_CommunicatorsBtwLvl1AndLvl3.
	InterfacesForControllerOfClientRequests
{
	public interface IReceiverDataOfClientRequests
	{
		public int Receive(DataOfClientRequest _dataClientRequest);
	}
}
