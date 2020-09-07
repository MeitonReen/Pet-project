using System;
using System.Windows;

using Layer0_Client.Authentification.Views;
using Layer0_Client.Shared.Create.Views;

namespace Layer0_Client.CreatingOrder.CreateViews
{
	public class CreateAuthentification : CreatorOfViewAbstract
	{
		protected override Window CreateView()
		{
			return new VAuthentification();
		}
		public override Type TypeOfCreationView()
		{
			return typeof(VAuthentification);
		}
	}
}
