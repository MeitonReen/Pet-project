using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;

using Layer0_Client.CommandForViews.Shared;
using Layer0_Client.Views;
using SeaCargoTransportation;

namespace Layer0_Client.CommandForViews.Authentification
{
	public class AuthentificationApp : WPFCommand
	{
		public override void Execute(object parameter)
		{
			(Application.Current as App).Authentification();
		}
	}
}
