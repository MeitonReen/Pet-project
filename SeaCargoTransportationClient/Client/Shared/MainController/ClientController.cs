using System.Collections.Generic;
using System.Threading;

using Layer0_Client.Shared.Create.ClientPresenters;
using Layer0_Client.Shared.Create.SettersToDataContext;
using SharedDTOs.DataAboutClientRequests;
using Shared.Dictionary;
using Shared.Transceiver;
using Shared;

namespace Layer0_Client.Shared.MainController
{
	public class ClientController
	{
		private DictionaryOfHandlers<EnumClientRequests> GettersFromDataContext = null;
		private DictionaryOfHandlers<EnumClientRequests> SettersToDataContext = null;
		private ITransceiver Transceiver = null;
		private SynchronizationContext WPFThread = null;

		public ClientController(
			SynchronizationContext wPFThread,
			object dataContext,
			params EnumClientRequests[] clientRequestsIDs)
		{
			WPFThread = wPFThread;

			GettersFromDataContext = (new GettersFactory(dataContext)).
				CreateGettersByClientRequestsIDs(clientRequestsIDs);
			SettersToDataContext = 
				(new SettersToDataContextFactory(dataContext)).
					CreateSettersByClientRequestsIDs(clientRequestsIDs);
			Transceiver = new TCPConnector();
		}

		public void Request(params EnumClientRequests[] clientRequests)
		{
			//Новая сессия
			KeyValuePair<EnumClientRequests, object>[] PreparedClientRequests =
				GetDataForClientRequests(clientRequests);

			foreach(KeyValuePair<EnumClientRequests, object> ClientRequest in
				PreparedClientRequests)
			{
				Transceiver.Send(ClientRequest);

				object DataReceived = Transceiver.Receive();
				ProcessingDataReceived(DataReceived);

				Transceiver.Stop();
			}
		}

		private KeyValuePair<EnumClientRequests, object>[] GetDataForClientRequests(
			EnumClientRequests[] clientRequests)
		{
			List<KeyValuePair<EnumClientRequests, object>> ClientRequests =
				new List<KeyValuePair<EnumClientRequests, object>>();

			foreach(EnumClientRequests ClientRequest in clientRequests)
			{
				ClientRequests.Add(
					GettersFromDataContext.HandleWithoutKeyInto_WithKeyOut(
						new KeyValuePair<EnumClientRequests, object>(ClientRequest, null))
				);
			}
			return ClientRequests.ToArray();
		}

		private void ProcessingDataReceived(object dataReceived)
		{
			WPFThread.Post(obj =>
				SettersToDataContext.
				HandleWithoutKeyInto_WithKeyOut(
					(KeyValuePair<EnumClientRequests, object>)obj),
					dataReceived);
		}
	}
}
