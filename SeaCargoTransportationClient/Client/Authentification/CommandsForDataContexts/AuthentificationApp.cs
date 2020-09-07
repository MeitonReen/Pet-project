using System;

using Layer0_Client.Shared.CommandsForDataContexts;
using Layer0_Client.Shared.MainController;
using Layer0_Client.Shared.Create.Views;
using Layer0_Client.Authentification.DataContextForBindingsToWPF;
using SharedDTOs.DataAboutClientRequests;

namespace Layer0_Client.Authentification.CommandsForDataContexts
{
	public class AuthentificationApp : AbstractWPFCommandWithNewTask
	{
		private ClientController ClientController = null;
		private DCAuthentification DCAuthentification = null;

		public AuthentificationApp(
			ClientController clientController,
			DCAuthentification dCAuthentification,
			Predicate<object> canExecuteInNewTask = null)
		:base(canExecuteInNewTask)
		{
			ClientController = clientController;
			DCAuthentification = dCAuthentification;

			DCAuthentification.ChangeConnectionStatus += 
				DCAuthentification_ChangeConnectionStatus;
		}

		private void DCAuthentification_ChangeConnectionStatus(object sender, bool e)
		{
			if (e)
			{
				new FactoryOfViews().CreateShowAndGoToNewView("VMainMenu");
			}
		}

		protected override void ExecuteInNewTask(object parameter)
		{
			RequestToBL Request = new RequestToBL(
				ClientController,
				null,
				EnumClientRequests.GetAuthorization);

			if ((Request?.CanExecute(null) ?? new bool?(false)).Value)
			{
				Request.Execute(null);
			}
		}
	}
}
