using System;
using System.Linq;

using Layer0_Client.MainMenu.DataContextForBindingsToWPF;
using Layer0_Client.Shared.ClientPresenters;

namespace Layer0_Client.MainMenu.GettersFromDataContext
{
	public class SetOrderCancel : AbstractGetterFromDataContext
	{
		DCMainMenu DCMainMenu = null;

		public SetOrderCancel(object dCMainMenu)
		{
			DCMainMenu = dCMainMenu as DCMainMenu;
		}

		protected override object GetFromDataContext()
		{
			int? IDOrder = (DCMainMenu.Orders.FirstOrDefault(OrderLayer0 =>
				OrderLayer0.IsSelected))?.IDOrder;

			return IDOrder;
		}
	}
}
