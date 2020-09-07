using System;

using SharedDTOsByServer.CreatingOrder;

namespace SharedDTOsByClient.CreatingOrder
{
	[Serializable]
	public class AttributeForCargoLayer0 : ICloneable
	{
		public int IdattributesForCargos { get; set; }
		public string Name { get; set; }
		public bool IsSelected { get; set; }

		public object Clone()
		{
			return new AttributeForCargoLayer0
			{
				IdattributesForCargos = IdattributesForCargos,
				Name = Name,
				IsSelected = IsSelected
			};
		}
		public CargoAttributeLayer2 ToCargoAttributeLayer2()
		{
			return new CargoAttributeLayer2()
			{
				IdattributesForCargos = IdattributesForCargos
			};
		}
	}
}
