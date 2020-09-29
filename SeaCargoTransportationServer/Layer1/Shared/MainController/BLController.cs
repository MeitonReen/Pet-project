using System;
using System.Collections.Generic;

using Layer1.Shared.PresentersOfDataToOutput;
using Layer2.Shared.Interactors;
using Shared;
using Shared.Dictionary;
using Shared.Transceiver;
using SharedDTOs.DataAboutClientRequests;

namespace Layer1.Shared.MainController
{
	public class BLController
	{
		private DictionaryOfHandlers<EnumClientRequests> Interactors = null;
		private DictionaryOfHandlers<EnumClientRequests> PresentersOfDataToOutput = null;
		private ITransceiver Transceiver = null;

		private bool BServerStart = false;
		public event EventHandler<bool> ChangeServerStatus;

		public BLController()
		{
			Interactors = new InteractorsFactory().CreateInteractors();
			PresentersOfDataToOutput =
				new PresentersOfDataToOutputFactory().CreatePresenters();
			Transceiver = new TCPListener();
		}

		public void ServerStop()
		{
			BServerStart = false;
			ChangeServerStatus?.Invoke(this, false);
		}

		public void ServerStart()
		{
			BServerStart = true;
			ChangeServerStatus?.Invoke(this, true);
			do
			{
				//Новая сессия
				object ReceivedData = Transceiver.Receive();

				object DataToSender = ProcessingDataReceived(ReceivedData);

				Transceiver.Send(DataToSender);
				Transceiver.Stop();
			}
			while (BServerStart);
		}

		private object ProcessingDataReceived(object dataReceived)
		{
			KeyValuePair<EnumClientRequests, object> ReceivedRequests =
				(KeyValuePair<EnumClientRequests, object>)dataReceived;

			KeyValuePair<EnumClientRequests, object> DataToPresenters =
				Interactors.HandleWithKeyInto_WithKeyOut(ReceivedRequests);

			KeyValuePair<EnumClientRequests, object> DataToSenderOutput =
				PresentersOfDataToOutput.HandleWithoutKeyInto_WithKeyOut(DataToPresenters);

			return DataToSenderOutput;
		}
	}
}
