
using Layer1_CommunicatorsBtwLvl1AndLvl3.ControllerOfClientRequests;
using Layer1_CommunicatorsBtwLvl1AndLvl3.
	InterfacesForReceiverOfResponsesToClient;
using Layer1_CommunicatorsBtwLvl1AndLvl3.
	InterfacesForControllerOfClientRequests;
using Layer2_ApplicationUseCases.
	DataAboutClientRequest;
using Layer2_ApplicationUseCases.
	Interactors.
	CreatingOrder;
using Layer1_CommunicatorsBtwLvl1AndLvl3.
	PresentersOfResponsesToClientRequests;
using Layer2_ApplicationUseCases.
	TruncatedDataFromGatewayToDatabaseForLayer2.
	Shared;
using Layer2_ApplicationUseCases.Interactors.ClientOrders;

namespace Layer1_CommunicatorsBtwLay0AndLay2.CreatorLay1
{
	public class CreatorLay1
	{
		private ControllerOfClientRequests ClientRequestsToApplication = null;
		private IReceiverOfResponsesToClient ReceiverDataOfClientCommands = null;
		private ClientLayer2 Client;

		private CreatingOrder CreatingOrder = null;
		private AttributesForCargosPresenter AttributesForCargosPresenter = null;

		private ClientOrders ClientOrders = null;
		private ClientPresenter ClientPresenter = null;
		private ClientOrdersPresenter ClientOrdersPresenter = null;


		public CreatorLay1(ClientLayer2 client)
		{
			ClientRequestsToApplication =
				new ControllerOfClientRequests();

			Client = client;
		}

		private void Create_CreateOrder()
		{
			AttributesForCargosPresenter =
				new AttributesForCargosPresenter(ReceiverDataOfClientCommands);
			CreatingOrder = new CreatingOrder(
				Client,
				AttributesForCargosPresenter);

			ClientRequestsToApplication.RegistrationOfRequest(
				EnumClientRequests.CreatingOrder_GetAttributeForCargos,
				CreatingOrder);

			ClientRequestsToApplication.RegistrationOfRequest(
				EnumClientRequests.CreatingOrder_SetCargosInOrders,
				CreatingOrder);
		}
		private void Create_ClientOrders()
		{
			ClientPresenter = new ClientPresenter(ReceiverDataOfClientCommands);
			ClientOrdersPresenter = new ClientOrdersPresenter(ReceiverDataOfClientCommands);

			ClientOrders = new ClientOrders(
				Client,
				ClientPresenter,
				ClientOrdersPresenter);

			ClientRequestsToApplication.RegistrationOfRequest(
				EnumClientRequests.Get_ClientData,
				ClientOrders);
			ClientRequestsToApplication.RegistrationOfRequest(
				EnumClientRequests.Get_ClientOrders,
				ClientOrders);
		}

		public void LinkToReceiverDataOfClientCommands(
			IReceiverOfResponsesToClient receiverDataOfClientCommands)
		{
			ReceiverDataOfClientCommands = receiverDataOfClientCommands;
			
			Create_CreateOrder();
			Create_ClientOrders();
		}

		public IReceiverDataOfClientRequests 
			GetReceiverDataOfClientRequest()
		{
			return ClientRequestsToApplication;
		}
	}
}
