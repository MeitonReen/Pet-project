using System.Collections.Generic;
using System.Linq;

using Shared;

namespace Layer2.Shared.SimpleStateMachine
{
	public class State<TStateID> : IHandler
	{
		private IExecutorOfClientRequest Executor = null;
		private TStateID[][] ArraysOfAllowedTransitionToThisState = null;

		private SharedBufferForStates<TStateID> SharedBufferOfStates = null;
		private List<State<TStateID>> StatesForResetAfterSuccessfulExecutionOfThisState = null;
		private List<TStateID> StateIDsForResetAfterSuccessfulExecutionOfThisState = null;

		public void Receive(object keyAndData)
		{
			Handle(keyAndData);
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
					//Сколково
					object ObjStateID = StateIDAndData.Key;
					TStateID StateID = (TStateID)ObjStateID;

					SharedBufferOfStates.SuccessExecutedStates.Add(StateID);

					ResetStates();
				}
			}
			return Res;
		}

		public State(
			IExecutorOfClientRequest executor,
			TStateID[][] arraysOfAllowedTransitionToThisState,
			SharedBufferForStates<TStateID> sharedBufferOfStates,
			List<State<TStateID>> statesForResetAfterSuccessfulExecutionOfThisState = null,
			List<TStateID> stateIDsForResetAfterSuccessfulExecutionOfThisState = null)
		{
			Executor = executor;
			ArraysOfAllowedTransitionToThisState = arraysOfAllowedTransitionToThisState;
			SharedBufferOfStates = sharedBufferOfStates;
			StatesForResetAfterSuccessfulExecutionOfThisState =
				statesForResetAfterSuccessfulExecutionOfThisState;
			StateIDsForResetAfterSuccessfulExecutionOfThisState =
				stateIDsForResetAfterSuccessfulExecutionOfThisState;
		}

		private bool CheckTransitionToThisState()
		{
			bool Allow = false;
			TStateID[] ExecutedStates = SharedBufferOfStates.SuccessExecutedStates.ToArray();

			for (int i = 0;
				i < ArraysOfAllowedTransitionToThisState.GetLength(0) && !Allow;
				i++)
			{
				TStateID[] Line = ArraysOfAllowedTransitionToThisState[i];

				if (!Line.Except(ExecutedStates).Any())
				{
					Allow = true;
				}
			}

			return Allow;
		}
		private void ResetStates()
		{
			if (StatesForResetAfterSuccessfulExecutionOfThisState != null)
			{
				foreach (State<TStateID> State in
					StatesForResetAfterSuccessfulExecutionOfThisState)
				{
					State.SetDefault();
				}
			}

			SharedBufferOfStates.ExcludeItems(
				StateIDsForResetAfterSuccessfulExecutionOfThisState?.ToArray());
		}

		private void SetDefault()
		{
			Executor.SetDefault();
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
