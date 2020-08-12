
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

using Layer0_Client.InterfacesForProcessingDataContexts;
using Layer0_Client.DataContextsForBindings.CreateOrder;
using Layer1_CommunicatorsBtwLay0AndLay2.
	TruncatedDataFromGatewayToDatabaseForLayer0;

namespace Layer0_Client.ProcessingDataContexts.CreateOrder
{
	public class SetAttributesForCargoToDCCreateOrder : 
		ISetterToDataContextsFromResponseToClient
	{
		private DCCreateOrder DCAttributesForCargos;

		public SetAttributesForCargoToDCCreateOrder(
			DCCreateOrder dCAttributesForCargos)
		{
			DCAttributesForCargos = dCAttributesForCargos;
		}

		public ObservableCollection<AttributeForCargoLayer0>
			CopyAttributeForCargoLayer0(
				ObservableCollection<AttributeForCargoLayer0> original)
		{
			ObservableCollection<AttributeForCargoLayer0>
				Copied =
					new ObservableCollection<AttributeForCargoLayer0>();

			foreach(AttributeForCargoLayer0 OriginalItem in
				original)
			{
				AttributeForCargoLayer0 NewItemToCopied = 
					(AttributeForCargoLayer0)OriginalItem.Clone();
				Copied.Add(NewItemToCopied);
			}
			return Copied;
		}

		public void Set(object data)
		{
			ObservableCollection<AttributeForCargoLayer0>
				ResponseData = CopyAttributeForCargoLayer0(
					(ObservableCollection<AttributeForCargoLayer0>)data);
			

			DCAttributesForCargos.GettedAttributesForCargo.Clear();
			foreach(AttributeForCargoLayer0 AttributeForCargoLayer0 in
				ResponseData)
			{
				DCAttributesForCargos.GettedAttributesForCargo.Add(
					AttributeForCargoLayer0);
			}
		
			foreach (CargoLayer0 CargoLayer0 in
				DCAttributesForCargos.Cargos)
			{
				CargoLayer0.CargoAttributes.Clear();

				ResponseData = CopyAttributeForCargoLayer0(
					(ObservableCollection<AttributeForCargoLayer0>)data);

				foreach (AttributeForCargoLayer0 ResponseDataItem in
					ResponseData)
				{
					CargoLayer0.CargoAttributes.
						Add(ResponseDataItem);
				}
				;
			}
			
		}
	}
}
