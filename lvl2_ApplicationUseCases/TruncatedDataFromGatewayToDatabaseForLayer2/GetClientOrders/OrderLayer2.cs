using System;
using Layer2_ApplicationUseCases.GatewayToDatabase;
using System.Collections.Generic;


namespace Layer2_ApplicationUseCases.
	TruncatedDataFromGatewayToDatabaseForLayer2.
	GetClientOrders
{
	public class OrderLayer2
	{
		public int IDOrder { get; set; }
        public DateTime? DateTimeCreate { get; set; }
        public string ReceiptNumberOfOrder { get; set; }

        public List<CargoLayer2> Cargos { get; set; }
        public List<OrderOnFlightLayer2> OrderOnFligths { get; set; }
	}
}
