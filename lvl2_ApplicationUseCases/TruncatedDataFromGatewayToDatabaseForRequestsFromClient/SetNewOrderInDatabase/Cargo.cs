
using System.Collections.Generic;

namespace Layer2_ApplicationUseCases.
	TruncatedDataFromGatewayToDatabaseForRequestsFromClient.
    SetNewOrderInDatabase
{
    public class Cargo
	{
        public List<CargoAttribute> 
            CargoAttribute { get; set; }
        public CargoCharacteristics
            CargoCharacteristics { get; set; }
        public Cargo()
        {
            CargoAttribute = 
                new List<CargoAttribute>();
            CargoCharacteristics = new CargoCharacteristics();
        }

    }
}
