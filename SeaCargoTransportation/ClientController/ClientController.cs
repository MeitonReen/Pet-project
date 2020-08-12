
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
using Layer2_ApplicationUseCases.
    TruncatedDataFromGatewayToDatabaseForLayer2.
    Shared;

namespace Layer0_Client.ClientController
{
	public class ClientController : 
		ISenderOfClientRequestsToApplication, IReceiverOfResponsesToClient
	{
		private ClientLayer2 Client;

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
			SynchronizationContext synchronizationContext,
			ClientLayer2 client)
		{
			ReceiverDataOfClientRequest = receiverDataOfClientRequest;
			SynchronizationContext = synchronizationContext;
			Client = client;
		}
		public void Send(EnumClientRequests clientRequest)
		{
			DataOfClientRequest NewClientRequest = new DataOfClientRequest();
			NewClientRequest.RequestID = clientRequest;

			if (GettersFromDataContextForClientRequest.ContainsKey(clientRequest))
			{
				NewClientRequest.DataForExecutorClientRequests = 
				GettersFromDataContextForClientRequest[clientRequest].
					Get();
			}
			else
			{
				NewClientRequest.DataForExecutorClientRequests = null;
			}

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
