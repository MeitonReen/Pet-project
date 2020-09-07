using System;

namespace SharedDTOsByServer.CreatingOrder
{
	[Serializable]
	public class FlightScheduleLayer2
	{
		public DateTime DateTimeOfFlight { get; set; }
		public int IDShips { get; set; }
		public bool IsSelected { get; set; }
	}
}
