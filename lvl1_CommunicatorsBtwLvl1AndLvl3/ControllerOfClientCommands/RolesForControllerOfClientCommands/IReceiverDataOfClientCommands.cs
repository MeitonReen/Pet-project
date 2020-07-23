using System;
using System.Collections.Generic;
using System.Text;
//ReceiverDataOfClientCommands получае данные для Executor'а client command
using lvl2_ApplicationUseCases.
	Interactors.
	RolesForInteractors.
	IExecutorOfClientCommand.
	DataForExecutorOfClientCommand;

namespace lvl1_CommunicatorsBtwLvl1AndLvl3.
	ControllerOfClientCommands.
	RolesForControllerOfClientCommands
{
	public interface IReceiverDataOfClientCommands
	{
		public int Receive(DataOfClientCommand _dataClientCommand);
	}
}
