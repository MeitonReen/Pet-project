
using System.Collections.ObjectModel;

using Layer0_Client.InterfacesForProcessingDataContexts;
using Layer0_Client.DataContextsForBindings.CreateOrder;
using Layer2_ApplicationUseCases.
	TruncatedDataFromGatewayToDatabaseForLayer2.
	SetNewOrderInDatabase;

namespace Layer0_Client.ProcessingDataContexts.CreateOrder
{
	public class SetFlightScheduleToDCCreateOrder : 
		ISetterToDataContextsFromResponseToClient
	{
		private DCCreateOrder DCAttributesForCargos;

		public SetFlightScheduleToDCCreateOrder(
			DCCreateOrder dCAttributesForCargos)
		{
			DCAttributesForCargos = dCAttributesForCargos;
		}

		public void Set(object data)
		{
			ObservableCollection<FlightScheduleLayer2>
				ResponseData = (ObservableCollection<FlightScheduleLayer2>)data;

			DCAttributesForCargos.GettedFlightsSchedule.Clear();
			foreach(FlightScheduleLayer2 FlightSchedule in
				ResponseData)
			{
				DCAttributesForCargos.GettedFlightsSchedule.Add(
					FlightSchedule);
			}
			;
		}
	}
}
