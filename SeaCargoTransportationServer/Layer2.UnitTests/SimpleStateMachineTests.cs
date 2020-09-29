using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;
using NSubstitute;

using Layer2.Shared.SimpleStateMachine;
using Layer2.Shared;
using SharedDTOs.DataAboutClientRequests;

namespace Layer2.UnitTests
{
	public class SimpleStateMachineTests
	{
		[Test]
		public void DenyTransitionToNewState_TransitionAttemptFromNullStateToNewState_NewStateDidNotExecuted()
		{
			//Arrange
			IExecutorOfClientRequest MockExecutorClientRequest = Substitute.For<IExecutorOfClientRequest>();

			State<EnumClientRequests> NullState = FromState<EnumClientRequests>.Null;
			var NewState = new State<EnumClientRequests>(
				EnumClientRequests.GetAuthorization,
				MockExecutorClientRequest);
			NullState.LinkStates(NewState);

			var ObjectIntoNewStateForHandle = new KeyValuePair<EnumClientRequests, object>(
				EnumClientRequests.GetAuthorization, null);
			//Act
			NewState.Handle(ObjectIntoNewStateForHandle);
			//Assert
			MockExecutorClientRequest.DidNotReceive().Execute(null);
		}
		[Test]
		public void AcceptTransitionToNewState_TransitionAttemptFromNullStateToNewState_NewStateExecuted()
		{
			//Arrange
			IExecutorOfClientRequest MockExecutorClientRequest = Substitute.For<IExecutorOfClientRequest>();

			State<EnumClientRequests> NullState = FromState<EnumClientRequests>.Null;
			var NewState = new State<EnumClientRequests>(
				EnumClientRequests.GetAuthorization,
				MockExecutorClientRequest);

			NewState.AddSingledAllowedTransitionFrom(NullState);

			NullState.LinkStates(NewState);

			var ObjectIntoNewStateForHandle = new KeyValuePair<EnumClientRequests, object>(
				EnumClientRequests.GetAuthorization, null);
			//Act
			NewState.Handle(ObjectIntoNewStateForHandle);
			//Assert
			MockExecutorClientRequest.Received().Execute(null);
		}
		[Test]
		public void DenyTransitionToNewState_TransitionAttemptFromCurrentStateToNewState_NewStateDidNotExecuted()
		{
			//Arrange
			IExecutorOfClientRequest MockExecutorClientRequest = Substitute.For<IExecutorOfClientRequest>();
			IExecutorOfClientRequest StubExecutorClientRequest = Substitute.For<IExecutorOfClientRequest>();
			StubExecutorClientRequest.Execute(null).Returns(new object());

			State<EnumClientRequests> CurrentState = new State<EnumClientRequests>(
				EnumClientRequests.GetAttributeForCargos, StubExecutorClientRequest);
			var NewState = new State<EnumClientRequests>(
				EnumClientRequests.GetAuthorization,
				MockExecutorClientRequest);
			CurrentState.LinkStates(NewState);

			var ObjectIntoStateForHandle = new KeyValuePair<EnumClientRequests, object>(
				EnumClientRequests.GetAuthorization, null);
			//Act
			CurrentState.Handle(ObjectIntoStateForHandle);
			NewState.Handle(ObjectIntoStateForHandle);
			//Assert
			MockExecutorClientRequest.DidNotReceive().Execute(null);
		}
		[Test]
		public void AcceptTransitionToNewState_TransitionAttemptFromCurrentStateToNewState_NewStateExecuted()
		{
			//Arrange
			IExecutorOfClientRequest MockExecutorClientRequest = Substitute.For<IExecutorOfClientRequest>();
			IExecutorOfClientRequest StubExecutorOfClientRequest = Substitute.For<IExecutorOfClientRequest>();
			StubExecutorOfClientRequest.Execute(null).Returns(new object());

			State<EnumClientRequests> CurrentState = new State<EnumClientRequests>(
				EnumClientRequests.GetAttributeForCargos, StubExecutorOfClientRequest);
			CurrentState.AddSingledAllowedTransitionFrom(FromState<EnumClientRequests>.Null);

			var NewState = new State<EnumClientRequests>(
				EnumClientRequests.GetAuthorization,
				MockExecutorClientRequest);
			NewState.AddSingledAllowedTransitionFrom(CurrentState);

			CurrentState.LinkStates(NewState);

			var ObjectIntoNewStateForHandle = new KeyValuePair<EnumClientRequests, object>(
				EnumClientRequests.GetAuthorization, null);
			var ObjectIntoCurrentStateForHandle = new KeyValuePair<EnumClientRequests, object>(
				EnumClientRequests.GetAttributeForCargos, null);

			CurrentState.Handle(ObjectIntoCurrentStateForHandle);
			//Act
			NewState.Handle(ObjectIntoNewStateForHandle);
			//Assert
			MockExecutorClientRequest.Received().Execute(null);
		}
		[Test]
		public void AcceptTransitionToAnywhereState_TransitionAttemptFromAnywhereStateToNewState_NewStateExecuted()
		{
			//Arrange
			EnumClientRequests[] ClientRequests = Enum.GetValues(typeof(EnumClientRequests)).
				Cast<EnumClientRequests>().ToArray();
			foreach (var ClientRequest in ClientRequests)
			{
				var State = new State<EnumClientRequests>(ClientRequest, null);

				IExecutorOfClientRequest MockExecutorClientRequest = Substitute.For<IExecutorOfClientRequest>();
				var NewState = new State<EnumClientRequests>(
					EnumClientRequests.GetAuthorization,
					MockExecutorClientRequest);

				NewState.AddSingledAllowedTransitionFrom(FromState<EnumClientRequests>.Anywhere);
			
				NewState.LinkStates(State);

				var ObjectIntoNewStateForHandle = new KeyValuePair<EnumClientRequests, object>(
					EnumClientRequests.GetAuthorization, null);
				//Act
				NewState.Handle(ObjectIntoNewStateForHandle);
				//Assert
				MockExecutorClientRequest.Received().Execute(null);
			}
		}
		[Test]
		public void CheckResetOfStatesAfterSuccessfulExecutionOfState_CheckTheCallToSetDefaultTargetStates_CallToSetDefaultTargetStates()
		{
			//Arrange
			IExecutorOfClientRequest[] MockExecutors = new IExecutorOfClientRequest[5];
			MockExecutors = MockExecutors.Select(MockExecutor =>
				Substitute.For<IExecutorOfClientRequest>()).ToArray();

			State<EnumClientRequests>[] States = MockExecutors.Select(MockExecutor =>
				new State<EnumClientRequests>(EnumClientRequests.GetAuthorization, MockExecutor))
					.ToArray();

			IExecutorOfClientRequest StubExecutorOfClientRequest =
				Substitute.For<IExecutorOfClientRequest>();
			StubExecutorOfClientRequest.Execute(null).Returns(new object());

			var State = new State<EnumClientRequests>(
				EnumClientRequests.GetAuthorization,
				StubExecutorOfClientRequest,
				States);
			State.AddSingledAllowedTransitionFrom(FromState<EnumClientRequests>.Null);
			State.LinkStates(States);
			var ObjectIntoStateForHandle = new KeyValuePair<EnumClientRequests, object>(
				EnumClientRequests.GetAuthorization, null);
			//Act
			State.Handle(ObjectIntoStateForHandle);
			//Assert
			Array.ForEach(MockExecutors, MockExecutor => MockExecutor.Received().SetDefault());
		}
	}
}