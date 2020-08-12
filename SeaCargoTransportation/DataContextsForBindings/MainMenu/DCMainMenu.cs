using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;

using Layer1_CommunicatorsBtwLay0AndLay2.
	TruncatedDataFromGatewayToDatabaseForLayer0;
using Layer2_ApplicationUseCases.
	TruncatedDataFromGatewayToDatabaseForLayer2.
	Shared;
using Layer0_Client.CommandForViews.MainMenu;

namespace Layer0_Client.DataContextsForBindings.MainMenu
{
	public class DCMainMenu : INotifyPropertyChanged
	{
		public ObservableCollection<OrderLayer0> Orders { get; set; } =
			new ObservableCollection<OrderLayer0>();

		private ClientLayer2 _Client = null;
		public ClientLayer2 Client 
		{
			get
			{
				return _Client;
			}
			set
			{
				_Client = value;
				OnPropertyChanged("Client");
			}
		}

		private GetClientDataAndClientOrders Comm_GetClientDataAndClientOrders = new
			GetClientDataAndClientOrders();
		public ICommand GetClientDataAndClientOrders
		{
			get
			{
				return Comm_GetClientDataAndClientOrders;
			}
		}

		public void OnPropertyChanged(string prop)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}
		public event PropertyChangedEventHandler PropertyChanged;
	}
}
