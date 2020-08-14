
using System.Threading;

using Layer1_CommunicatorsBtwLvl1AndLvl3.
	InterfacesForControllerOfClientRequests;
using Layer0_Client.ProcessingDataContexts.CreateOrder;
using Layer0_Client.DataContextsForBindings.CreateOrder;
using Layer0_Client.DataContextsForBindings.MainMenu;
using Layer1_CommunicatorsBtwLvl1AndLvl3.
	InterfacesForReceiverOfResponsesToClient;
using Layer2_ApplicationUseCases.
	DataAboutClientRequest;
using Layer0_Client.CommandForViews.Shared;
using Layer2_ApplicationUseCases.
    TruncatedDataFromGatewayToDatabaseForLayer2.
    Shared;
using Layer0_Client.CommandForViews.MainMenu;
using Layer0_Client.ProcessingDataContexts.MainMenu;
using Layer0_Client.CommandForViews.CreateOrder;

namespace Layer0_Client.CreatorLay0
{
	public class CreatorLay0
	{
		private ClientController.ClientController ClientController;
		private IReceiverDataOfClientRequests ReceiverDataOfClientRequest;
		private SynchronizationContext SynchronizationContext;
		private DCCreateOrder DCCreateOrder;
		private DCMainMenu DCMainMenu;
		private ClientLayer2 Client;

		public CreatorLay0(
			IReceiverDataOfClientRequests receiverDataOfClientRequest,
			SynchronizationContext synchronizationContext,
			DCCreateOrder dCCreateOrder,
			DCMainMenu dCMainMenu,
			ClientLayer2 client
		)
		{
			ReceiverDataOfClientRequest = receiverDataOfClientRequest;
			SynchronizationContext = synchronizationContext;
			DCCreateOrder = dCCreateOrder;
			Client = client;
			DCMainMenu = dCMainMenu;

			Create();
		}
		public IReceiverOfResponsesToClient
			GetReceiverOfResponsesToClient()
		{
			return ClientController;
		}
		private void Create()
		{
			ClientController = new ClientController.ClientController(
				ReceiverDataOfClientRequest,
				SynchronizationContext,
				Client);

			InitializeProcessingDataContext_CreateOrder();
			InitializeProcessingDataContext_ClientOrders();

			LinkClientControllerToSendClientRequests();
		}
		private void InitializeProcessingDataContext_ClientOrders()
		{
			SetDataOfClientToDCMainMenu SetDataOfClientToDCShowOrders = new
				SetDataOfClientToDCMainMenu(DCMainMenu);
			SetOrdersToDCMainMenu SetOrdersToDCShowOrders = new
				SetOrdersToDCMainMenu(DCMainMenu);

			ClientController.RegistrationSettersToDataContextsFromResponseToClient(
				EnumClientRequests.Get_ClientData,
				SetDataOfClientToDCShowOrders);
			ClientController.RegistrationSettersToDataContextsFromResponseToClient(
				EnumClientRequests.Get_ClientOrders,
				SetOrdersToDCShowOrders);
		}

		private void LinkClientControllerToSendClientRequests()
		{
			//Костылюшка, убрать как можно быстрее
			if (DCCreateOrder != null)
			{
				Initialize Initialize =
					(DCCreateOrder.InitializeCreateOrder as
						Initialize);
				Initialize.LinkToSenderOfClientRequestsToApplication(
					ClientController);

				SendClientRequest SendClientRequest =
					(DCCreateOrder.SendRequestSetCargosInOrders as
						SendClientRequest);
				SendClientRequest.LinkToSenderOfClientRequestsToApplication(
					ClientController);
			}
			if (DCMainMenu != null)
			{
				GetClientDataAndClientOrders GetClientDataAndClientOrders =
					(DCMainMenu.GetClientDataAndClientOrders as GetClientDataAndClientOrders);
				GetClientDataAndClientOrders.LinkToSenderOfClientRequestsToApplication(
					ClientController);
			}
		}

		private void InitializeProcessingDataContext_CreateOrder()
		{
			GetCargosFromDCCreateOrder GetFromClientCargosInOrders =
					new GetCargosFromDCCreateOrder(DCCreateOrder);
			GetAttributesForCargoFromDCCreateOrder 
				GetFromClientAttributesForCargos =
					new GetAttributesForCargoFromDCCreateOrder(DCCreateOrder);
			SetAttributesForCargoToDCCreateOrder
				SetToClientAttributesForCargos =
					new SetAttributesForCargoToDCCreateOrder(DCCreateOrder);
			SetFlightScheduleToDCCreateOrder
				SetFlightScheduleToDCCreateOrder =
					new SetFlightScheduleToDCCreateOrder(DCCreateOrder);

			ClientController.
			RegistrationGettersFromDataContextForClientRequest(
				EnumClientRequests.CreatingOrder_GetAttributeForCargos,
				GetFromClientAttributesForCargos);
			ClientController.
			RegistrationGettersFromDataContextForClientRequest(
				EnumClientRequests.CreatingOrder_SetCargosInOrders,
				GetFromClientCargosInOrders);
			ClientController.
			RegistrationSettersToDataContextsFromResponseToClient(
				EnumClientRequests.CreatingOrder_GetAttributeForCargos,
				SetToClientAttributesForCargos);
			ClientController.
			RegistrationSettersToDataContextsFromResponseToClient(
				EnumClientRequests.CreatingOrder_GetFligthsSchedule,
				SetFlightScheduleToDCCreateOrder);
		}
			
	}
}
