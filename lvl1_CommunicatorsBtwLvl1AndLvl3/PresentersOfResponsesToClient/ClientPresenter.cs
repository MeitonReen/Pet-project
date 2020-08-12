
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Layer1_CommunicatorsBtwLvl1AndLvl3.
	InterfacesForReceiverOfResponsesToClient;
using Layer2_ApplicationUseCases.InterfacesForPresenters;
using Layer2_ApplicationUseCases.
	DataAboutClientRequest;
using Layer2_ApplicationUseCases.
	GatewayToDatabase;
using Layer1_CommunicatorsBtwLvl1AndLvl3.
	DataAboutResponsesToClientRequests;
using Layer2_ApplicationUseCases.
	TruncatedDataFromGatewayToDatabaseForLayer2.
	Shared;

namespace Layer1_CommunicatorsBtwLvl1AndLvl3.
	PresentersOfResponsesToClientRequests
{
	public class ClientPresenter : 
		IPresenterOfResponsesToClientRequest
	{
		private IReceiverOfResponsesToClient 
			ReceiverOfPresentedData = null;

		public ClientPresenter(
			IReceiverOfResponsesToClient receiverOfPresentedData)
		{
			ReceiverOfPresentedData = receiverOfPresentedData;
		}

		public void PresentAndSend(
			EnumClientRequests RequestID,
			object responseDataFromInteractor)
		{
			Clients Client = (Clients)responseDataFromInteractor;

			ClientLayer2 ResponseDataToReceiverOfPresentedData = 
				Present(Client);

			DataOfResponseToClient PackedResponseDataToReceiverOfPresentedData = 
				new DataOfResponseToClient();

			PackedResponseDataToReceiverOfPresentedData.ClientRequestID = RequestID;
			PackedResponseDataToReceiverOfPresentedData.ResponseData =
				ResponseDataToReceiverOfPresentedData;

			ReceiverOfPresentedData.Receive(PackedResponseDataToReceiverOfPresentedData);
		}

		private ClientLayer2 Present(
			Clients client)
		{
			ClientLayer2 ClientLayer2 = new ClientLayer2()
			{
				IDСlient = client.Idclient,
				FirstName = client.FirstName,
				LastName = client.LastName,
				Patronymic = client.Patronymic
			};

			return ClientLayer2;
		}
	}
}
