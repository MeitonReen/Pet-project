using System;
using System.Windows.Input;

namespace Layer0.Commands
{
	public abstract class WPFCommand : ICommand
	{
		protected abstract Func<object, bool> _CanExecute { get; set; }

		public abstract void Execute(object parameter);

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public bool CanExecute(object parameter)
		{
			if (_CanExecute != null)
			{
				return _CanExecute(parameter);
			}
			else
			{
				return true;
			}
		}
	}
}
