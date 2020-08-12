
using Layer2_ApplicationUseCases.
	TruncatedDataFromGatewayToDatabaseForLayer2.
	Shared;
using Layer2_ApplicationUseCases.
	InterfacesForInteractors;
using Layer2_ApplicationUseCases.DataAboutClientRequest;
using Layer2_ApplicationUseCases.InterfacesForPresenters;
using Layer2_ApplicationUseCases.
	InterfacesForStatesOfInteractors;
using Layer2_ApplicationUseCases.
	SimpleStateMachineForInteractors;
using Layer2_ApplicationUseCases.
	SimpleStateMachineForInteractors.
	Data;
using Layer2_ApplicationUseCases.
	Interactors.
	ClientOrders.
	Steps;

namespace Layer2_ApplicationUseCases.Interactors.ClientOrders
{
	public class ClientOrders : IExecutorOfApplicationUseCase
	{
		private SimpleStateMachineForInteractors<
			object,
			IExecutorOfClientRequest> StateMachine =
			new SimpleStateMachineForInteractors<
				object,
				IExecutorOfClientRequest>();

		private IPresenterOfResponsesToClientRequest PresenterForStepOne = null;
		private IPresenterOfResponsesToClientRequest PresenterForStepTwo = null;

		private ClientLayer2 Client = null;

		public ClientOrders(
			ClientLayer2 client,
			IPresenterOfResponsesToClientRequest presenterForGetClientData,
			IPresenterOfResponsesToClientRequest presenterForGetClientOrders)
		{
			Client = client;
			PresenterForStepOne = presenterForGetClientData;
			PresenterForStepTwo = presenterForGetClientOrders;

			RegistrationSteps();
		}

		private void RegistrationSteps()
		{
			StateMachine.RegistrationState(
				EnumClientRequests.Get_ClientData,
				new StepOne_GetClientData(
					Client, PresenterForStepOne),
				new EnumAttributesState[]
				{ 
					EnumAttributesState.First
				},
				new EnumClientRequests[][]
				{
					new EnumClientRequests[] 
					{ 
						EnumClientRequests.Get_ClientData
					},
					new EnumClientRequests[] 
					{ 
						EnumClientRequests.Get_ClientOrders
					},
					new EnumClientRequests[] 
					{
						EnumClientRequests.Get_ClientData,
						EnumClientRequests.Get_ClientOrders
					}
				}
			);

			StateMachine.RegistrationState(
				EnumClientRequests.Get_ClientOrders,
				new StepTwo_GetClientOrders(
					Client, PresenterForStepTwo),
				new EnumAttributesState[]
				{ 
					EnumAttributesState.First
				},
				new EnumClientRequests[][]
				{
					new EnumClientRequests[] 
					{ 
						EnumClientRequests.Get_ClientData
					},
					new EnumClientRequests[] 
					{ 
						EnumClientRequests.Get_ClientOrders
					},
					new EnumClientRequests[] 
					{
						EnumClientRequests.Get_ClientData,
						EnumClientRequests.Get_ClientOrders
					}
				}
			);
		}

		public bool Execute(DataOfClientRequest dataOfClientRequest)
		{
			//Основная деятельность интерактора в состояниях
			//Тут общий вход во все состояния
			StateMachine.Execute(
				dataOfClientRequest.RequestID,
				dataOfClientRequest.DataForExecutorClientRequests);
			//За ответ клиенту отвечает конкретное состояние интерактора
			return true;
		}
	}
}
