using System;
using System.Collections.Generic;

namespace Layer2_ApplicationUseCases.
	TruncatedDataFromGatewayToDatabaseForLayer2.
	GetClientOrders
{
	public class OrderOnFlightLayer2
	{
        public DateTime DateTimeOfFlight { get; set; }
		public string ShipNumber { get; set; }
		public List<string> StatusesFlight { get; set; }
	}
	
}
