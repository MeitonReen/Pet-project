using System;
using System.Windows;

using Layer0_Client.CreatingOrder.Views;
using Layer0_Client.Shared.Create.Views;

namespace Layer0_Client.CreatingOrder.CreateViews
{
	public class CreateCreatingOrder : CreatorOfViewAbstract
	{
		protected override Window CreateView()
		{
			return new VCreatingOrder();
		}

		public override Type TypeOfCreationView()
		{
			return typeof(VCreatingOrder);
		}
	}
}
