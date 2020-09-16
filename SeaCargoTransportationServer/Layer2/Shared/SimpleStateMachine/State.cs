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
		private State<TStateID>[] StatesForResetAfterSuccessfulExecutionOfThisState = null;
		private SharedBufferForStates<TStateID> _SharedBufferForStates = null;
		public SharedBufferForStates<TStateID> SharedBufferForStates
		{
			set { _SharedBufferForStates = value; }
		}

		public State(
			TStateID stateID,
			IExecutorOfClientRequest executor,
			State<TStateID>[] statesForResetAfterSuccessfulExecutionOfThisState = null)
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

					_SharedBufferForStates.SuccessExecutedStates.Add(StateIDAndData.Key);

					ResetStates();
				}
			}
			return Res;
		}

		private bool CheckTransitionToThisState()
		{
			bool Allow = false;
			List<TStateID> ExecutedStates = _SharedBufferForStates.SuccessExecutedStates;

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
				State.SetDefault();
			}
		}
		private void SetDefault()
		{
			Executor.SetDefault();
			_SharedBufferForStates.ExcludeItems(StateID);
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
		public void LinkStates(params State<TStateID>[] States)
		{
			_SharedBufferForStates =
				new SharedBufferForStates<TStateID>(FromState<TStateID>.Null.StateID);
			foreach(State<TStateID> State in States ?? new State<TStateID>[0])
			{
				State.SharedBufferForStates = _SharedBufferForStates;
			}
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
