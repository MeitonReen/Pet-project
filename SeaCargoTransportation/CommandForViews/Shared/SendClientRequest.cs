
using System.Threading.Tasks;

using System.Windows.Input;
using Layer2_ApplicationUseCases.
	DataAboutClientRequest;
using Layer0_Client.InterfacesForClientController;


namespace Layer0_Client.CommandForViews.Shared
{
	public class SendClientRequest : WPFCommand
	{
		private EnumClientRequests ClientRequestID = (EnumClientRequests)(-1);
		private ISenderOfClientRequestsToApplication
			SenderClientRequestsToApplication = null;

		private Task Task = null;
		public ISenderOfClientRequestsToApplication getcc()
		{
			return SenderClientRequestsToApplication;
		}

		public SendClientRequest(EnumClientRequests clientRequestID)
			: base()
		{
			ClientRequestID = clientRequestID;
		}

		public void LinkToSenderOfClientRequestsToApplication(
			ISenderOfClientRequestsToApplication
				senderClientRequestsToApplication
			)
		{
			SenderClientRequestsToApplication = 
				senderClientRequestsToApplication;
		}
	
		public override void Execute(object parameter)
		{
			Task = new Task(
				() =>
				{
					SenderClientRequestsToApplication.Send(ClientRequestID);
				}
			);

			_CanExecute =
				(obj) =>
					{
						return Task.IsCompleted || 
							Task.Status == TaskStatus.WaitingForActivation;
					};

			Task.Start();
		}
	}
}
