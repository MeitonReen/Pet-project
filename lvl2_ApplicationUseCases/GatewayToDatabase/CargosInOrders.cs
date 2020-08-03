using System;
using System.Collections.Generic;

namespace Layer2_ApplicationUseCases.GatewayToDatabase
{
    public partial class CargosInOrders
    {
        public CargosInOrders()
        {
            CargosAttributes = new HashSet<CargosAttributes>();
            CargosCharacteristics = new HashSet<CargosCharacteristics>();
        }

        public int IdcargosInOrders { get; set; }
        public int? Idorder { get; set; }
        public int? Idclient { get; set; }
        public int? Idcontainers { get; set; }

        public virtual Orders Id { get; set; }
        public virtual Containers IdcontainersNavigation { get; set; }
        public virtual ICollection<CargosAttributes> CargosAttributes { get; set; }
        public virtual ICollection<CargosCharacteristics> CargosCharacteristics { get; set; }
    }
}
