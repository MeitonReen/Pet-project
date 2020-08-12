using System;
using System.Collections.Generic;

namespace Layer2_ApplicationUseCases.GatewayToDatabase
{
    public partial class CargosAttributes
    {
        public int IdattributesForCargos { get; set; }
        public int IdcargosInOrders { get; set; }

        public virtual AttributesForCargos IdattributesForCargosNavigation { get; set; }
        public virtual CargosInOrders IdcargosInOrdersNavigation { get; set; }
    }
}
