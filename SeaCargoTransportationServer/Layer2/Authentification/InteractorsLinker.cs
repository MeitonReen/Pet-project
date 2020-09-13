using System.Collections.Generic;
using System.Linq;

using Layer2.Authentification.Interactors;
using Layer2.Shared;
using Layer2.Shared.SimpleStateMachine;
using Shared;
using SharedDTOs.DataAboutClientRequests;

namespace Layer2.Authentification
{

	public class InteractorsLinker : ILinkerInteractorStates
	{
		private SharedBufferForStates<EnumClientRequests> SharedBufferOfStates = null;

		State<EnumClientRequests> StateOfGetAuthentification = null;

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
						EnumClientRequests.GetAuthorization,
						LinkStateGetAuthentification()
					)
				};
		}

		private State<EnumClientRequests> LinkStateGetAuthentification()
		{
			GetAuthorization GetAuthentification =
				new GetAuthorization();

			EnumClientRequests[][] arraysOfAllowedTransitionToThisState =
			new EnumClientRequests[][]
			{
				new EnumClientRequests[]
				{},
				new EnumClientRequests[]
				{
					EnumClientRequests.GetAuthorization
				}
			};

			EnumClientRequests[] ClearClientRequestIDs = new EnumClientRequests[]
			{
				EnumClientRequests.GetAttributeForCargos,
				EnumClientRequests.GetFlightsSchedule,
				EnumClientRequests.SetNewOrder,
				EnumClientRequests.GetClientData,
				EnumClientRequests.GetClientOrders
			};

			StateOfGetAuthentification = new State<EnumClientRequests>(
				GetAuthentification,
				arraysOfAllowedTransitionToThisState,
				SharedBufferOfStates,
				null,
				ClearClientRequestIDs.ToList());

			return StateOfGetAuthentification;
		}
	}
}
