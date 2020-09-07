using System;
using System.Collections.Generic;

namespace Layer2.Shared.GatewayToDatabase
{
    public partial class Containers
    {
        public Containers()
        {
            CargosInOrders = new HashSet<CargosInOrders>();
            ContainersCharacteristics = new HashSet<ContainersCharacteristics>();
            ContainersForCargosAttributes = new HashSet<ContainersForCargosAttributes>();
        }

        public int Idcontainers { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CargosInOrders> CargosInOrders { get; set; }
        public virtual ICollection<ContainersCharacteristics> ContainersCharacteristics { get; set; }
        public virtual ICollection<ContainersForCargosAttributes> ContainersForCargosAttributes { get; set; }
    }
}
