
using Layer2_ApplicationUseCases.
	DataAboutClientRequest;

namespace Layer0_Client.InterfacesForClientController
{
	public interface ISenderOfClientRequestsToApplication
	{
		void Send(EnumClientRequests clientRequest);
	}
}
