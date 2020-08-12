﻿
using System.Collections.Generic;
using System.Linq;

using Layer2_ApplicationUseCases.
	InterfacesForStatesOfInteractors;
using Layer2_ApplicationUseCases.GatewayToDatabase.Context;
using Layer2_ApplicationUseCases.GatewayToDatabase;
using Layer2_ApplicationUseCases.InterfacesForPresenters;
using Layer2_ApplicationUseCases.DataAboutClientRequest;

namespace Layer2_ApplicationUseCases.Interactors.CreatingOrder.States
{
	public class StepOne_GetAttributesForCargos : IExecutorOfClientRequest
	{
		private SeaCargoTransportationContext Database =
			new SeaCargoTransportationContext();
		private IPresenterOfResponsesToClientRequest Presenter = null;

		public StepOne_GetAttributesForCargos(
			IPresenterOfResponsesToClientRequest presenter)
		{
			Presenter = presenter;
		}
		
		public void ClearRequest()
		{
			//Скорее всего придётся Database освобождать
			
		}

		public bool Execute(EnumClientRequests RequestID, object dataOfClientRequest)
		{
			List<AttributesForCargos> AttributesForCargos = 
				Database.AttributesForCargos.ToList();

			object Result = AttributesForCargos;
			Presenter.PresentAndSend(RequestID, Result);
			
			return true;
		}
	}
}
