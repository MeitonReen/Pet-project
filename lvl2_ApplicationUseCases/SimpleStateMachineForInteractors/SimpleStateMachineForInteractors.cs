using System;
using System.Linq;
using System.Collections.Generic;

using Layer2_ApplicationUseCases.
	InterfacesForStatesOfInteractors;
using Layer2_ApplicationUseCases.
	SimpleStateMachineForInteractors.
	Data;

namespace Layer2_ApplicationUseCases.
	SimpleStateMachineForInteractors
{
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="TEnumRequestID"></typeparam>
	/// <typeparam name="TDataOfRequest"></typeparam>
	/// <typeparam name="TExecutorRequest"></typeparam>
	public class SimpleStateMachineForInteractors<
		TEnumRequestID, TDataOfRequest, TExecutorRequest>
		where TEnumRequestID : Enum
		where TExecutorRequest : IExecutorOfClientRequest
	{
		#region Fields
		private Dictionary<
			EnumStateID,
			StateOfSimpleStateMachineForInteractors<TExecutorRequest>>
			States = new Dictionary<
				EnumStateID,
				StateOfSimpleStateMachineForInteractors<TExecutorRequest>>();

		private Dictionary<TEnumRequestID, EnumStateID> StateIDsOnRequestIDs =
			new Dictionary<TEnumRequestID, EnumStateID>();

		private List<EnumStateID> ExecutedStates = new List<EnumStateID>();
		private List<EnumStateID> LastStates = new List<EnumStateID>();
		#endregion

		#region PublicMethods
		public SimpleStateMachineForInteractors()
		{
			RegistrationRequestIDs();
			ExecutedStates.Add(EnumStateID.None);
		}
		
		public void RegistrationState(
			TEnumRequestID RequestID,
			TExecutorRequest executorRequest,
			EnumAttributesState[] attributeState,
			params TEnumRequestID[][] allowedTransitionsToThisRequest)
		{

			EnumStateID[][] allowedTransitionsToThisState =
				ConvertRequestIDsToStateIDs(allowedTransitionsToThisRequest);
			
			IfNewStateIsFirstStateThenCorrectAllowedTransitions(
				attributeState,
				ref allowedTransitionsToThisState);

			StateOfSimpleStateMachineForInteractors<TExecutorRequest> NewState =
				new StateOfSimpleStateMachineForInteractors<TExecutorRequest>(
					executorRequest, allowedTransitionsToThisState);
			EnumStateID NewStateID = StateIDsOnRequestIDs[RequestID];
		
			States.Add(NewStateID, NewState);

			IfNewStateIsLastStateThenRememberItInLastStates(
				NewStateID,
				attributeState);
		}

		//Добавить обобщённый Result
		public object Execute(TEnumRequestID RequestID, TDataOfRequest dataOfRequest)
		{
			object Res = null;
			EnumStateID NewState = StateIDsOnRequestIDs[RequestID];

			if (CheckAllowedTransitionsToNewStateFromExecutedStates(
				NewState))
			{
				Res = States[NewState].Execute(dataOfRequest);
				
				ExecutedStates.Add(NewState);

				IfExecutedLastStateThenStateMachineSetDefault(NewState);
			}

			return Res;
		}
		#endregion

		#region PrivateMethods
		
		private void IfNewStateIsFirstStateThenCorrectAllowedTransitions(
			EnumAttributesState[] attributeState,
			ref EnumStateID[][] allowedTransitionsToThisState)
		{

			if (attributeState.Contains(EnumAttributesState.First))
			{
				EnumStateID[][] Correct = 
					new EnumStateID[allowedTransitionsToThisState.Length + 1][];

				allowedTransitionsToThisState.CopyTo(Correct, 0);

				Correct[Correct.Length - 1] = new EnumStateID[] { EnumStateID.None };

				allowedTransitionsToThisState = Correct;
			}

		}
		
		private void RegistrationRequestIDs()
		{
			int StateID = 0;
			foreach(
				TEnumRequestID RequestID in
					Enum.GetValues(typeof(TEnumRequestID)))
			{
				StateIDsOnRequestIDs.Add(RequestID, (EnumStateID)StateID);
				StateID++;
			}
		}
		private EnumStateID[][] ConvertRequestIDsToStateIDs(TEnumRequestID[][] RequestIDs)
		{
			EnumStateID[][] StatesID = new EnumStateID[RequestIDs.GetLength(0)][];
			
			for (int i = 0; i < RequestIDs.GetLength(0); i++)
			{
				StatesID[i] = new EnumStateID[RequestIDs[i].Length];

				for (int j = 0; j < RequestIDs[i].Length; j++)
				{
					StatesID[i][j] = StateIDsOnRequestIDs[RequestIDs[i][j]];
				}
			}

			return StatesID;
		}
		private void IfNewStateIsLastStateThenRememberItInLastStates(
			EnumStateID NewStateID,
			EnumAttributesState[] attributeState)
		{
			if (attributeState.Contains(EnumAttributesState.Last))
			{
				LastStates.Add(NewStateID);
			}
		}
		private void SetDefault()
		{
			ClearRequests();
			ExecutedStates = new List<EnumStateID>() { EnumStateID.None };
		}
		private void ClearRequests()
		{
			foreach(
				StateOfSimpleStateMachineForInteractors<TExecutorRequest> Value
					in States.Values)
			{
				Value.ClearRequest();
			}
		}
		private void IfExecutedLastStateThenStateMachineSetDefault(
			EnumStateID ExecutedStateID)
		{
			if (LastStates.Contains(ExecutedStateID))
			{
				SetDefault();
			}
		}

		private bool CheckAllowedTransitionsToNewStateFromExecutedStates(
			EnumStateID NewState)
		{
			return 
				States[NewState].
					CheckAllowedTransitionsToNewStateFromExecutedStates(
						ExecutedStates.ToArray());
		}
		#endregion
	}
}
