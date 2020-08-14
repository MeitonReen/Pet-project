
using System.Collections.Generic;

using Layer2_ApplicationUseCases.
	InterfacesForStatesOfInteractors;
using Layer2_ApplicationUseCases.GatewayToDatabase;
using Layer2_ApplicationUseCases.GatewayToDatabase.Context;
using Layer2_ApplicationUseCases.
	TruncatedDataFromGatewayToDatabaseForLayer2.
	SetNewOrderInDatabase;
using Layer2_ApplicationUseCases.
	TruncatedDataFromGatewayToDatabaseForLayer2.
	Shared;
using System;
using Layer2_ApplicationUseCases.DataAboutClientRequest;
using System.Linq;
using Layer2_ApplicationUseCases.InterfacesForPresenters;


namespace Layer2_ApplicationUseCases.Interactors.CreatingOrder.States
{
	public class StepThree_GetFlightsSchedule : IExecutorOfClientRequest
	{
		private SeaCargoTransportationContext Database =
			new SeaCargoTransportationContext();

		private IPresenterOfResponsesToClientRequest Presenter = null;

		public StepThree_GetFlightsSchedule(
			IPresenterOfResponsesToClientRequest presenter)
		{
			Presenter = presenter;
		}

		public void ClearRequest()
		{
			//Скорее всего придётся Database освобождать, или раньше
		}

		public bool Execute(EnumClientRequests RequestID, object dataOfClientRequest)
		{
			List<FlightsSchedule> FlightsSchedule =
				Database.FlightsSchedule.Where(FlightSchedule =>
					FlightSchedule.DateTimeOfFlight >= DateTime.Now).ToList();
			
			object Result = FlightsSchedule;
			Presenter.PresentAndSend(RequestID, Result);

			return true;
		}
	}
}
