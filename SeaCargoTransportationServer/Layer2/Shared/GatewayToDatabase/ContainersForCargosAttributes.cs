using Layer2.Shared.GatewayToDatabase;
using System;
using System.Collections.Generic;

namespace Layer2.Shared.GatewayToDatabase
{
	public partial class ContainersForCargosAttributes
    {
        public int Idcontainers { get; set; }
        public int IdattributesForCargos { get; set; }

        public virtual AttributesForCargos IdattributesForCargosNavigation { get; set; }
        public virtual Containers IdcontainersNavigation { get; set; }
    }
}
