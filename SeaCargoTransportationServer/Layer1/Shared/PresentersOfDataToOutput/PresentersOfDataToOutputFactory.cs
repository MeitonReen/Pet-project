using System.Collections.Generic;

using Layer1.Authentification.PresentersOfDataToOutput;
using Layer1.CreatingOrder.PresentersOfDataToOutput;
using Layer1.MainMenu.PresentersOfDataToOutput;
using Shared;
using Shared.Dictionary;
using SharedDTOs.DataAboutClientRequests;

namespace Layer1.Shared.PresentersOfDataToOutput
{
	public class PresentersOfDataToOutputFactory
	{
		DictionaryOfHandlers<EnumClientRequests> PresentersOfDataToOutput =
			new DictionaryOfHandlers<EnumClientRequests>();

		public DictionaryOfHandlers<EnumClientRequests> CreatePresenters()
		{
			Create();

			return PresentersOfDataToOutput;
		}

		private void Create()
		{
			PresentersOfDataToOutput.AddRange(
				new KeyValuePair<EnumClientRequests, IHandler>[]
				{
					new KeyValuePair<EnumClientRequests,IHandler>
					(
						EnumClientRequests.GetAttributeForCargos,
						new GetAttributesForCargosPresenter()
					),
					new KeyValuePair<EnumClientRequests, IHandler>
					(
						EnumClientRequests.GetFlightsSchedule,
						new GetFlightsSchedulePresenter()
					),
					new KeyValuePair<EnumClientRequests, IHandler>
					(
						EnumClientRequests.GetClientData,
						new GetClientDataPresenter()
					),
					new KeyValuePair<EnumClientRequests, IHandler>
					(
						EnumClientRequests.GetClientOrders,
						new GetClientOrdersPresenter()
					),
					new KeyValuePair<EnumClientRequests, IHandler>
					(
						EnumClientRequests.GetAuthorization,
						new GetAuthorizationPresenter()
					)
				});
		}
	}
}
