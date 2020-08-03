using Layer2_ApplicationUseCases.GatewayToDatabase;
using System;
using System.Collections.Generic;

namespace Layer2_ApplicationUseCases.GatewayToDatabase
{
	public partial class TypesShipsImplementCargoAttributes
    {
        public int IdtypesShips { get; set; }
        public int IdattributesForCargos { get; set; }

        public virtual AttributesForCargos IdattributesForCargosNavigation { get; set; }
        public virtual TypesShips IdtypesShipsNavigation { get; set; }
    }
}
