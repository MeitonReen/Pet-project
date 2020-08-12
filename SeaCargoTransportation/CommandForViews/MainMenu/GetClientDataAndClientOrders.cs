
using Layer0_Client.CommandForViews.Shared;
using Layer2_ApplicationUseCases.DataAboutClientRequest;
using Layer0_Client.InterfacesForClientController;

namespace Layer0_Client.CommandForViews.MainMenu
{
	public class GetClientDataAndClientOrders : WPFCommand
	{
		private SendClientRequest GetClientData = new
			SendClientRequest(EnumClientRequests.Get_ClientData);
		private SendClientRequest GetClientOrders = new
			SendClientRequest(EnumClientRequests.Get_ClientOrders);

		public void LinkToSenderOfClientRequestsToApplication(
			ISenderOfClientRequestsToApplication
				senderClientRequestsToApplication)
		{
			GetClientData.LinkToSenderOfClientRequestsToApplication(
				senderClientRequestsToApplication);

			GetClientOrders.LinkToSenderOfClientRequestsToApplication(
				senderClientRequestsToApplication);
		}
		public override void Execute(object parameter)
		{
			if (GetClientData.CanExecute(null))
			{
				GetClientData.Execute(null);
			}
			if (GetClientOrders.CanExecute(null))
			{
				GetClientOrders.Execute(null);
			}
		}
	}
}
