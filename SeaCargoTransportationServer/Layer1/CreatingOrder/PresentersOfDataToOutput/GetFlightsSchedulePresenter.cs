using System.Collections.Generic;
using System.Collections.ObjectModel;

using Layer1.Shared.PresentersOfDataToOutput;
using SharedDTOsByServer.CreatingOrder;
using Layer2.Shared.GatewayToDatabase;

namespace Layer1.CreatingOrder.PresentersOfDataToOutput
{
	public class GetFlightsSchedulePresenter : AbstractPresenterOfDataToOutput
	{

		protected override object Present(object data)
		{
			List<FlightsSchedule> FlightsScheduleFromInteractor =
				(List<FlightsSchedule>)data;

			ObservableCollection<FlightScheduleLayer2> PresentationData =
				new ObservableCollection<FlightScheduleLayer2>();

			foreach (FlightsSchedule FlightSchedule in
				FlightsScheduleFromInteractor)
			{
				FlightScheduleLayer2 PresentationDataItem =
					new FlightScheduleLayer2()
					{
						IDShips = FlightSchedule.Idships,
						DateTimeOfFlight = FlightSchedule.DateTimeOfFlight,
						IsSelected = false
					};

				PresentationData.Add(PresentationDataItem);
			}

			return PresentationData;
		}

	}
}