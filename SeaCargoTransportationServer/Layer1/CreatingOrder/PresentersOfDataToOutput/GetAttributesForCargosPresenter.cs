
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Layer1.Shared.PresentersOfDataToOutput;
using Layer2.Shared.GatewayToDatabase;
using SharedDTOsByClient.CreatingOrder;

namespace Layer1.CreatingOrder.PresentersOfDataToOutput
{
	public class GetAttributesForCargosPresenter : AbstractPresenterOfDataToOutput
	{

		protected override object Present(object data)
		{
			List<AttributesForCargos> attributesForCargosFromInteractor =
				(List<AttributesForCargos>)data;

			ObservableCollection<AttributeForCargoLayer0> PresentationData =
				new ObservableCollection<AttributeForCargoLayer0>();

			foreach (AttributesForCargos AttributesForCargos in
				attributesForCargosFromInteractor)
			{
				AttributeForCargoLayer0 PresentationDataItem =
					new AttributeForCargoLayer0()
					{
						IdattributesForCargos = AttributesForCargos.IdattributesForCargos,
						Name = AttributesForCargos.Name,
						IsSelected = false
					};

				PresentationData.Add(PresentationDataItem);
			}

			return PresentationData;
		}

	}
}
