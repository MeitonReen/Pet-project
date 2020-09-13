using System;
using System.Threading;

using Layer0_Client.MainMenu.DataContextForBindingsToWPF;
using Layer0_Client.Shared.CommandsForDataContexts;
using Layer0_Client.Shared.MainController;
using SharedDTOs.DataAboutClientRequests;

namespace Layer0_Client.MainMenu.CommandsForDataContext
{
	public class OrderCancel : AbstractWPFCommandWithPostToWPF
	{
		private RequestToBL RequestToBL = null;
		private RemoveOrder RemoveOrder = null;

		public OrderCancel(
			ClientController clientController,
			DCMainMenu dCMainMenu,
			SynchronizationContext synchronizationContext,
			Predicate<object> canExecute = null)
		:base(synchronizationContext, canExecute)
		{
			RequestToBL = new RequestToBL(
				clientController, canExecute,EnumClientRequests.SetCancelOrder);

			RemoveOrder = new RemoveOrder(dCMainMenu, synchronizationContext, canExecute);
		}
		
		protected override void ExecuteInWPF(object parameter)
		{
			if ((RequestToBL?.CanExecute(null) ?? new bool?(false)).Value)
			{
				RequestToBL.Execute(null);
			}

			if ((RemoveOrder?.CanExecute(null) ?? new bool?(false)).Value)
			{
				RemoveOrder.Execute(null);
			}
		}
	}
}
