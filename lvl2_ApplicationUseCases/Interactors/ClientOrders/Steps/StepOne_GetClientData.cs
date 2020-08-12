using System;
using System.Collections.Generic;
using System.Linq;

using Layer2_ApplicationUseCases.
	InterfacesForStatesOfInteractors;
using Layer2_ApplicationUseCases.
	GatewayToDatabase.
	Context;

using Layer2_ApplicationUseCases.
	TruncatedDataFromGatewayToDatabaseForLayer2.
	Shared;
using Layer2_ApplicationUseCases.GatewayToDatabase;
using Layer2_ApplicationUseCases.InterfacesForPresenters;
using Layer2_ApplicationUseCases.DataAboutClientRequest;

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
			Client = client;
			Presenter = presenter;
		}

		public void ClearRequest()
		{
			throw new NotImplementedException();
		}

		public bool Execute(EnumClientRequests RequestID, object dataOfClientRequest)
		{
			Clients Client = Database.Clients.FirstOrDefault(Client =>
				Client.Idclient == this.Client.IDСlient);
				//Database.Clients.Where(GetClient =>
				//	GetClient.Idclient == this.Client.IDСlient).ToList();
			
			object Result = Client;
			Presenter.PresentAndSend(RequestID, Result);

			return true;
		}
	}
}
