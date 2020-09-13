using System;
using System.Collections.Generic;
using System.Linq;

using Layer2.Shared.GatewayToDatabase;
using Layer2.Shared.GatewayToDatabase.Context;
using Layer2.Shared.Interactors;

namespace Layer2.CreatingOrder.Interactors
{
	public class GetFlightsSchedule : InteractorAbstract
	{
		public override object Execute(object dataFromInputConverter)
		{
			using (SeaCargoTransportationContext Database = GetDataBase())
			{
				List<FlightsSchedule> FlightsSchedule =
					Database?.FlightsSchedule.Where(FlightSchedule =>
						FlightSchedule.DateTimeOfFlight >= DateTime.Now).ToList();
				
				return FlightsSchedule;
			}
		}

		public override void SetDefault()
		{
		}
	}
}
