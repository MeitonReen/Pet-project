
using System.Collections.ObjectModel;
using Layer0_Client.
	InterfacesForProcessingDataContexts;
using Layer0_Client.DataContextsForBindings.MainMenu;
using Layer1_CommunicatorsBtwLay0AndLay2.
	TruncatedDataFromGatewayToDatabaseForLayer0.
	GetClientOrders;

namespace Layer0_Client.ProcessingDataContexts.MainMenu
{
	public class SetOrdersToDCMainMenu :
		ISetterToDataContextsFromResponseToClient
	{
		private DCMainMenu DCMainMenu = null;
		
		public SetOrdersToDCMainMenu(
			DCMainMenu dCMainMenu)
		{
			DCMainMenu = dCMainMenu;
		}

		public void Set(object data)
		{
			ObservableCollection<OrderLayer0> Orders =
			(ObservableCollection<OrderLayer0>)data;

			DCMainMenu.Orders.Clear();
			foreach(OrderLayer0 Order in Orders)
			{
				DCMainMenu.Orders.Add(Order);
			}
			;
		}
	}
}
