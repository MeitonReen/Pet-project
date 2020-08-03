
using System.Collections.Generic;
using System.Linq;

using Layer0_Client.InterfacesForProcessingDataContexts;
using Layer0_Client.DataContextsForBindings;
using Layer2_ApplicationUseCases.
	TruncatedDataFromGatewayToDatabaseForRequestsFromClient.
	SetNewOrderInDatabase;

namespace Layer0_Client.GettersFromDataContexts
{
	public class GetCargosInOrders : IGetterFromDataContextForClientRequest
	{
		private DCCargosInOrders DCCargosInOrders;

		public GetCargosInOrders(DCCargosInOrders dCCargosInOrders)
		{
			DCCargosInOrders = dCCargosInOrders;
		}
		
		public object Get()
		{
			List<Cargo> Cargos = new List<Cargo>();
			Cargos = DCCargosInOrders.Cargos.ToList();

			return Cargos;
		}
	}
}
