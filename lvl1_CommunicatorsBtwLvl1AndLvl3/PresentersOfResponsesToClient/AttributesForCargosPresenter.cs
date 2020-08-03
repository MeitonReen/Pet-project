
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Layer1_CommunicatorsBtwLvl1AndLvl3.
	InterfacesForReceiversDataPresentation;
using Layer2_ApplicationUseCases.InterfacesForPresenters;
using Layer2_ApplicationUseCases.
	DataAboutClientRequest;
using Layer2_ApplicationUseCases.
	GatewayToDatabase;
using Layer1_CommunicatorsBtwLvl1AndLvl3.
	TruncatedDataFromGatewayToDatabaseForResponsesToClient;
using Layer1_CommunicatorsBtwLvl1AndLvl3.
	DataAboutResponsesToClientRequests;

namespace Layer1_CommunicatorsBtwLvl1AndLvl3.
	PresentersOfResponsesToClientRequests
{
	public class AttributesForCargosPresenter : IPresenterOfResponsesToClientRequest
	{
		private IReceiverOfResponsesToClientRequests 
			ReceiverOfPresentedData = null;

		public AttributesForCargosPresenter(
			IReceiverOfResponsesToClientRequests receiverOfPresentedData)
		{
			ReceiverOfPresentedData = receiverOfPresentedData;
		}

		public void PresentAndSend(
			EnumClientRequests RequestID,
			object responseDataFromInteractor)
		{
			List<AttributesForCargos> AttributesForCargosFromInteractor =
				(List<AttributesForCargos>)responseDataFromInteractor;

			ObservableCollection<AttributeForCargo> ResponseDataToReceiverOfPresentedData = 
				Present(AttributesForCargosFromInteractor);

			DataOfResponseToClient PackedResponseDataToReceiverOfPresentedData = 
				new DataOfResponseToClient();

			PackedResponseDataToReceiverOfPresentedData.ClientRequestID = RequestID;
			PackedResponseDataToReceiverOfPresentedData.ResponseData =
				ResponseDataToReceiverOfPresentedData;

			ReceiverOfPresentedData.Receive(PackedResponseDataToReceiverOfPresentedData);
		}

		private ObservableCollection<AttributeForCargo> Present(
			List<AttributesForCargos> attributesForCargosFromInteractor)
		{
			ObservableCollection<AttributeForCargo> PresentationData =
				new ObservableCollection<AttributeForCargo>();

			foreach (AttributesForCargos AttributesForCargos in
				attributesForCargosFromInteractor)
			{
				AttributeForCargo PresentationDataItem =
					new AttributeForCargo();

				PresentationDataItem.IdattributesForCargos =
					AttributesForCargos.IdattributesForCargos;
				PresentationDataItem.Name =
					AttributesForCargos.Name;

				PresentationData.Add(PresentationDataItem);
			}

			return PresentationData;
		}

	}
}
