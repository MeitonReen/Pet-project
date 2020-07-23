using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using lvl2_ApplicationUseCases.
	Interactors.
	ToolsForInteractors.
	CommonForClientCommands.
	InterfacesForClientCommands.
	IExecutorOfClientCommand;
using lvl2_ApplicationUseCases.GatewayToDatabase.Context;
using lvl2_ApplicationUseCases.GatewayToDatabase;

namespace lvl2_ApplicationUseCases.Interactors.SetOfInteractors.CreatingOrder.States
{
	public class StateTwo_SetNewOrderInDatabase : IExecutorOfClientCommand
	{
		private SeaCargoTransportationContext Database =
			new SeaCargoTransportationContext();

		public object Execute(object dataOfClientCommand)
		{
			
			return null;
		}
		public void ClearCommand()
		{
			//Скорее всего придётся Database освобождать
		}
	}
}
