using System;
using System.Collections.Generic;
using System.Text;
//RunnerClientCommands знает кто должен выполнить команду клиента
using lvl2_ApplicationUseCases.Interactors.RolesOfInteractors;
//RunnerClientCommands знает какие данные должен отдать выполнителю команды клиента
using lvl2_ApplicationUseCases.Interactors.RolesForInteractors.DataForExecutorOfClientCommand;

namespace lvl1_CommunicatorsBtwLvl1AndLvl3.
	ControllerOfClientCommands.
	RolesForControllerOfClientCommands
{
/// <summary>
/// object Data для запуска в отдельном потоке
/// </summary>
	public interface IRunnerClientCommands
	{
		public void RunClientCommand(
			IExecutorOfClientCommand _executorOfClientCommand,
			DataClientCommand _dataClientCommand);
	}

}
