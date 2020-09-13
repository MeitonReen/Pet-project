using System.Collections.Generic;

using Layer2.MainMenu.Interactors;
using Layer2.Shared.SimpleStateMachine;
using Layer2.Shared;
using SharedDTOs.DataAboutClientRequests;
using Shared;

namespace Layer2.MainMenu
{
	public class InteractorsLinker : ILinkerInteractorStates
	{
		private SharedBufferForStates<EnumClientRequests> SharedBufferOfStates =
			new SharedBufferForStates<EnumClientRequests>();

		State<EnumClientRequests> StateOfGetClientData = null;
		State<EnumClientRequests> StateOfGetClientOrders = null;
		State<EnumClientRequests> StateOfSetOrderCancel = null;

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
						EnumClientRequests.GetClientData,
						LinkStateGetClientData()
					),
					new KeyValuePair<EnumClientRequests, IHandler>
					(
						EnumClientRequests.GetClientOrders,
						LinkStateGetClientOrders()
					),
					new KeyValuePair<EnumClientRequests, IHandler>
					(
						EnumClientRequests.SetCancelOrder,
						LinkStateSetOrderCancel()
					)
				};
		}

		private State<EnumClientRequests> LinkStateGetClientData()
		{
			GetClientData GetClientData = new GetClientData();

			EnumClientRequests[][] arraysOfAllowedTransitionToThisState =
			new EnumClientRequests[][]
			{
				new EnumClientRequests[]
				{ 
					EnumClientRequests.GetAuthorization
				},
				new EnumClientRequests[]
				{
					EnumClientRequests.GetClientData,
				},
				new EnumClientRequests[]
				{
					EnumClientRequests.GetClientOrders
				},
				new EnumClientRequests[]
				{
					EnumClientRequests.GetClientData,
					EnumClientRequests.GetClientOrders
				}
			};

			StateOfGetClientData = new State<EnumClientRequests>(
				GetClientData,
				arraysOfAllowedTransitionToThisState,
				SharedBufferOfStates);

			return StateOfGetClientData;
		}

		private State<EnumClientRequests> LinkStateGetClientOrders()
		{
			GetClientOrders GetClientOrders =
				new GetClientOrders();

			EnumClientRequests[][] arraysOfAllowedTransitionToThisState =
			new EnumClientRequests[][]
			{
				new EnumClientRequests[]
				{ 
					EnumClientRequests.GetAuthorization
				},
				new EnumClientRequests[]
				{
					EnumClientRequests.GetClientData,
				},
				new EnumClientRequests[]
				{
					EnumClientRequests.GetClientOrders
				},
				new EnumClientRequests[]
				{
					EnumClientRequests.GetClientData,
					EnumClientRequests.GetClientOrders
				}
			};

			StateOfGetClientOrders = new State<EnumClientRequests>(
				GetClientOrders,
				arraysOfAllowedTransitionToThisState,
				SharedBufferOfStates);

			return StateOfGetClientOrders;
		}

		private State<EnumClientRequests> LinkStateSetOrderCancel()
		{
			SetOrderCancel SetOrderCancel =
				new SetOrderCancel();

			EnumClientRequests[][] arraysOfAllowedTransitionToThisState =
			new EnumClientRequests[][]
			{
				new EnumClientRequests[]
				{
					EnumClientRequests.GetClientData,
					EnumClientRequests.GetClientOrders
				}
			};

			StateOfSetOrderCancel = new State<EnumClientRequests>(
				SetOrderCancel,
				arraysOfAllowedTransitionToThisState,
				SharedBufferOfStates);

			return StateOfSetOrderCancel;
		}
	}
}
