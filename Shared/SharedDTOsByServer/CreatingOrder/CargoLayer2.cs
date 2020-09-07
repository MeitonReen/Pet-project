using System;
using System.Collections.Generic;

namespace SharedDTOsByServer.CreatingOrder
{
	[Serializable]
	public class CargoLayer2
	{
		public List<CargoAttributeLayer2> CargoAttributes { get; set; }
		public CargoCharacteristicsLayer2 CargoCharacteristics { get; set; }
		public CargoLayer2()
		{
			CargoAttributes =
				new List<CargoAttributeLayer2>();
			CargoCharacteristics = new CargoCharacteristicsLayer2();
		}

	}
}
