
using System.Collections.Generic;
using System.Linq;

using Layer2_ApplicationUseCases.
	InterfacesForStatesOfInteractors;
using Layer2_ApplicationUseCases.GatewayToDatabase.Context;
using Layer2_ApplicationUseCases.GatewayToDatabase;

namespace Layer2_ApplicationUseCases.Interactors.CreatingOrder.States
{
	public class StepOne_GetAttributesForCargos : IExecutorOfClientRequest
	{
		private SeaCargoTransportationContext Database =
			new SeaCargoTransportationContext();

		public object Execute(object dataOfClientRequest)
		{
			List<AttributesForCargos> AttributesForCargos = 
				Database.AttributesForCargos.ToList();

			return AttributesForCargos;
		}
		public void ClearRequest()
		{
			//Скорее всего придётся Database освобождать
			
		}
	}
}
