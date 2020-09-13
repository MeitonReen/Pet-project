using System.Collections.ObjectModel;

using Layer0_Client.Shared.SettersToDataContext;
using Layer0_Client.CreatingOrder.DataContextForBindingsToWPF;
using SharedDTOsByClient.CreatingOrder;

namespace Layer0_Client.CreatingOrder.SettersToDataContext
{
	public class AttributesForCargos : AbstractSetterToDataContext
	{
		private DCCreatingOrder DCCreatingOrder = null;

		public AttributesForCargos(object dCCreatingOrder)
		{
			DCCreatingOrder = dCCreatingOrder as DCCreatingOrder;
		}
		protected override object SetToDataContext(object presentationData)
		{
			DCCreatingOrder.GettedAttributesForCargo = 
				(ObservableCollection<AttributeForCargoLayer0>)presentationData;
			
			return null;
		}
	}
}
