
using System.Collections.ObjectModel;

using Layer0_Client.InterfacesForProcessingDataContexts;
using Layer1_CommunicatorsBtwLvl1AndLvl3.
	TruncatedDataFromGatewayToDatabaseForResponsesToClient;
using Layer0_Client.DataContextsForBindings;

namespace Layer0_Client.SettersToDataContexts
{
	public class SetAttributesForCargos : ISetterToDataContextsFromResponseToClient
	{
		private DCAttributesForCargos DCAttributesForCargos;

		public void Set(object data)
		{
			ObservableCollection<AttributeForCargo> ResponseData =
				(ObservableCollection<AttributeForCargo>)data;
			
			DCAttributesForCargos.AttributesForCargos.Clear();

			foreach (AttributeForCargo ResponseDataItem in
				ResponseData)
			{
				DCAttributesForCargos.AttributesForCargos.Add(ResponseDataItem);
			}
		}

		
	}
}
