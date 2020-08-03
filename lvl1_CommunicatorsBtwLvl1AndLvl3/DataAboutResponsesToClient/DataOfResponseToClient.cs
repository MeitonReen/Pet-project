
using Layer2_ApplicationUseCases.
	DataAboutClientRequest;

namespace Layer1_CommunicatorsBtwLvl1AndLvl3.
	DataAboutResponsesToClientRequests
{
	public class DataOfResponseToClient
	{
		public EnumClientRequests ClientRequestID { get; set; }
		public object ResponseData { get; set; }
	}
}
