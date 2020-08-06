
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Layer1_CommunicatorsBtwLvl1AndLvl3.
	InterfacesForReceiverOfResponsesToClient;
using Layer2_ApplicationUseCases.InterfacesForPresenters;
using Layer2_ApplicationUseCases.
	DataAboutClientRequest;
using Layer2_ApplicationUseCases.
	GatewayToDatabase;
using Layer1_CommunicatorsBtwLay0AndLay2.
	TruncatedDataFromGatewayToDatabaseForLayer0;
using Layer1_CommunicatorsBtwLvl1AndLvl3.
	DataAboutResponsesToClientRequests;

namespace Layer1_CommunicatorsBtwLvl1AndLvl3.
	PresentersOfResponsesToClientRequests
{
	public class AttributesForCargosPresenter : 
		IPresenterOfResponsesToClientRequest
	{
		private IReceiverOfResponsesToClient 
			ReceiverOfPresentedData = null;

		public AttributesForCargosPresenter(
			IReceiverOfResponsesToClient receiverOfPresentedData)
		{
			ReceiverOfPresentedData = receiverOfPresentedData;
		}

		public void PresentAndSend(
			EnumClientRequests RequestID,
			object responseDataFromInteractor)
		{
			List<AttributesForCargos> AttributesForCargosFromInteractor =
				(List<AttributesForCargos>)responseDataFromInteractor;

			ObservableCollection<AttributeForCargoLayer0> ResponseDataToReceiverOfPresentedData = 
				Present(AttributesForCargosFromInteractor);

			DataOfResponseToClient PackedResponseDataToReceiverOfPresentedData = 
				new DataOfResponseToClient();

			PackedResponseDataToReceiverOfPresentedData.ClientRequestID = RequestID;
			PackedResponseDataToReceiverOfPresentedData.ResponseData =
				ResponseDataToReceiverOfPresentedData;

			ReceiverOfPresentedData.Receive(PackedResponseDataToReceiverOfPresentedData);
		}

		private ObservableCollection<AttributeForCargoLayer0> Present(
			List<AttributesForCargos> attributesForCargosFromInteractor)
		{
			ObservableCollection<AttributeForCargoLayer0> PresentationData =
				new ObservableCollection<AttributeForCargoLayer0>();

			foreach (AttributesForCargos AttributesForCargos in
				attributesForCargosFromInteractor)
			{
				AttributeForCargoLayer0 PresentationDataItem =
					new AttributeForCargoLayer0();

				PresentationDataItem.IdattributesForCargos =
					AttributesForCargos.IdattributesForCargos;
				PresentationDataItem.Name =
					AttributesForCargos.Name;
				PresentationDataItem.IsSelected = false;

				PresentationData.Add(PresentationDataItem);
			}

			return PresentationData;
		}

	}
}
