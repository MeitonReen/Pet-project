
using System.Collections.ObjectModel;


using Layer1_CommunicatorsBtwLvl1AndLvl3.
	TruncatedDataFromGatewayToDatabaseForResponsesToClient;

namespace Layer0_Client.DataContextsForBindings
{
	public class DCAttributesForCargos
	{
		public ObservableCollection<AttributeForCargo> AttributesForCargos { get; set; } = 
			new ObservableCollection<AttributeForCargo>();

		public void SetNewData(object responseData)
		{
			ObservableCollection<AttributeForCargo> ResponseData =
				(ObservableCollection<AttributeForCargo>)responseData;
			
			AttributesForCargos.Clear();

			foreach (AttributeForCargo ResponseDataItem in
				ResponseData)
			{
				AttributesForCargos.Add(ResponseDataItem);
			}
		}

		
	}
}
