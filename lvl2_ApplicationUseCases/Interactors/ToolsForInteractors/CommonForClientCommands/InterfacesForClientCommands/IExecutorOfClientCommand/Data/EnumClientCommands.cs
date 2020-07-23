using System;
using System.Collections.Generic;
using System.Text;

namespace lvl2_ApplicationUseCases.
	Interactors.
	ToolsForInteractors.
	CommonForClientCommands.
	InterfacesForClientCommands.
	IExecutorOfClientCommand.
	Data
{
	/// <summary>
	/// Перечисление функций. Контроллер на клиенте знает какую функцию использовать
	/// </summary>
	public enum EnumClientCommands
	{
		CreatingOrder_GetAttributeForCargos,
		CreatingOrder_SetCargosInOrders
	}
}
