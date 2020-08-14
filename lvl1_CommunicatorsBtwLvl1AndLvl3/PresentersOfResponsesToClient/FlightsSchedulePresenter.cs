
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Layer1_CommunicatorsBtwLvl1AndLvl3.
	InterfacesForReceiverOfResponsesToClient;
using Layer2_ApplicationUseCases.InterfacesForPresenters;
using Layer2_ApplicationUseCases.
	DataAboutClientRequest;
using Layer2_ApplicationUseCases.
	GatewayToDatabase;
using Layer2_ApplicationUseCases.
	TruncatedDataFromGatewayToDatabaseForLayer2.
	SetNewOrderInDatabase;
using Layer1_CommunicatorsBtwLvl1AndLvl3.
	DataAboutResponsesToClientRequests;

namespace Layer1_CommunicatorsBtwLvl1AndLvl3.
	PresentersOfResponsesToClientRequests
{
	public class FlightsSchedulePresenter : 
		IPresenterOfResponsesToClientRequest
	{
		private IReceiverOfResponsesToClient 
			ReceiverOfPresentedData = null;

		public FlightsSchedulePresenter(
			IReceiverOfResponsesToClient receiverOfPresentedData)
		{
			ReceiverOfPresentedData = receiverOfPresentedData;
		}

		public void PresentAndSend(
			EnumClientRequests RequestID,
			object responseDataFromInteractor)
		{
			List<FlightsSchedule> FlightsScheduleFromInteractor =
				(List<FlightsSchedule>)responseDataFromInteractor;

			ObservableCollection<FlightScheduleLayer2> 
				ResponseDataToReceiverOfPresentedData = 
					Present(FlightsScheduleFromInteractor);

			DataOfResponseToClient PackedResponseDataToReceiverOfPresentedData = 
				new DataOfResponseToClient();

			PackedResponseDataToReceiverOfPresentedData.ClientRequestID = RequestID;
			PackedResponseDataToReceiverOfPresentedData.ResponseData =
				ResponseDataToReceiverOfPresentedData;

			ReceiverOfPresentedData.Receive(PackedResponseDataToReceiverOfPresentedData);
		}

		private ObservableCollection<FlightScheduleLayer2> Present(
			List<FlightsSchedule> FlightsScheduleFromInteractor)
		{
			ObservableCollection<FlightScheduleLayer2> PresentationData =
				new ObservableCollection<FlightScheduleLayer2>();

			foreach (FlightsSchedule FlightSchedule in
				FlightsScheduleFromInteractor)
			{
				FlightScheduleLayer2 PresentationDataItem =
					new FlightScheduleLayer2();

				PresentationDataItem.IDShips =
					FlightSchedule.Idships;
				PresentationDataItem.DateTimeOfFlight =
					FlightSchedule.DateTimeOfFlight;
				PresentationDataItem.IsSelected = false;

				PresentationData.Add(PresentationDataItem);
			}

			return PresentationData;
		}

	}
}