using System;
using System.Collections.Generic;

namespace SharedDTOsByServer.MainMenu
{
	[Serializable]
	public class OrderOnFlightLayer2
	{
		public DateTime DateTimeOfFlight { get; set; }
		public string ShipNumber { get; set; }
		public List<string> StatusesFlight { get; set; }
	}

}
