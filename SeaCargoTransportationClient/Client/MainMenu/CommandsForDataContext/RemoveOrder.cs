using System;
using System.Linq;
using System.Threading;
using Layer0_Client.MainMenu.DataContextForBindingsToWPF;
using Layer0_Client.Shared.CommandsForDataContexts;
using SharedDTOsByClient.MainMenu;

namespace Layer0_Client.MainMenu.CommandsForDataContext
{
	public class RemoveOrder : AbstractWPFCommandWithPostToWPF
	{
		DCMainMenu DCMainMenu = null;
		
		public RemoveOrder(
			DCMainMenu dCMainMenu, 
			SynchronizationContext synchronizationContext,
			Predicate<object> canExecute = null)
		:base(synchronizationContext, canExecute)
		{
			DCMainMenu = dCMainMenu;
		}

		protected override void ExecuteInWPF(object parameter)
		{
			OrderLayer0 OrderToRemove = 
				DCMainMenu.Orders.FirstOrDefault(OrderLayer0 => OrderLayer0.IsSelected);
			
			DCMainMenu.Orders.Remove(OrderToRemove);
		}
	}
}
