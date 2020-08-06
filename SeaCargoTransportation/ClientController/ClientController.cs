
using System.Collections.Generic;
using System.Threading;

using Layer1_CommunicatorsBtwLvl1AndLvl3.
	InterfacesForReceiverOfResponsesToClient;
using Layer1_CommunicatorsBtwLvl1AndLvl3.
	InterfacesForControllerOfClientRequests;
using Layer2_ApplicationUseCases.
	DataAboutClientRequest;
using Layer1_CommunicatorsBtwLvl1AndLvl3.
	DataAboutResponsesToClientRequests;
using Layer0_Client.
	InterfacesForProcessingDataContexts;
using Layer0_Client.
	InterfacesForClientController;

namespace Layer0_Client.ClientController
{
	public class ClientController : 
		ISenderOfClientRequestsToApplication, IReceiverOfResponsesToClient
	{
		private IReceiverDataOfClientRequests ReceiverDataOfClientRequest;
		
		private Dictionary<EnumClientRequests,
			ISetterToDataContextsFromResponseToClient> 
			SettersToDataContextsFromResponseToClient =
				new Dictionary<EnumClientRequests, 
					ISetterToDataContextsFromResponseToClient>();

		private  Dictionary<EnumClientRequests, 
			IGetterFromDataContextForClientRequest> 
			GettersFromDataContextForClientRequest =
				new Dictionary<EnumClientRequests, 
					IGetterFromDataContextForClientRequest>();

		private SynchronizationContext SynchronizationContext;

		public ClientController(
			IReceiverDataOfClientRequests receiverDataOfClientRequest,
			SynchronizationContext synchronizationContext)
		{
			ReceiverDataOfClientRequest = receiverDataOfClientRequest;
			
			SynchronizationContext = synchronizationContext;

		}
		public void Send(EnumClientRequests clientRequest)
		{
			DataOfClientRequest NewClientRequest = new DataOfClientRequest();
			NewClientRequest.RequestID = clientRequest;
			NewClientRequest.DataForExecutorClientRequests = 
				GettersFromDataContextForClientRequest[clientRequest].
					Get();

			ReceiverDataOfClientRequest.Receive(NewClientRequest);
		}

		public void RegistrationSettersToDataContextsFromResponseToClient(
			EnumClientRequests requestID, 
			ISetterToDataContextsFromResponseToClient setter)
		{
			SettersToDataContextsFromResponseToClient.Add(requestID, 
				setter);
		}

		public void RegistrationGettersFromDataContextForClientRequest(
			EnumClientRequests requestID, 
			IGetterFromDataContextForClientRequest getter)
		{
			GettersFromDataContextForClientRequest.Add(requestID, 
				getter);
		}

		private void DelegateReceiveToWPF(object data)
		{
			DataOfResponseToClient DataOfResponseToClient = 
				(DataOfResponseToClient)data;

			ISetterToDataContextsFromResponseToClient SetterToDC =
				SettersToDataContextsFromResponseToClient[
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
