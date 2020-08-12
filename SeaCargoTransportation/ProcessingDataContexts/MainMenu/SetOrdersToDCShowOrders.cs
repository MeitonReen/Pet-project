
using System.Collections.ObjectModel;
using Layer0_Client.
	InterfacesForProcessingDataContexts;
using Layer0_Client.DataContextsForBindings.MainMenu;
using Layer1_CommunicatorsBtwLay0AndLay2.
	TruncatedDataFromGatewayToDatabaseForLayer0;

namespace Layer0_Client.ProcessingDataContexts.MainMenu
{
	public class SetOrdersToDCShowOrders :
		ISetterToDataContextsFromResponseToClient
	{
		private DCMainMenu DCShowOrders = null;
		
		public SetOrdersToDCShowOrders(
			DCMainMenu dCShowOrders)
		{
			DCShowOrders = dCShowOrders;
		}

		public void Set(object data)
		{
			ObservableCollection<OrderLayer0> Orders =
			(ObservableCollection<OrderLayer0>)data;

			DCShowOrders.Orders.Clear();
			foreach(OrderLayer0 Order in Orders)
			{
				DCShowOrders.Orders.Add(Order);
			}
		}
	}
}
