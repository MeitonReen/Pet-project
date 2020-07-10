using System.Collections.Generic;
using System.Threading.Tasks;
using lvl2_CommunicatorsBtwLvl1AndLvl3.ClientCommands;
using lvl2_CommunicatorsBtwLvl1AndLvl3.ClientCommands.RolesOfClientCommand;
using lvl2_CommunicatorsBtwLvl1AndLvl3.
	ControllerOfClientCommands.
	RolesOfCreatorOfClientCommands;
using lvl2_CommunicatorsBtwLvl1AndLvl3.DataOfClientCommands;
namespace lvl2_CommunicatorsBtwLvl1AndLvl3.ControllerOfClientCommands
{
	public class ControllerOfClientCommands:
		IReceiverDataOfClientCommands,
		IRunnerClientCommands
	{
		private Dictionary<EnumClientCommands, IExecutorOfClientCommand>
			_clientCommandsDictionary = new Dictionary<EnumClientCommands, IExecutorOfClientCommand>();
	
		public void RegistrationOfCommand(
			EnumClientCommands CommandID, IExecutorOfClientCommand ExecutorClientCommand)
		{
			_clientCommandsDictionary.Add(CommandID, ExecutorClientCommand);
		}
		public int Receive(DataForReceiverDataClientCommands Data)
		{
			DataForRunnerClientCommands DataForRunner =
				new DataForRunnerClientCommands();
			DataForRunner.Command = _clientCommandsDictionary[Data.IDCommand];
			//Проверки добавить через коды возврата и исключения
			DataForRunner.DataForExecutorClientCommands = Data.Data;

			Task NewTask =
				Task.Factory.StartNew(RunClientCommand, DataForRunner);

			return 0;
		}

		public void RunClientCommand(object Data)
		{
			DataForRunnerClientCommands DataForRunnerClientCommands = 
				(Data as DataForRunnerClientCommands);
			
			IExecutorOfClientCommand ExecutorOfClientCommand = DataForRunnerClientCommands.Command;
			ExecutorOfClientCommand.Execute(DataForRunnerClientCommands.DataForExecutorClientCommands);
		}

		
	}
}
