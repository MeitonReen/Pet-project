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
	ToolsForInteractors.
	SimpleStateMachineForInteractors;
using lvl2_ApplicationUseCases.
	Interactors.
	InterfacesForInteractors.
	IExecutorOfApplicationUseCase;

namespace lvl2_ApplicationUseCases.
	Interactors.
	SetOfInteractors.
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
			EnumClientCommands,
			object,
			IExecutorOfClientCommand> StateMachine =
			new SimpleStateMachineForInteractors<
				EnumClientCommands,
				object,
				IExecutorOfClientCommand>();

		private void RegistrationStates()
		{

		}

		public bool Execute(DataOfClientCommand dataOfClientCommand)
		{
			//Основная деятельность интерактора в состояниях
			//Тут общий вход во все состояния
			StateMachine.Execute(
				dataOfClientCommand.CommandID,
				dataOfClientCommand.DataForExecutorClientCommands);
			return true;
		}
		
		

#region Состояния 
		private bool GetAttributeForCargos(object Data)
		{
			return false;
		}

		private bool SetCargosInOrders(object Data)
		{
			return false;
		}
#endregion
	}
}
