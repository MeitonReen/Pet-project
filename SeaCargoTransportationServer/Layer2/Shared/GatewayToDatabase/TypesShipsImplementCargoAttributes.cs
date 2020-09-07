using Layer2.Shared.GatewayToDatabase;
using System;
using System.Collections.Generic;

namespace Layer2.Shared.GatewayToDatabase
{
	public partial class TypesShipsImplementCargoAttributes
    {
        public int IdtypesShips { get; set; }
        public int IdattributesForCargos { get; set; }

        public virtual AttributesForCargos IdattributesForCargosNavigation { get; set; }
        public virtual TypesShips IdtypesShipsNavigation { get; set; }
    }
}
