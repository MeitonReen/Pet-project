using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using lvl2_ApplicationUseCases.
	Interactors.
	ToolsForInteractors.
	CommonForClientCommands.
	InterfacesForClientCommands.
	IExecutorOfClientCommand.
	Data;

using lvl2_ApplicationUseCases.
	Interactors.
	ToolsForInteractors.
	CommonForClientCommands.
	InterfacesForClientCommands.
	IExecutorOfClientCommand;

using lvl2_ApplicationUseCases.
	Interactors.
	ToolsForInteractors.
	SimpleStateMachineForInteractors.
	Data;

namespace lvl2_ApplicationUseCases.
	ToolsForInteractors.
	SimpleStateMachineForInteractors
{

	public class StateOfSimpleStateMachineForInteractors<TExecutorCommand>
		where TExecutorCommand : IExecutorOfClientCommand
	{
		private TExecutorCommand State;
		private EnumStateID[] AllowedTransitionsToCurrentState;

		//public Func<object, bool> Execute { get; set; }
		//public List<EnumClientCommands> AllowedTransitionsToCurrentState {get; set;}

		public bool CheckAllowedTransitionsToNewStateFromExecutedState(EnumStateID executedState)
		{
			return AllowedTransitionsToCurrentState.Contains(executedState);
		}

		public object Execute(object _dataOfCommand)
		{
			return State.Execute(_dataOfCommand);
		}
		public void ClearCommand()
		{
			State.ClearCommand();
		}

		public StateOfSimpleStateMachineForInteractors(
			TExecutorCommand state,
			params EnumStateID[] allowedTransitionsToThisState)
		{
			State = state;
			AllowedTransitionsToCurrentState = allowedTransitionsToThisState;
		}
	}
}
