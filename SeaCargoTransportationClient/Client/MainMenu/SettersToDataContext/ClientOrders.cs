using System.Collections.ObjectModel;

using Layer0_Client.Shared.SettersToDataContext;
using Layer0_Client.MainMenu.DataContextForBindingsToWPF;
using SharedDTOsByClient.MainMenu;

namespace Layer0_Client.MainMenu.SettersToDataContext
{
	public class ClientOrders : AbstractSetterToDataContext
	{
		private DCMainMenu DCMainMenu = null;

		public ClientOrders(object dCMainMenu)
		{
			DCMainMenu = dCMainMenu as DCMainMenu;
		}
		protected override object SetToDataContext(object presentationData)
		{
			DCMainMenu.Orders =
				(ObservableCollection<OrderLayer0>)presentationData;

			return null;
		}
	}
}
