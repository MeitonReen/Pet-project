
using Layer0_Client.
	InterfacesForProcessingDataContexts;
using Layer0_Client.DataContextsForBindings.MainMenu;
using Layer2_ApplicationUseCases.
	TruncatedDataFromGatewayToDatabaseForLayer2.
	Shared;

namespace Layer0_Client.ProcessingDataContexts.MainMenu
{
	public class SetDataOfClientToDCShowOrders : 
		ISetterToDataContextsFromResponseToClient
	{
		private DCMainMenu DCShowOrders = null;
		
		public SetDataOfClientToDCShowOrders(
			DCMainMenu dCShowOrders)
		{
			DCShowOrders = dCShowOrders;
		}

		public void Set(object data)
		{
			ClientLayer2 Client = (ClientLayer2)data;
			DCShowOrders.Client = Client;
		}
	}
}
