
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Layer1.Shared.PresentersOfDataToOutput;
using SharedDTOsByClient.MainMenu;
using SharedDTOsByServer.MainMenu;

namespace Layer1.MainMenu.PresentersOfDataToOutput
{
	public class GetClientOrdersPresenter : AbstractPresenterOfDataToOutput
	{
		protected override object Present(object data)
		{
			List<OrderLayer2> Orders = (List<OrderLayer2>)data;

			ObservableCollection<OrderLayer0> OrdersOut = new
				ObservableCollection<OrderLayer0>();

			foreach (OrderLayer2 Order in Orders)
			{
				OrderLayer0 OrderOut = new OrderLayer0();
				OrderOut.IDOrder = Order.IDOrder;
				OrderOut.DateTimeCreate = Order.DateTimeCreate;
				OrderOut.ReceiptNumberOfOrder = Order.ReceiptNumberOfOrder;

				OrderOut.Cargos = new ObservableCollection<CargoLayer2>(
					Order.Cargos);

				ObservableCollection<OrderOnFlightLayer0> OrderOnFlightsOut =
					new ObservableCollection<OrderOnFlightLayer0>();

				foreach (OrderOnFlightLayer2 OrderOnFlight in Order.OrderOnFligths)
				{
					OrderOnFlightLayer0 OrderOnFlightOut = new OrderOnFlightLayer0();
					OrderOnFlightOut.ShipNumber = OrderOnFlight.ShipNumber;
					OrderOnFlightOut.DateTimeOfFlight = OrderOnFlight.DateTimeOfFlight;

					OrderOnFlightOut.StatusesFlight =
						new ObservableCollection<string>(OrderOnFlight.StatusesFlight);

					OrderOnFlightsOut.Add(OrderOnFlightOut);
				}

				OrderOut.OrderOnFligths = OrderOnFlightsOut;

				OrdersOut.Add(OrderOut);
			}

			return OrdersOut;
		}
	}
}
