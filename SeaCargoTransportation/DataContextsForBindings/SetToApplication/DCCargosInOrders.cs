
using System.Collections.ObjectModel;
using Layer2_ApplicationUseCases.
	TruncatedDataFromGatewayToDatabaseForRequestsFromClient.
	SetNewOrderInDatabase;
namespace Layer0_Client.DataContextsForBindings
{
	public class DCCargosInOrders
	{
		public ObservableCollection<Cargo> Cargos { get; set; } = 
			new ObservableCollection<Cargo>();
	}
}
