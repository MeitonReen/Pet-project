using System.Collections.Generic;
using System.Threading.Tasks;
//ControllerOfClientCommands знает какие роли должен реализовать:
using lvl1_CommunicatorsBtwLvl1AndLvl3.ControllerOfClientCommands.
	RolesForControllerOfClientCommands;
//ControllerOfClientCommands знает кто выполняет полученные команды клиента
using lvl2_ApplicationUseCases.Interactors.RolesOfInteractors;
//ControllerOfClientCommands знает какие данные должен отдать выполнителю команды клиента
using lvl2_ApplicationUseCases.
	Interactors.
	RolesForInteractors.
	IExecutorOfClientCommand.
	DataForExecutorOfClientCommand;



namespace lvl1_CommunicatorsBtwLvl1AndLvl3.ControllerOfClientCommands
{
	public class ControllerOfClientCommands:
		IReceiverDataOfClientCommands,
		IRunnerClientCommands
	{
		private Dictionary<EnumStates, IExecutorOfClientCommand>
			_clientCommandsDictionary = new 
				Dictionary<EnumStates, IExecutorOfClientCommand>();
	
		public void RegistrationOfCommand(
			EnumStates CommandID, IExecutorOfClientCommand ExecutorClientCommand)
		{
			_clientCommandsDictionary.Add(CommandID, ExecutorClientCommand);
		}
		
		private IExecutorOfClientCommand FindExecutorOfClientCommand(
			EnumStates CommandID)
		{
			return _clientCommandsDictionary[CommandID];
		}

		public int Receive(DataOfClientCommand _dataClientCommand)
		{
			IExecutorOfClientCommand _executorOfClientCommand =
				FindExecutorOfClientCommand(_dataClientCommand.IDCommand);

			RunClientCommand(_executorOfClientCommand, _dataClientCommand);
			//Добавить проверочки, исключения
			return 0;
		}

		public void RunClientCommand(
			IExecutorOfClientCommand _executorOfClientCommand,
			DataOfClientCommand _dataClientCommand)
		{

			object _data = _dataClientCommand;
			Task NewTask = Task.Factory.StartNew( (_data) =>
				{
					_executorOfClientCommand.Execute(_dataClientCommand);
				},
				_data
			);
	
		}

		
		

		
	}
}
