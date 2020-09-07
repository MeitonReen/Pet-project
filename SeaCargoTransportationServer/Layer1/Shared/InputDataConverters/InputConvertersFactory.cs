using System.Collections.Generic;

using Layer1.CreatingOrder.InputDataConverters;
using SharedDTOs.DataAboutClientRequests;
using Layer1.Authentification.InputDataConverters;
using Layer1.MainMenu.InputDataConverters;
using Shared;
using Shared.Dictionary;

namespace Layer1.Shared.InputDataConverters
{
	public class InputConvertersFactory
	{
		DictionaryOfHandlers<EnumClientRequests> InputConverters =
			new DictionaryOfHandlers<EnumClientRequests>();

		public DictionaryOfHandlers<EnumClientRequests> CreateInputConverters()
		{
			Create();

			return InputConverters;
		}

		private void Create()
		{
			InputConverters.AddRange(
				new KeyValuePair<EnumClientRequests, IHandler>[]
				{
					new KeyValuePair<EnumClientRequests, IHandler>
					(
						EnumClientRequests.SetNewOrder,
						new SetNewOrderConverter()
					),
					new KeyValuePair<EnumClientRequests, IHandler>
					(
						EnumClientRequests.GetAuthorization,
						new GetAuthorization()
					),
					new KeyValuePair<EnumClientRequests, IHandler>
					(
						EnumClientRequests.SetCancelOrder,
						new SetCancelOrder()
					)
				});
		}
	}
}
