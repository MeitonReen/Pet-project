﻿
using System.Collections.ObjectModel;

using Layer0_Client.InterfacesForProcessingDataContexts;
using Layer0_Client.DataContextsForBindings.CreateOrder;
using Layer1_CommunicatorsBtwLay0AndLay2.
	TruncatedDataFromGatewayToDatabaseForLayer0;
using Layer2_ApplicationUseCases.DataAboutClientRequest;

namespace Layer0_Client.ProcessingDataContexts.CreateOrder
{
	public class GetAttributesForCargoFromCargosInOrder : 
		IGetterFromDataContextForClientRequest
	{
		private DCCreateOrder DCCargosInOrder;

		public GetAttributesForCargoFromCargosInOrder(
			DCCreateOrder dCCargosInOrder)
		{
			DCCargosInOrder = dCCargosInOrder;
		}

		public object Get()
		{
			return null;
		}
	}
}
