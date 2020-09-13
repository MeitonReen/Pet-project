using System.Collections.Generic;

using Layer2.CreatingOrder.Interactors;
using Layer2.Shared;
using Layer2.Shared.SimpleStateMachine;
using Shared;
using SharedDTOs.DataAboutClientRequests;

namespace Layer2.CreatingOrder
{

	public class InteractorsLinker : ILinkerInteractorStates
	{
		private SharedBufferForStates<EnumClientRequests> SharedBufferOfStates = null;

		State<EnumClientRequests> StateOfGetAttributesForCargos = null;
		State<EnumClientRequests> StateOfGetFlightsSchedule = null;
		State<EnumClientRequests> StateOfSetNewOrderInDatabase = null;

		public InteractorsLinker(
			SharedBufferForStates<EnumClientRequests> sharedBufferOfStates)
		{
			SharedBufferOfStates = sharedBufferOfStates;
		}

		public KeyValuePair<EnumClientRequests, IHandler>[] LinkStates()
		{
			return
				new KeyValuePair<EnumClientRequests, IHandler>[]
				{
					new KeyValuePair<EnumClientRequests, IHandler>
					(
						EnumClientRequests.GetAttributeForCargos,
						LinkStateGetAttributesForCargos()
					),

					new KeyValuePair<EnumClientRequests, IHandler>
					(
						EnumClientRequests.GetFlightsSchedule,
						LinkStateGetFlightsSchedule()
					),

					new KeyValuePair<EnumClientRequests, IHandler>
					(
						EnumClientRequests.SetNewOrder,
						LinkStateSetNewOrderInDatabase()
					)
				};
		}

		private State<EnumClientRequests> LinkStateGetAttributesForCargos()
		{
			GetAttributesForCargos GetAttributesForCargos =
				new GetAttributesForCargos();

			EnumClientRequests[][] arraysOfAllowedTransitionToThisState =
			new EnumClientRequests[][]
			{
				new EnumClientRequests[]
				{
					EnumClientRequests.GetClientData,
					EnumClientRequests.GetClientOrders
				},
				new EnumClientRequests[]
				{
					EnumClientRequests.GetAttributeForCargos,
				},
				new EnumClientRequests[]
				{
					EnumClientRequests.GetFlightsSchedule
				},
				new EnumClientRequests[]
				{
					EnumClientRequests.GetAttributeForCargos,
					EnumClientRequests.GetFlightsSchedule
				}
			};

			StateOfGetAttributesForCargos = new State<EnumClientRequests>(
				GetAttributesForCargos,
				arraysOfAllowedTransitionToThisState,
				SharedBufferOfStates);

			return StateOfGetAttributesForCargos;
		}

		private State<EnumClientRequests> LinkStateGetFlightsSchedule()
		{
			GetFlightsSchedule GetFlightsSchedule =
				new GetFlightsSchedule();

			EnumClientRequests[][] arraysOfAllowedTransitionToThisState =
			new EnumClientRequests[][]
			{
				new EnumClientRequests[]
				{
					EnumClientRequests.GetAttributeForCargos,
				},
				new EnumClientRequests[]
				{
					EnumClientRequests.GetFlightsSchedule
				},
				new EnumClientRequests[]
				{
					EnumClientRequests.GetAttributeForCargos,
					EnumClientRequests.GetFlightsSchedule
				}
			};

			StateOfGetFlightsSchedule = new State<EnumClientRequests>(
				GetFlightsSchedule,
				arraysOfAllowedTransitionToThisState,
				SharedBufferOfStates);

			return StateOfGetFlightsSchedule;
		}

		private State<EnumClientRequests> LinkStateSetNewOrderInDatabase()
		{
			SetNewOrderInDatabase SetNewOrderInDatabase = new SetNewOrderInDatabase();

			EnumClientRequests[][] arraysOfAllowedTransitionToThisState =
			new EnumClientRequests[][]
			{
				new EnumClientRequests[]
				{
					EnumClientRequests.GetAttributeForCargos,
					EnumClientRequests.GetFlightsSchedule
				}
			};

			List<State<EnumClientRequests>> StatesForReset = new List<State<EnumClientRequests>>
			{
				StateOfGetAttributesForCargos,
				StateOfGetFlightsSchedule
			};
			List<EnumClientRequests> StatesIdForReset = new List<EnumClientRequests>()
			{
				EnumClientRequests.GetAttributeForCargos,
				EnumClientRequests.GetFlightsSchedule,
				EnumClientRequests.SetNewOrder
			};

			StateOfSetNewOrderInDatabase = new State<EnumClientRequests>(
				SetNewOrderInDatabase,
				arraysOfAllowedTransitionToThisState,
				SharedBufferOfStates,
				StatesForReset,
				StatesIdForReset);

			return StateOfSetNewOrderInDatabase;
		}
	}
}
