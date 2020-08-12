using System;
using System.Collections.Generic;
using System.Text;
using Layer2_ApplicationUseCases.
	InterfacesForStatesOfInteractors;
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

namespace Layer2_ApplicationUseCases.Interactors.ClientOrders.Steps
{
	public class StepTwo_GetClientOrders : IExecutorOfClientRequest
	{
		private SeaCargoTransportationContext Database =
			new SeaCargoTransportationContext();
		private ClientLayer2 Client = null;
		private IPresenterOfResponsesToClientRequest Presenter = null;

		public StepTwo_GetClientOrders(
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
			List<Orders> ClientOrders = 
				Database.Orders.Where(Order =>
					Order.Idclient == Client.IDСlient).ToList();

			object Result = ClientOrders;
			Presenter.PresentAndSend(RequestID, Result);

			return true;
		}
	}
}
