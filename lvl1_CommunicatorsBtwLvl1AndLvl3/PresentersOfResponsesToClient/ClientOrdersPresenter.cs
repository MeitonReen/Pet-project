
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Layer1_CommunicatorsBtwLvl1AndLvl3.
	InterfacesForReceiverOfResponsesToClient;
using Layer2_ApplicationUseCases.InterfacesForPresenters;
using Layer2_ApplicationUseCases.
	DataAboutClientRequest;
using Layer2_ApplicationUseCases.
	GatewayToDatabase;
using Layer1_CommunicatorsBtwLay0AndLay2.
	TruncatedDataFromGatewayToDatabaseForLayer0;
using Layer1_CommunicatorsBtwLvl1AndLvl3.
	DataAboutResponsesToClientRequests;
using Layer2_ApplicationUseCases.
	TruncatedDataFromGatewayToDatabaseForLayer2.
	GetClientOrders;
using Layer1_CommunicatorsBtwLay0AndLay2.
	TruncatedDataFromGatewayToDatabaseForLayer0.
	GetClientOrders;
using System.Linq;

namespace Layer1_CommunicatorsBtwLvl1AndLvl3.
	PresentersOfResponsesToClientRequests
{
	public class ClientOrdersPresenter : 
		IPresenterOfResponsesToClientRequest
	{
		private IReceiverOfResponsesToClient 
			ReceiverOfPresentedData = null;

		public ClientOrdersPresenter(
			IReceiverOfResponsesToClient receiverOfPresentedData)
		{
			ReceiverOfPresentedData = receiverOfPresentedData;
		}

		public void PresentAndSend(
			EnumClientRequests RequestID,
			object responseDataFromInteractor)
		{
			
			List<OrderLayer2> ClientOrders =
				(List<OrderLayer2>)responseDataFromInteractor;

			ObservableCollection<OrderLayer0> ResponseDataToReceiverOfPresentedData = 
				Present(ClientOrders);

			DataOfResponseToClient PackedResponseDataToReceiverOfPresentedData = 
				new DataOfResponseToClient();

			PackedResponseDataToReceiverOfPresentedData.ClientRequestID = RequestID;
			PackedResponseDataToReceiverOfPresentedData.ResponseData =
				ResponseDataToReceiverOfPresentedData;

			ReceiverOfPresentedData.Receive(PackedResponseDataToReceiverOfPresentedData);
		}

		private ObservableCollection<OrderLayer0> Present(
			List<OrderLayer2> Orders)
		{
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
