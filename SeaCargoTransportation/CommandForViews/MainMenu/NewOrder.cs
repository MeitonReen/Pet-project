
using Layer0_Client.CommandForViews.Shared;
using Layer2_ApplicationUseCases.DataAboutClientRequest;
using Layer0_Client.InterfacesForClientController;
using System.Windows;
using SeaCargoTransportation;

namespace Layer0_Client.CommandForViews.MainMenu
{
	public class NewOrder : WPFCommand
	{
		public override void Execute(object parameter)
		{
			(Application.Current as App).CreatingOrder(); 
		}
	}
}
