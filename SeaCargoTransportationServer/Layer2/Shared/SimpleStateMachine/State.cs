using System;
using System.Collections.Generic;
using System.Linq;

using Shared;

namespace Layer2.Shared.SimpleStateMachine
{
	public class State<TStateID> : IHandler where TStateID : Enum
	{
		private IExecutorOfClientRequest Executor = null;
		private TStateID StateID;
		private List<TStateID[]> ArraysOfAllowedTransitionsToThisState = new List<TStateID[]>();
		private IHandler[] StatesForResetAfterSuccessfulExecutionOfThisState = null;
		private SharedBufferForStates<TStateID> SharedBufferForStates = null;

		public State(
			TStateID stateID,
			IExecutorOfClientRequest executor,
			IHandler[] statesForResetAfterSuccessfulExecutionOfThisState = null)
		{
			StateID = stateID;
			Executor = executor;
			StatesForResetAfterSuccessfulExecutionOfThisState =
				statesForResetAfterSuccessfulExecutionOfThisState;
		}

		public object Handle(object stateIDAndData)
		{
			object Res = null;

			if (CheckTransitionToThisState())
			{
				object Data = ((KeyValuePair<TStateID, object>)stateIDAndData).Value;
				Res = Executor.Execute(Data);
				if (Res != null)
				{
					KeyValuePair<TStateID, object> StateIDAndData =
						(KeyValuePair<TStateID, object>)stateIDAndData;

					SharedBufferForStates.SuccessExecutedStates.Add(StateIDAndData.Key);

					ResetStates();
				}
			}
			return Res;
		}

		private bool CheckTransitionToThisState()
		{
			bool Allow = false;
			List<TStateID> ExecutedStates = SharedBufferForStates.SuccessExecutedStates;

			for (int i = 0;
				i < ArraysOfAllowedTransitionsToThisState.Count && !Allow;
				i++)
			{
				TStateID[] AllowedTransitions = ArraysOfAllowedTransitionsToThisState[i];
				if (AllowedTransitions.Contains(FromState<TStateID>.Anywhere.StateID))
				{
					Allow = true;
				} else 
				{
					var TransitionsForCheck = AllowedTransitions.Intersect(ExecutedStates);
					if (AllowedTransitions.SequenceEqual(TransitionsForCheck) &&
						TransitionsForCheck.Any())
					{
						Allow = true;
					}
				}
			}
			return Allow;
		}
		private void ResetStates()
		{
			foreach (State<TStateID> State in StatesForResetAfterSuccessfulExecutionOfThisState
				?? new State<TStateID>[0])
			{
				if (State != FromState<TStateID>.Null && State != FromState<TStateID>.Anywhere)
					State.SetDefault();
			}
		}
		private void SetDefault()
		{
			Executor.SetDefault();
			SharedBufferForStates.ExcludeItems(StateID);
		}

		public void AddStatesForResetAfterSuccessfulExecutionOfThisState(
			params State<TStateID>[] statesForResetAfterSuccessfulExecutionOfThisState)
		{
			StatesForResetAfterSuccessfulExecutionOfThisState =
				statesForResetAfterSuccessfulExecutionOfThisState;
		}
		
		public State<TStateID> AddSingledAllowedTransitionFrom(State<TStateID> state)
		{
			ArraysOfAllowedTransitionsToThisState.Add(new TStateID[1] { state.StateID });
			return this;
		}
		public State<TStateID> AddCombinedAllowedTransitionsFrom(params State<TStateID>[] states)
		{
			TStateID[] StateIDs = states.Select(State => State.StateID).ToArray();

			ArraysOfAllowedTransitionsToThisState.Add(StateIDs);
			return this;
		}

		public TStateID GetStateID()
		{
			return StateID;
		}
		public void LinkStates(params State<TStateID>[] states)
		{
			SharedBufferForStates =
				new SharedBufferForStates<TStateID>(FromState<TStateID>.Null.StateID);
			foreach(State<TStateID> State in states ?? new State<TStateID>[0])
			{
				State.SharedBufferForStates = SharedBufferForStates;
			}
		}
		public void LinkStates(List<State<TStateID>> states)
		{
			LinkStates(states.ToArray());
		}
		public void MulticastSendServiceData(object data)
		{
			Executor.MulticastSendDataAuthorization(data);
		}
		public void SetSharedCommunication(object reference)
		{
			Executor.SetSharedCommunication(reference);
		}
	}
}
