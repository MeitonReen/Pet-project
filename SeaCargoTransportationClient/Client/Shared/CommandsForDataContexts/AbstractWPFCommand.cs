using System;
using System.Linq;
using System.Windows.Input;

namespace Layer0_Client.Shared.CommandsForDataContexts
{
	public abstract class AbstractWPFCommand : ICommand
	{
		private Predicate<object> AggregatedCanExecuteMethods = null;
		
		public AbstractWPFCommand(Predicate<object> canExecuteMethodsFromWayOne)
		{
			Predicate<object> CanExecuteIntegrated = null;
			CanExecuteIntegrated += canExecuteMethodsFromWayOne;
			CanExecuteIntegrated += GetCanExecuteMethodsFromWayTwo();

			AggregatedCanExecuteMethods =
				CreateAggregatePredicateFromInvokationList(
					CanExecuteIntegrated?.GetInvocationList(),
					(CurrentPredicate, NextPredicate, parameter) =>
						CurrentPredicate?.Invoke(parameter) & NextPredicate?.Invoke(parameter)
				);
		}

		protected virtual Predicate<object> GetCanExecuteMethodsFromWayTwo()
		{
			return null;
		}

		public void Execute(object parameter)
		{
			ConcreteExecute(parameter);
		}

		protected abstract void ConcreteExecute(object parameter);

		public bool CanExecute(object parameter)
		{
			return (AggregatedCanExecuteMethods?.Invoke(parameter) ?? new bool?(true)).Value;
		}

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		private Predicate<object> CreateAggregatePredicateFromInvokationList(
			Delegate[] delegates,
			Func<Predicate<object>, Predicate<object>, object, bool?> aggregateFunc)
		{
			Predicate<object>[] Predicates = CastInvokationListToArrayPredicate(delegates);
	
			return Predicates?.Aggregate(
				(CurrentDelegate, NextDelegate) =>
				(
					(parameter) => 
						(aggregateFunc(CurrentDelegate, NextDelegate, parameter) ??
							new bool?(false)).Value
				)
			);
		}
		private Predicate<object>[] CastInvokationListToArrayPredicate(Delegate[] Delegates)
		{
			if (Delegates == null)
			{
				return null;
			}
			else
			{
				Predicate<object>[] Predicates = new Predicate<object>[Delegates.Length];
				for (int i = 0; i < Delegates.Length; i++)
				{
					Predicates[i] = Delegates[i] as Predicate<object>;
				}

				return Predicates;
			}
		}
	}
}
