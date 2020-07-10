using lvl1_ApplicationUseCasesByClient.EntityDatabase;
using System;
using System.Collections.Generic;

namespace lvl1_ApplicationUseCasesByClient.EntityDatabase
{
	public partial class CargosAttributes
    {
        public int IdattributesForCargos { get; set; }
        public int IdcargosInOrders { get; set; }

        public virtual AttributesForCargos IdattributesForCargosNavigation { get; set; }
        public virtual CargosInOrders IdcargosInOrdersNavigation { get; set; }
    }
}
