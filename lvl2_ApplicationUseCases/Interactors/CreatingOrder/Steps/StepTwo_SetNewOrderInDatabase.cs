
using Layer2_ApplicationUseCases.
	InterfacesForStatesOfInteractors;
using Layer2_ApplicationUseCases.GatewayToDatabase;
using Layer2_ApplicationUseCases.GatewayToDatabase.Context;


namespace Layer2_ApplicationUseCases.Interactors.CreatingOrder.States
{
	public class StepTwo_SetNewOrderInDatabase : IExecutorOfClientRequest
	{
		private CargosInOrders CargosInOrders = null;

		private SeaCargoTransportationContext Database =
			new SeaCargoTransportationContext();

		public object Execute(object dataOfClientRequest)
		{
			CargosInOrders = (CargosInOrders)dataOfClientRequest;


			return null;
		}
		public void ClearRequest()
		{
			//Скорее всего придётся Database освобождать
		}
	}
}
