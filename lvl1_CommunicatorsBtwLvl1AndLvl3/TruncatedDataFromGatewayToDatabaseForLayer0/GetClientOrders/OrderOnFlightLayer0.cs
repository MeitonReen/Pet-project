﻿using System;
using System.Collections.ObjectModel;

namespace Layer1_CommunicatorsBtwLay0AndLay2.
	TruncatedDataFromGatewayToDatabaseForLayer0.
    GetClientOrders
{
	public class OrderOnFlightLayer0
	{
        public DateTime DateTimeOfFlight { get; set; }
		public string ShipNumber { get; set; }
		public ObservableCollection<string> StatusesFlight { get; set; }
	}
	
}
