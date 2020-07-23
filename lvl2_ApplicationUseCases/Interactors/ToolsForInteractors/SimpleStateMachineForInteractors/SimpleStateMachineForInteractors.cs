using System;
using System.Collections.Generic;
using System.Text;
using lvl2_ApplicationUseCases.GatewayToDatabase.Context;
using lvl2_ApplicationUseCases.
	Interactors.
	ToolsForInteractors.
	CommonForClientCommands.
	InterfacesForClientCommands.
	IExecutorOfClientCommand;

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
	SimpleStateMachineForInteractors.
	Data;
namespace lvl2_ApplicationUseCases.
	ToolsForInteractors.
	SimpleStateMachineForInteractors
{
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="TEnumCommandID"></typeparam>
	/// <typeparam name="TDataOfCommand"></typeparam>
	/// <typeparam name="TExecutorCommand"></typeparam>
	public class SimpleStateMachineForInteractors<
		TEnumCommandID, TDataOfCommand, TExecutorCommand>
		where TEnumCommandID : Enum
		where TExecutorCommand : IExecutorOfClientCommand
	{
		#region Fields
		private Dictionary<
			EnumStateID,
			StateOfSimpleStateMachineForInteractors<TExecutorCommand>>
			States = new Dictionary<
				EnumStateID,
				StateOfSimpleStateMachineForInteractors<TExecutorCommand>>();

		private Dictionary<TEnumCommandID, EnumStateID> StateIDsOnCommandIDs =
			new Dictionary<TEnumCommandID, EnumStateID>();

		private EnumStateID ExecutedState = EnumStateID.None;
		private List<EnumStateID> LastStates = new List<EnumStateID>();
		#endregion

		#region PublicMethods
		public SimpleStateMachineForInteractors()
		{
			RegistrationCommandIDs();
		}
		
		public void RegistrationState(
			TEnumCommandID commandID,
			TExecutorCommand executorCommand,
			EnumAttributesState attributeState,
			params TEnumCommandID[] allowedTransitionsToThisState)
		{
			StateOfSimpleStateMachineForInteractors<TExecutorCommand> State =
				new StateOfSimpleStateMachineForInteractors<TExecutorCommand>(
					executorCommand,
					ConvertCommandIDsToStateIDs(allowedTransitionsToThisState));

			States.Add(StateIDsOnCommandIDs[commandID], State);

			IfNewStateIsLastStateThenRememberItInLastStates(
				StateIDsOnCommandIDs[commandID],
				attributeState);
		}

		//Добавить обобщённый Result
		public object Execute(TEnumCommandID commandID, TDataOfCommand dataOfCommand)
		{
			object Res = null;
			EnumStateID NewState = StateIDsOnCommandIDs[commandID];

			if (CheckAllowedTransitionsToNewStateFromExecutedState(
				NewState))
			{
				Res = States[StateIDsOnCommandIDs[commandID]].Execute(dataOfCommand);
				IfExecutedLastStateThenStateMachineSetDefault(NewState);
			}

			return Res;
		}
		#endregion

		#region PrivateMethods
		
		private void RegistrationCommandIDs()
		{
			int StateID = 0;
			foreach(
				TEnumCommandID CommandID in
					Enum.GetValues(typeof(TEnumCommandID)))
			{
				StateIDsOnCommandIDs.Add(CommandID, (EnumStateID)StateID);
				StateID++;
			}
		}
		private EnumStateID[] ConvertCommandIDsToStateIDs(TEnumCommandID[] commandIDs)
		{
			EnumStateID[] StatesID = new EnumStateID[commandIDs.Length];
			
			for (int i = 0; i < commandIDs.Length; i++)
			{
				StatesID[i] = StateIDsOnCommandIDs[commandIDs[i]];
			}

			return StatesID;
		}
		private void IfNewStateIsLastStateThenRememberItInLastStates(
			EnumStateID StateID,
			EnumAttributesState attributeState)
		{
			if (attributeState == EnumAttributesState.Last)
			{
				LastStates.Add(StateID);
			}
		}
		private void SetDefault()
		{
			ClearCommands();
			ExecutedState = EnumStateID.None;
		}
		private void ClearCommands()
		{
			foreach(
				StateOfSimpleStateMachineForInteractors<TExecutorCommand> Value
					in States.Values)
			{
				Value.ClearCommand();
			}
		}
		private void IfExecutedLastStateThenStateMachineSetDefault(
			EnumStateID StateID)
		{
			if (LastStates.Contains(StateID))
			{
				SetDefault();
			}
		}

		private bool CheckAllowedTransitionsToNewStateFromExecutedState(
			EnumStateID NewState)
		{
			return 
				States[NewState].
					CheckAllowedTransitionsToNewStateFromExecutedState(ExecutedState);
		}
		#endregion
	}
}
