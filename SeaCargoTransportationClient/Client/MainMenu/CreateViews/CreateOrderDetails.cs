using System;
using System.Windows;

using Layer0_Client.MainMenu.Views;
using Layer0_Client.Shared.Create.Views;

namespace Layer0_Client.CreatingOrder.CreateViews
{
	public class CreateOrderDetails : CreatorOfViewAbstract
	{
		protected override Window CreateView()
		{
			return new VOrderDetails();
		}
		public override Type TypeOfCreationView()
		{
			return typeof(VOrderDetails);
		}
	}
}
