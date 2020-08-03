
using System;
using System.Collections.Generic;
using System.Threading;

using Layer1_CommunicatorsBtwLvl1AndLvl3.
	InterfacesForReceiversDataPresentation;
using Layer1_CommunicatorsBtwLvl1AndLvl3.
	InterfacesForControllerOfClientRequests;
using Layer2_ApplicationUseCases.
	DataAboutClientRequest;
using Layer0_Client.
	InterfacesForViews;
using Layer1_CommunicatorsBtwLvl1AndLvl3.
	DataAboutResponsesToClientRequests;
using Layer0_Client.
	InterfacesForProcessingDataContexts;

namespace Layer0_Client.ClientController
{
	class ClientController : IReceiverOfResponsesToClientRequests
	{
		private IReceiverDataOfClientRequest ReceiverDataOfClientRequest;
		
		private Dictionary<EnumClientRequests,
			ISetterToDataContextsFromResponseToClient> 
			DataContextsForApplicationResponsesToClient =
				new Dictionary<EnumClientRequests, 
					ISetterToDataContextsFromResponseToClient>();

		private  Dictionary<EnumClientRequests, 
			IGetterFromDataContextForClientRequest> 
			DataContextsForSendClientRequestsToApplication =
				new Dictionary<EnumClientRequests, 
					IGetterFromDataContextForClientRequest>();

		private ICreatingOrder CreatingOrder = null;
		private SynchronizationContext SynchronizationContext;

		public ClientController(
			IReceiverDataOfClientRequest receiverDataOfClientRequest,
			ICreatingOrder creatingOrder,
			SynchronizationContext synchronizationContext)
		{
			ReceiverDataOfClientRequest = receiverDataOfClientRequest;
			CreatingOrder = creatingOrder;
			SynchronizationContext = synchronizationContext;

			CreatingOrder.GetAttributeForCargos += Send;
		}
//!
		private void Send(object sender, EventArgs e)
		{
			
			DataOfClientRequest NewClientRequest = new DataOfClientRequest();
			NewClientRequest.RequestID = EnumClientRequests.CreatingOrder_GetAttributeForCargos;
			NewClientRequest.DataForExecutorClientRequests = null;

			ReceiverDataOfClientRequest.Receive(NewClientRequest);
		}
//!

		public void LinkViewCreatingOrderAndClientRequest(
			EnumClientRequests clientRequest,
			ICreatingOrder creatingOrder)
		{
			creatingOrder.GetAttributeForCargos += (sender, e) =>
			{
				DataOfClientRequest NewClientRequest = new DataOfClientRequest();
				NewClientRequest.RequestID = 
					EnumClientRequests.CreatingOrder_GetAttributeForCargos;
				NewClientRequest.DataForExecutorClientRequests = null;

				ReceiverDataOfClientRequest.Receive(NewClientRequest);
			};
		}

		public void RegistrationDataContextsForApplicationResponsesToClient(
			EnumClientRequests requestID, 
			ISetterToDataContextsFromResponseToClient dataContext)
		{
			DataContextsForApplicationResponsesToClient.Add(requestID, 
				dataContext);
		}

		public void RegistrationDataContextsForSendClientRequestsToApplication(
			EnumClientRequests requestID, 
			IGetterFromDataContextForClientRequest dataContext)
		{
			DataContextsForSendClientRequestsToApplication.Add(requestID, 
				dataContext);
		}

		private void DelegateReceiveToWPF(object data)
		{
			DataOfResponseToClient DataOfResponseToClient = 
				(DataOfResponseToClient)data;

			ISetterToDataContextsFromResponseToClient SetterToDC =
				DataContextsForApplicationResponsesToClient[
					DataOfResponseToClient.ClientRequestID];
			
			SetterToDC.Set(DataOfResponseToClient.ResponseData);
		}

		public void Receive(DataOfResponseToClient 
			dataOfResponseToClient)
		{
			object Data = dataOfResponseToClient;
			SynchronizationContext.Post(DelegateReceiveToWPF, Data);
		}
	}
}
