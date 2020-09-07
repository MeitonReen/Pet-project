using System.Threading;
using System.Windows.Input;

using Layer0_Client.Shared.MainController;
using SharedDTOs.DataAboutClientRequests;

namespace Layer0_Client.CreatingOrder.DataContextForBindingsToWPF
{
	public abstract class AbstractDataContext
	{
		protected ClientController ClientController = null;
		
		public AbstractDataContext()
		{
			InitializeDataContext();
		}

		protected abstract EnumClientRequests[] DefineClientRequestIDsRunningInDataContext();
		protected abstract ICommand[] DefineCommandsToExecuteDuringInitialization();

		protected void InitializeDataContext()
		{
			EnumClientRequests[] ClientRequestIDsRunningInDataContext = 
				DefineClientRequestIDsRunningInDataContext();

			ClientController = new ClientController(SynchronizationContext.Current, this,
				ClientRequestIDsRunningInDataContext);

			ICommand[] CommandsToExecuteDuringInitialization = 
				DefineCommandsToExecuteDuringInitialization();

			if (CommandsToExecuteDuringInitialization != null)
			{
				foreach (ICommand Command in CommandsToExecuteDuringInitialization)
				{
					if ((Command?.CanExecute(null) ?? new bool?(false)).Value)
					{
						Command.Execute(null);
					}
				}
			}
		}
	}
}
