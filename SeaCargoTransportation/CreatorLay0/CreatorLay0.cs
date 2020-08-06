using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using Layer1_CommunicatorsBtwLvl1AndLvl3.
	InterfacesForControllerOfClientRequests;
using Layer0_Client.ProcessingDataContexts.CreateOrder;
using Layer0_Client.DataContextsForBindings.CreateOrder;
using Layer0_Client.
	ClientController;
using Layer0_Client.InterfacesForClientController;
using Layer1_CommunicatorsBtwLvl1AndLvl3.
	InterfacesForReceiverOfResponsesToClient;
using Layer2_ApplicationUseCases.
	DataAboutClientRequest;
using Layer0_Client.CommandForViews.Shared;

namespace Layer0_Client.CreatorLay0
{
	public class CreatorLay0
	{
		private ClientController.ClientController ClientController;
		private IReceiverDataOfClientRequests ReceiverDataOfClientRequest;
		private SynchronizationContext SynchronizationContext;
		private DCCreateOrder DCCreateOrder;


		public CreatorLay0(
			IReceiverDataOfClientRequests receiverDataOfClientRequest,
			SynchronizationContext synchronizationContext,
			DCCreateOrder dCCreateOrder
		)
		{
			ReceiverDataOfClientRequest = receiverDataOfClientRequest;
			SynchronizationContext = synchronizationContext;
			DCCreateOrder = dCCreateOrder;

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
				SynchronizationContext);

			InitializeProcessingDataContext_CreateOrder();
			LinkClientControllerToSendClientRequests();
		}

		private void LinkClientControllerToSendClientRequests()
		{
			SendClientRequest SendClientRequest =
				(DCCreateOrder.SendRequestGetAttributesForCargos as
					SendClientRequest);

			SendClientRequest.LinkToSenderOfClientRequestsToApplication(
				ClientController);		
		}

		private void InitializeProcessingDataContext_CreateOrder()
		{
			GetFromCargosInOrder GetFromClientCargosInOrders =
					new GetFromCargosInOrder(DCCreateOrder);
			GetAttributesForCargoFromCargosInOrder 
				GetFromClientAttributesForCargos =
					new GetAttributesForCargoFromCargosInOrder(DCCreateOrder);
			SetAttributesForCargoToCargosInOrder
				SetToClientAttributesForCargos =
					new SetAttributesForCargoToCargosInOrder(DCCreateOrder);

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
		}
			
	}
}
