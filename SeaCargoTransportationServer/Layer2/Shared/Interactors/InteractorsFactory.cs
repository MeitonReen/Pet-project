using Layer2.Authentification.Interactors;
using Layer2.CreatingOrder.Interactors;
using Layer2.MainMenu.Interactors;
using Layer2.Shared.SimpleStateMachine;
using Shared;
using Shared.Dictionary;
using SharedDTOs.DataAboutClientRequests;
using System.Collections.Generic;
using System.Linq;

namespace Layer2.Shared.Interactors
{
	public class InteractorsFactory
	{
		private DictionaryOfHandlers<EnumClientRequests> Interactors =
			new DictionaryOfHandlers<EnumClientRequests>();

		private State<EnumClientRequests> GetAuthorization = null;

		private State<EnumClientRequests> GetAttributesForCargos = null;
		private State<EnumClientRequests> GetFlightsSchedule = null;
		private State<EnumClientRequests> SetNewOrder = null;

		private State<EnumClientRequests> GetClientData = null;
		private State<EnumClientRequests> GetClientOrders = null;
		private State<EnumClientRequests> SetOrderCancel = null;


		public DictionaryOfHandlers<EnumClientRequests> CreateInteractors()
		{
			CreateAndLink();

			return Interactors;
		}

		private void CreateAndLink()
		{
			CreateStateAuthentification();
			CreateStatesMainMenu();
			CreateStatesCreatingOrder();
			State<EnumClientRequests>[] CompleteInteractors = LinkStates();

			KeyValuePair<EnumClientRequests, IHandler>[] PreparedInteractorsToLoadIntoDictionary =
				ToKeyValuePairs(CompleteInteractors);

			Interactors.AddRange(PreparedInteractorsToLoadIntoDictionary);
		}

		private void CreateStateAuthentification()
		{
			GetAuthorization = new State<EnumClientRequests>(
				EnumClientRequests.GetAuthorization,
				new GetAuthorization());
		}
		private void CreateStatesMainMenu()
		{
			GetClientData =
				new State<EnumClientRequests>(EnumClientRequests.GetClientData, new GetClientData());
			GetClientOrders =
				new State<EnumClientRequests>(EnumClientRequests.GetClientOrders, new GetClientOrders());
			SetOrderCancel =
				new State<EnumClientRequests>(EnumClientRequests.SetCancelOrder, new SetCancelOrder());
		}
		private void CreateStatesCreatingOrder()
		{
			GetAttributesForCargos =
				new State<EnumClientRequests>(EnumClientRequests.GetAttributeForCargos, new GetAttributesForCargos());
			GetFlightsSchedule =
				new State<EnumClientRequests>(EnumClientRequests.GetFlightsSchedule, new GetFlightsSchedule());
			SetNewOrder =
				new State<EnumClientRequests>(EnumClientRequests.SetNewOrder, new SetNewOrder());
		}
		private State<EnumClientRequests>[] LinkStates()
		{
			GetAuthorization.
				AddSingledAllowedTransitionFrom(FromState<EnumClientRequests>.Null).
				AddSingledAllowedTransitionFrom(GetAuthorization);
			GetAuthorization.AddStatesForResetAfterSuccessfulExecutionOfThisState(
				GetClientData, GetClientOrders, GetAttributesForCargos, GetFlightsSchedule, SetNewOrder);

			GetClientData.
				AddSingledAllowedTransitionFrom(GetAuthorization).
				AddSingledAllowedTransitionFrom(GetClientData).
				AddSingledAllowedTransitionFrom(GetClientOrders);
			GetClientOrders.
				AddSingledAllowedTransitionFrom(GetAuthorization).
				AddSingledAllowedTransitionFrom(GetClientData).
				AddSingledAllowedTransitionFrom(GetClientOrders);
			SetOrderCancel.
				AddCombinedAllowedTransitionsFrom(GetClientData, GetClientOrders);

			GetAttributesForCargos.
				AddSingledAllowedTransitionFrom(GetAttributesForCargos).
				AddSingledAllowedTransitionFrom(GetFlightsSchedule).
				AddCombinedAllowedTransitionsFrom(GetClientData, GetClientOrders);
			GetFlightsSchedule.
				AddSingledAllowedTransitionFrom(GetFlightsSchedule).
				AddSingledAllowedTransitionFrom(GetAttributesForCargos).
				AddCombinedAllowedTransitionsFrom(GetClientData, GetClientOrders);
			SetNewOrder.
				AddCombinedAllowedTransitionsFrom(GetAttributesForCargos, GetFlightsSchedule);
			SetNewOrder.AddStatesForResetAfterSuccessfulExecutionOfThisState(
				GetAttributesForCargos, GetFlightsSchedule, SetNewOrder);

			GetAuthorization.LinkStates(GetAuthorization, GetClientData, GetClientOrders, SetOrderCancel,
				GetAttributesForCargos, GetFlightsSchedule, SetNewOrder);

			return new State<EnumClientRequests>[]
			{
				GetAuthorization, GetClientData, GetClientOrders, SetOrderCancel,
				GetAttributesForCargos, GetFlightsSchedule, SetNewOrder
			};
		}

		private KeyValuePair<EnumClientRequests, IHandler>[] ToKeyValuePairs(
			State<EnumClientRequests>[] states)
		{
			return states.Select(
				State => new KeyValuePair<EnumClientRequests, IHandler>(State.GetStateID(), State)).
					ToArray();
		}
	}
}
