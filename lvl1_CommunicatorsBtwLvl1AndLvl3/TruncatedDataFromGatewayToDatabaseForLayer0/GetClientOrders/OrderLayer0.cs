using System;
using System.Collections.ObjectModel;
using Layer2_ApplicationUseCases.
	TruncatedDataFromGatewayToDatabaseForLayer2.
	GetClientOrders;

namespace Layer1_CommunicatorsBtwLay0AndLay2.
	TruncatedDataFromGatewayToDatabaseForLayer0.
    GetClientOrders
{
	public class OrderLayer0
	{
		public int IDOrder { get; set; }
        public DateTime? DateTimeCreate { get; set; }
        public string ReceiptNumberOfOrder { get; set; }

        public ObservableCollection<CargoLayer2> Cargos { get; set; }
        public ObservableCollection<OrderOnFlightLayer0> OrderOnFligths { get; set; }
	}
}
