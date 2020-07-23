using System;
using System.Collections.Generic;
using System.Text;
using lvl2_ApplicationUseCases.
	Interactors.
	ToolsForInteractors.
	CommonForClientCommands.
	InterfacesForClientCommands.
	IExecutorOfClientCommand.
	Data;

namespace lvl2_ApplicationUseCases.
	Interactors.
	ToolsForInteractors.
	CommonForClientCommands.
	InterfacesForClientCommands.
	IExecutorOfClientCommand
{
	public interface IExecutorOfClientCommand
	{
	//Вместо bool добавить обобщённый Result
		public object Execute(object dataOfClientCommand);
		public void ClearCommand();
	}
}
