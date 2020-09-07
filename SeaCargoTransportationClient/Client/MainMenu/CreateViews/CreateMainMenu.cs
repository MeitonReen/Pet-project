using System;
using System.Windows;

using Layer0_Client.MainMenu.Views;
using Layer0_Client.Shared.Create.Views;

namespace Layer0_Client.CreatingOrder.CreateViews
{
	public class CreateMainMenu : CreatorOfViewAbstract
	{
		protected override Window CreateView()
		{
			return new VMainMenu();
		}
		public override Type TypeOfCreationView()
		{
			return typeof(VMainMenu);
		}
	}
}
