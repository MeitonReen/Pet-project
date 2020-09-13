using System;

using Layer0_Client.Shared.MainController;
using SharedDTOs.DataAboutClientRequests;

namespace Layer0_Client.Shared.CommandsForDataContexts
{
	public class RequestToBL : AbstractWPFCommandWithNewTask
	{
		private ClientController ClientController = null;
		private EnumClientRequests[] ClientRequestIDs = null;

		public RequestToBL(
			ClientController clientController,
			Predicate<object> canExecute = null,
			params EnumClientRequests[] clientRequestIDs)
		:base(canExecute)
		{
			ClientController = clientController;
			ClientRequestIDs = clientRequestIDs;
		}

		protected override void ExecuteInNewTask(object parameter)
		{
			ClientController?.Request(ClientRequestIDs);
		}
	}
}
