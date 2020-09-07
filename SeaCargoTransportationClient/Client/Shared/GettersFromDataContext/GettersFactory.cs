using System.Collections.Generic;

using Layer0_Client.CreatingOrder.ClientPresenters;
using SharedDTOs.DataAboutClientRequests;
using Layer0_Client.Authentification.GettersFromDataContext;
using Layer0_Client.MainMenu.GettersFromDataContext;
using Shared.Dictionary;
using Shared;

namespace Layer0_Client.Shared.Create.ClientPresenters
{
	public class GettersFactory
	{
		DictionaryOfHandlers<EnumClientRequests> GettersFromDataContext =
			new DictionaryOfHandlers<EnumClientRequests>();

		private object DataContext = null;

		public GettersFactory(object dataContext)
		{
			DataContext = dataContext;
		}
		public DictionaryOfHandlers<EnumClientRequests> CreateGetters()
		{
			Create();
			
			return GettersFromDataContext;
		}
		public DictionaryOfHandlers<EnumClientRequests> CreateGettersByClientRequestsIDs(
			EnumClientRequests[] clientRequestIDs)
		{
			Create();
			ExcludeGettersByClientRequestIDs(clientRequestIDs);

			return GettersFromDataContext;
		}

		private void ExcludeGettersByClientRequestIDs(
			EnumClientRequests[] clientRequestIDs)
		{
			GettersFromDataContext.ExcludeByKeys(clientRequestIDs);
		}

		private void Create()
		{
			GettersFromDataContext.AddRange(
				new KeyValuePair<EnumClientRequests, IHandler>[]
				{
					new KeyValuePair<EnumClientRequests, IHandler>
					(
						EnumClientRequests.SetNewOrder,
						new CreateOrder(DataContext)
					),
					new KeyValuePair<EnumClientRequests, IHandler>
					(
						EnumClientRequests.GetAuthorization,
						new GetAuthorization(DataContext)
					),
					new KeyValuePair<EnumClientRequests, IHandler>
					(
						EnumClientRequests.SetCancelOrder,
						new SetOrderCancel(DataContext)
					)
				});
		}
	}
}
