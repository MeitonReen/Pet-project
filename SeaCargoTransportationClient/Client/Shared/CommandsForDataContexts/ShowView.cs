using System;
using System.Threading;

using Layer0_Client.Shared.Create.Views;

namespace Layer0_Client.Shared.CommandsForDataContexts
{
	public class ShowView : AbstractWPFCommandWithPostToWPF
	{
		private string NameView = null;
		private FactoryOfViews FactoryOfViews = new FactoryOfViews();

		public ShowView(
			string nameView,
			SynchronizationContext synchronizationContext,
			Predicate<object> canExecute = null)
		:base(synchronizationContext, canExecute)
		{
			NameView = nameView;
		}

		protected override void ExecuteInWPF(object parameter)
		{
			FactoryOfViews.CreateAndShow(NameView);
		}
	}
}
