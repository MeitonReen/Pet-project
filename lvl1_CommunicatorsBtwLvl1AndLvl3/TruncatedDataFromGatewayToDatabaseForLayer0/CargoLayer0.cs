
using System.Collections.ObjectModel;

namespace Layer1_CommunicatorsBtwLay0AndLay2.
    TruncatedDataFromGatewayToDatabaseForLayer0
{
	 public class CargoLayer0
	{
        public int Number { get; set; }
        public ObservableCollection<AttributeForCargoLayer0> 
            CargoAttributes { get; set; }
        public CargoCharacteristicsLayer0
            CargoCharacteristics { get; set; }
        public bool IsSelected { get; set; }
        
        public CargoLayer0()
        {
            CargoAttributes =
                new ObservableCollection<AttributeForCargoLayer0>();
            CargoCharacteristics = new CargoCharacteristicsLayer0();
            IsSelected = true;
        }
        public CargoLayer0(int number)
        {
            Number = number;
            CargoAttributes =
                new ObservableCollection<AttributeForCargoLayer0>();
            CargoCharacteristics = new CargoCharacteristicsLayer0();
        }

    }
}
