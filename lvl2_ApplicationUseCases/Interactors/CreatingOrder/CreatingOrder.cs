
using Layer2_ApplicationUseCases.
	InterfacesForStatesOfInteractors;
using Layer2_ApplicationUseCases.
	SimpleStateMachineForInteractors;
using Layer2_ApplicationUseCases.
	DataAboutClientRequest;
using Layer2_ApplicationUseCases.
	InterfacesForPresenters;
using Layer2_ApplicationUseCases.
	InterfacesForInteractors;
using Layer2_ApplicationUseCases.
	Interactors.
	CreatingOrder.
	States;
using Layer2_ApplicationUseCases.
	SimpleStateMachineForInteractors.
	Data;

using Layer2_ApplicationUseCases.
	TruncatedDataFromGatewayToDatabaseForLayer2.
	Shared;

namespace Layer2_ApplicationUseCases.
	Interactors.
	CreatingOrder
{
	/*Идея:
		Одно приложение целиком для одного пользователя.
		Один вариант использования пользователем реализуется одним интерактором.
		Для завершения одного варианта использования может быть необходимо
	несколько запросов пользователя к интерактору и несколько ответов пользователю от
	интерактора.
		Контроллер со стороны клиента знает какой запрос нужно отослать интерактору (через
	контроллер на стороне интерактора) по действию пользователя.
		Контроллер со стороны интерактора знает какой запрос какому интерактору отослать.
		Интерактор (напомню - который реализует один вариант использования) хранит
	перечень этапов для реализации подответственного ему варианта использования.
		Этапы вместе определяют состояние прогресса варианта использования.
		Этапы представляют конечный автомат. На какие-то этапы возвращаться можно, на
	какие-то нельзя.
		Есть такие этапы, которые могут отменить другие этапы или отменить весь вариант
	использования.
		База данных обновляется полностью только после успешного завершения варианта
	использования.
		Короче, кажется тут паттерн Состояние. Хорошо бы изучить и утвердить если подойдёт.
		UPD: подойдёт одна из модификаций
		Сделаем просто словарь состояний и будем помнить какое состояние было обработано
		Связывание состояний (ограничения переходов) внутри состояний пока
		Прост знаем где мы были и для каждого состояния знаем откуда к нему можно было прийти
	*/
	public class CreatingOrder : IExecutorOfApplicationUseCase
	{
		private SimpleStateMachineForInteractors<
			object,
			IExecutorOfClientRequest> StateMachine =
			new SimpleStateMachineForInteractors<
				object,
				IExecutorOfClientRequest>();
		private IPresenterOfResponsesToClientRequest PresenterForStepOne;
		public ClientLayer2 Client;

		public CreatingOrder(
			ClientLayer2 client,
			IPresenterOfResponsesToClientRequest presenter)
		{
			PresenterForStepOne = presenter;
			Client = client;

			RegistrationSteps();
		}

		public bool Execute(DataOfClientRequest dataOfClientRequest)
		{
			//Основная деятельность интерактора в состояниях
			//Тут общий вход во все состояния
			object Result =  StateMachine.Execute(
				dataOfClientRequest.RequestID,
				dataOfClientRequest.DataForExecutorClientRequests);


			return true;
		}
		/// <summary>
		/// EnumClientRequests[][] - в каждой строке множество прошедших
		/// состояний из которых можно переходить в создаваемое состояние
		/// например в состояние 3 можно перейти из {1 и 2} или из {1 и 3}
		/// или из {1} или из {3}. Таким образом, например, если мы были только
		/// во 2, то к 3 переход запрещён
		/// </summary>
		private void RegistrationSteps()
		{
			StateMachine.RegistrationState(
				EnumClientRequests.CreatingOrder_GetAttributeForCargos,
				new StepOne_GetAttributesForCargos(PresenterForStepOne),
				new EnumAttributesState[]
				{ 
					EnumAttributesState.First
				},
				new EnumClientRequests[][]
				{
					new EnumClientRequests[] 
					{ 
						EnumClientRequests.CreatingOrder_GetAttributeForCargos
					}
				}
				
			);

			StateMachine.RegistrationState(
				EnumClientRequests.CreatingOrder_SetCargosInOrders,
				new StepTwo_SetNewOrderInDatabase(Client),
				new EnumAttributesState[]
				{ 
					EnumAttributesState.Last
				},
				new EnumClientRequests[][]
				{
					new EnumClientRequests[] 
					{ 
						EnumClientRequests.CreatingOrder_GetAttributeForCargos
					}
				}
				
			);
		}

	}
}
