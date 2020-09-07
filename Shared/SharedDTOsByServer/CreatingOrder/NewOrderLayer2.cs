using System;
using System.Collections.Generic;

namespace SharedDTOsByServer.CreatingOrder
{
	[Serializable]
	public class NewOrderLayer2
	{
		public List<CargoLayer2> Cargos { get; set; }
		public FlightScheduleLayer2 SelectedFlight { get; set; }
	}
}
