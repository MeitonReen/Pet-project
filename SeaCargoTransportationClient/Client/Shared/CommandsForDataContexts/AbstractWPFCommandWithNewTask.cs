using System;
using System.Threading.Tasks;

namespace Layer0_Client.Shared.CommandsForDataContexts
{
	public abstract class AbstractWPFCommandWithNewTask : AbstractWPFCommand
	{
		protected abstract void ExecuteInNewTask(object parameter);

		private Task Task = null;
		
		protected override Predicate<object> GetCanExecuteMethodsFromWayTwo()
		{
			Task = new Task(() => ExecuteInNewTask(null));
			
			Predicate<object> CanExecute = (parameter) =>
			{
				return ((Task?.IsCompleted | Task?.Status == TaskStatus.Created) ??
					new bool?(false)).Value;
			};
			return CanExecute;
		}

		public AbstractWPFCommandWithNewTask(Predicate<object> canExecuteMethodsFromWayOne)
		:base(canExecuteMethodsFromWayOne)
		{}

		protected override void ConcreteExecute(object parameter)
		{
			Task = new Task(() => ExecuteInNewTask(parameter));

			Task.Start();
		}

	}
}
