using System;
using System.Collections.Generic;

namespace Layer2_ApplicationUseCases.GatewayToDatabase
{
	public partial class AttributesForCargos
	{
		public AttributesForCargos()
		{
			CargosAttributes = new HashSet<CargosAttributes>();
			ContainersForCargosAttributes = new HashSet<ContainersForCargosAttributes>();
			TypesShipsImplementCargoAttributes = new HashSet<TypesShipsImplementCargoAttributes>();
		}

		public int IdattributesForCargos { get; set; }
		public string Name { get; set; }

		public virtual ICollection<CargosAttributes> CargosAttributes { get; set; }
		public virtual ICollection<ContainersForCargosAttributes> ContainersForCargosAttributes { get; set; }
		public virtual ICollection<TypesShipsImplementCargoAttributes> TypesShipsImplementCargoAttributes { get; set; }
	}
}
