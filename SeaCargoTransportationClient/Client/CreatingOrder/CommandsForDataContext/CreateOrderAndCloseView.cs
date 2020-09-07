using System;
using System.Threading;

using Layer0_Client.Shared.CommandsForDataContexts;
using Layer0_Client.Shared.MainController;
using SharedDTOs.DataAboutClientRequests;

namespace Layer0_Client.CreatingOrder.CommandsForDataContext
{
	public class CreateOrderAndCloseView : AbstractWPFCommandWithPostToWPF
	{
		private RequestToBL RequestToBL = null;
		private CloseView CloseView = null;

		public CreateOrderAndCloseView(
			ClientController clientController,
			SynchronizationContext synchronizationContext,
			Predicate<object> canExecute = null)
		:base(synchronizationContext, canExecute)
		{
			RequestToBL = new RequestToBL(
				clientController,
				canExecute,
				EnumClientRequests.SetNewOrder);

			CloseView = new CloseView("VCreatingOrder", synchronizationContext);
		}
	
		protected override void ExecuteInWPF(object parameter)
		{
			if ((RequestToBL?.CanExecute(null) ?? new bool?(false)).Value)
			{
				RequestToBL.Execute(null);
			}

			if ((CloseView?.CanExecute(null) ?? new bool?(false)).Value)
			{
				CloseView.Execute(null);
			}
		}
	}
}
