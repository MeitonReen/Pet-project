
using System.Windows;
using System.Threading;

using Layer0_Client.MainMenu.Views;
using Layer0_Client.CreatingOrder.Views;
using Layer0_Client.Shared.Create.Views;

namespace SeaCargoTransportation
{

	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			new FactoryOfViews().CreateShowAndGoToNewView("VAuthentification"); 
		}
	}
}
