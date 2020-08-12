
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
			List<Orders> Orders =
				(List<Orders>)responseDataFromInteractor;

			ObservableCollection<OrderLayer0> ResponseDataToReceiverOfPresentedData = 
				Present(Orders);

			DataOfResponseToClient PackedResponseDataToReceiverOfPresentedData = 
				new DataOfResponseToClient();

			PackedResponseDataToReceiverOfPresentedData.ClientRequestID = RequestID;
			PackedResponseDataToReceiverOfPresentedData.ResponseData =
				ResponseDataToReceiverOfPresentedData;

			ReceiverOfPresentedData.Receive(PackedResponseDataToReceiverOfPresentedData);
		}

		private ObservableCollection<OrderLayer0> Present(
			List<Orders> Orders)
		{
			ObservableCollection<OrderLayer0> PresentationData =
				new ObservableCollection<OrderLayer0>();

			foreach (Orders Order in
				Orders)
			{
				OrderLayer0 PresentationDataItem =
					new OrderLayer0()
					{
						IDOrder = Order.Idorder,
						IDClient = Order.Idclient,
						DateTimeCreate = Order.DateTimeCreate,
						ReceiptNumberOfOrder = Order.ReceiptNumberOfOrder,
						IsSelected = false
					};

				PresentationData.Add(PresentationDataItem);
			}

			return PresentationData;
		}

	}
}
