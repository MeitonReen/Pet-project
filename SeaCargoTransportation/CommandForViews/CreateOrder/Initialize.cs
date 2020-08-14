
using Layer0_Client.CommandForViews.Shared;
using Layer2_ApplicationUseCases.DataAboutClientRequest;
using Layer0_Client.InterfacesForClientController;

namespace Layer0_Client.CommandForViews.CreateOrder
{
	public class Initialize : WPFCommand
	{
		private SendClientRequest SendRequestGetAttributesForCargos = new
			SendClientRequest(EnumClientRequests.CreatingOrder_GetAttributeForCargos);
		private SendClientRequest SendRequestGetFlightsShedule = new
			SendClientRequest(EnumClientRequests.CreatingOrder_GetFligthsSchedule);

		public void LinkToSenderOfClientRequestsToApplication(
			ISenderOfClientRequestsToApplication
				senderClientRequestsToApplication)
		{
			SendRequestGetAttributesForCargos.
				LinkToSenderOfClientRequestsToApplication(
					senderClientRequestsToApplication);

			SendRequestGetFlightsShedule.
				LinkToSenderOfClientRequestsToApplication(
					senderClientRequestsToApplication);
		}
		public override void Execute(object parameter)
		{
			if (SendRequestGetAttributesForCargos.CanExecute(null))
			{
				SendRequestGetAttributesForCargos.Execute(null);
			}
			if (SendRequestGetFlightsShedule.CanExecute(null))
			{
				SendRequestGetFlightsShedule.Execute(null);
			}
		}
	}
}
