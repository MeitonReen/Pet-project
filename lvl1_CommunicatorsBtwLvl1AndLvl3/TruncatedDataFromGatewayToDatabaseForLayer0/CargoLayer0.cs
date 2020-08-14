using System;
using System.Collections.ObjectModel;
using System.Text;

namespace Layer1_CommunicatorsBtwLay0AndLay2.TruncatedDataFromGatewayToDatabaseForLayer0
{
	public class CargoLayer0
	{
		public ObservableCollection<AttributeForCargoLayer0>
			CargoAttributes { get; set; }
		public CargoCharacteristicsLayer0 CargoCharacteristics { get; set; }
		public int Number { get; set; }
		public bool IsSelected { get; set; }

		public CargoLayer0(int number)
		{
			Number = number;
			CargoAttributes = 
				new ObservableCollection<AttributeForCargoLayer0>();
		}
	}
}
