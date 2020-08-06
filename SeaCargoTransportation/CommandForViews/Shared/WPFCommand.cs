using System;
using System.Windows.Input;

namespace Layer0_Client.CommandForViews.Shared
{
	public abstract class WPFCommand : ICommand
	{
		protected Func<object, bool> _CanExecute;

		public WPFCommand(Func<object, bool> canExecute = null)
		{
			_CanExecute = canExecute;
		}

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
