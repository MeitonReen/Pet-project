using System;
using System.Threading;
using System.Windows;

using Layer0_Client.Shared.Create.Views;

namespace Layer0_Client.Shared.CommandsForDataContexts
{
	public class CloseView : AbstractWPFCommandWithPostToWPF
	{
		private string ViewNameToClose = null;
		private FactoryOfViews FactoryOfViews = new FactoryOfViews();

		public CloseView(
			string viewNameToClose,
			SynchronizationContext synchronizationContext,
			Predicate<object> canExecute = null)
		:base(synchronizationContext, canExecute)
		{
			ViewNameToClose = viewNameToClose;
		}

		protected override void ExecuteInWPF(object parameter)
		{
			FactoryOfViews.Close(ViewNameToClose);
		}
	}
}
