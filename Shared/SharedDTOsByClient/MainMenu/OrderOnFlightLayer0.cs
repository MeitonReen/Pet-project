using System;
using System.Collections.ObjectModel;

namespace SharedDTOsByClient.MainMenu
{
	[Serializable]
	public class OrderOnFlightLayer0
	{
		public DateTime DateTimeOfFlight { get; set; }
		public string ShipNumber { get; set; }
		public ObservableCollection<string> StatusesFlight { get; set; }
	}

}
