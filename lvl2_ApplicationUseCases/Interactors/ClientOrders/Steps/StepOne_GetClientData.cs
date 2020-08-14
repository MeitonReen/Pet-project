using System;
using System.Collections.Generic;

using Layer2_ApplicationUseCases.
	GatewayToDatabase.
	Context;
using Layer2_ApplicationUseCases.
	TruncatedDataFromGatewayToDatabaseForLayer2.
	Shared;
using System.Linq;
using Layer2_ApplicationUseCases.GatewayToDatabase;
using Layer2_ApplicationUseCases.InterfacesForPresenters;
using Layer2_ApplicationUseCases.DataAboutClientRequest;
using Layer2_ApplicationUseCases.
	TruncatedDataFromGatewayToDatabaseForLayer2.
	GetClientOrders;
using Layer2_ApplicationUseCases.
	InterfacesForStatesOfInteractors;

namespace Layer2_ApplicationUseCases.Interactors.ClientOrders.Steps
{
	public class StepOne_GetClientData : IExecutorOfClientRequest
	{
		private SeaCargoTransportationContext Database =
			new SeaCargoTransportationContext();
		private ClientLayer2 Client = null;
		private IPresenterOfResponsesToClientRequest Presenter = null;

		public StepOne_GetClientData(
			ClientLayer2 client,
			IPresenterOfResponsesToClientRequest presenter)
		{
		//Клиент указан временно
			Client = client;
			Presenter = presenter;
		}

		public void ClearRequest()
		{
			throw new NotImplementedException();
		}

		public bool Execute(EnumClientRequests RequestID, object dataOfClientRequest)
		{
			Clients Client =
				Database.Clients.FirstOrDefault(Client =>
					Client.Idclient == this.Client.IDСlient);
					
			object Result = Client;
			Presenter.PresentAndSend(RequestID, Result);

			return true;
		}
	}
}
