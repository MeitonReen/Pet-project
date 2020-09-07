using System.Collections.Generic;

using Layer0_Client.CreatingOrder.SettersToDataContext;
using SharedDTOs.DataAboutClientRequests;
using Layer0_Client.Authentification.SettersToDataContext;
using Layer0_Client.MainMenu.SettersToDataContext;
using Shared.Dictionary;
using Shared;

namespace Layer0_Client.Shared.Create.SettersToDataContext
{
	public class SettersToDataContextFactory
	{
		DictionaryOfHandlers<EnumClientRequests> SettersToDataContext =
			new DictionaryOfHandlers<EnumClientRequests>();

		object DataContext = null;
		public SettersToDataContextFactory(object dataContext)
		{
			DataContext = dataContext;
		}

		public DictionaryOfHandlers<EnumClientRequests> CreateSetters()
		{
			Create();

			return SettersToDataContext;
		}

		public DictionaryOfHandlers<EnumClientRequests> CreateSettersByClientRequestsIDs(
			EnumClientRequests[] clientRequestIDs)
		{
			Create();
			ExcludeSettersByClientRequestIDs(clientRequestIDs);

			return SettersToDataContext;
		}

		private void ExcludeSettersByClientRequestIDs(
			EnumClientRequests[] clientRequestIDs)
		{
			SettersToDataContext.ExcludeByKeys(clientRequestIDs);
		}

		private void Create()
		{
			SettersToDataContext.AddRange(
				new KeyValuePair<EnumClientRequests, IHandler>[]
				{
					new KeyValuePair<EnumClientRequests, IHandler>
					(
						EnumClientRequests.GetAttributeForCargos,
						new AttributesForCargos(DataContext)
					),
					new KeyValuePair<EnumClientRequests, IHandler>
					(
						EnumClientRequests.GetFlightsSchedule,
						new FlightSchedule(DataContext)
					),
					new KeyValuePair<EnumClientRequests, IHandler>
					(
						EnumClientRequests.GetClientData,
						new ClientData(DataContext)
					),
					new KeyValuePair<EnumClientRequests, IHandler>
					(
						EnumClientRequests.GetClientOrders,
						new ClientOrders(DataContext)
					),
					new KeyValuePair<EnumClientRequests, IHandler>
					(
						EnumClientRequests.GetAuthorization,
						new GetAuthorization(DataContext)
					)
				});
		}
	}
}
