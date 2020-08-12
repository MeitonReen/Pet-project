using System;
using System.Linq;
using Layer2_ApplicationUseCases.
	InterfacesForStatesOfInteractors;
using Layer2_ApplicationUseCases.
	SimpleStateMachineForInteractors.
	Data;
using Layer2_ApplicationUseCases.
	DataAboutClientRequest;

namespace Layer2_ApplicationUseCases.
	SimpleStateMachineForInteractors
{

	public class StateOfSimpleStateMachineForInteractors<TExecutorRequest>
		where TExecutorRequest : IExecutorOfClientRequest
	{
		private TExecutorRequest State;
		private EnumStateID[][] AllowedTransitionsToCurrentState = null;

		//public Func<object, bool> Execute { get; set; }
		//public List<EnumClientRequests> AllowedTransitionsToCurrentState {get; set;}

		public bool CheckAllowedTransitionsToNewStateFromExecutedStates(
			EnumStateID[] executedStates)
		{
			bool Allow = false;
			for (int i = 0;
				(i < AllowedTransitionsToCurrentState.GetLength(0)) && (!Allow);
				i++)
			{
				EnumStateID[] Line = AllowedTransitionsToCurrentState[i];

				if (!Line.Except(executedStates).Any())
				{
					Allow = true;
				}
			}
			
			return Allow;
		}

		public object Execute(EnumClientRequests RequestID, object dataOfRequest)
		{
			return State.Execute(RequestID, dataOfRequest);
		}
		public void ClearRequest()
		{
			State.ClearRequest();
		}

		public StateOfSimpleStateMachineForInteractors(
			TExecutorRequest state,
			params EnumStateID[][] allowedTransitionsToThisState)
		{	
			State = state;
			AllowedTransitionsToCurrentState = allowedTransitionsToThisState;
		}
	}
}
