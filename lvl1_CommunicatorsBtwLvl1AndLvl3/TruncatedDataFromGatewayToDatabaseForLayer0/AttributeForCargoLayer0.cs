using System;

namespace Layer1_CommunicatorsBtwLay0AndLay2.
	TruncatedDataFromGatewayToDatabaseForLayer0
{
	public class AttributeForCargoLayer0 : ICloneable
	{
		public int IdattributesForCargos { get; set; }
		public string Name { get; set; }
		public bool IsSelected { get; set; }

		public object Clone()
		{
			return new AttributeForCargoLayer0
			{
				IdattributesForCargos = this.IdattributesForCargos,
				Name = this.Name,
				IsSelected = this.IsSelected
			};
		}
	}
}
