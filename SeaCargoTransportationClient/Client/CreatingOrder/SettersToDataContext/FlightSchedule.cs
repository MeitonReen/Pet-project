
using System.Threading;
using System.Collections.ObjectModel;

using Layer0_Client.Shared.SettersToDataContext;
using Layer0_Client.CreatingOrder.DataContextForBindingsToWPF;
using SharedDTOsByServer.CreatingOrder;

namespace Layer0_Client.CreatingOrder.SettersToDataContext
{
	public class FlightSchedule : AbstractSetterToDataContext
	{
		private DCCreatingOrder DCCreatingOrder = null;

		public FlightSchedule(object dCCreateOrder)
		{
			DCCreatingOrder = dCCreateOrder as DCCreatingOrder;
		}
		protected override object SetToDataContext(object presentationData)
		{
			DCCreatingOrder.GettedFlightsSchedule =
				(ObservableCollection<FlightScheduleLayer2>)presentationData;

			return null;
		}
	}
}
