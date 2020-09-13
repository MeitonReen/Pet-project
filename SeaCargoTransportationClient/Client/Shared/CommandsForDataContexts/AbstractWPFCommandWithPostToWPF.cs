using System;
using System.Threading;

namespace Layer0_Client.Shared.CommandsForDataContexts
{
	public abstract class AbstractWPFCommandWithPostToWPF : AbstractWPFCommand
	{
		protected abstract void ExecuteInWPF(object parameter);
		
		private SynchronizationContext SynchronizationContext = null;

		public AbstractWPFCommandWithPostToWPF(
			SynchronizationContext synchronizationContext,
			Predicate<object> canExecute = null)
		:base(canExecute)
		{
			SynchronizationContext = synchronizationContext;
		}

		protected override void ConcreteExecute(object parameter)
		{
			SynchronizationContext.Post(ExecuteInWPF, parameter);
		}
	
	}
}
