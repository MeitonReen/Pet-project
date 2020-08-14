using System;
using System.Collections.Generic;
using System.Text;

namespace Layer2_ApplicationUseCases.
	TruncatedDataFromGatewayToDatabaseForLayer2.
	SetNewOrderInDatabase
{
	public class CargosIntoFlightLayer2
	{
		public List<CargoLayer2> Cargos { get; set; }
		public FlightScheduleLayer2 FlightSchedule { get; set; }
	}
}
