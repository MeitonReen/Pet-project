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
	InterfacesForInteractors.
	IExecutorOfApplicationUseCase
{
	public interface IExecutorOfApplicationUseCase
	{
	//Вместо bool добавить обобщённый Result
		public bool Execute(DataOfClientCommand dataOfClientCommand);
	}
}
