using System;
using System.Collections.Generic;

namespace Layer2_ApplicationUseCases.GatewayToDatabase
{
    public partial class Orders
    {
        public Orders()
        {
            CargosInOrders = new HashSet<CargosInOrders>();
            OrdersOnFligths = new HashSet<OrdersOnFligths>();
        }

        public int Idorder { get; set; }
        public int Idclient { get; set; }
        public DateTime? DateTimeCreate { get; set; }
        public string ReceiptNumberOfOrder { get; set; }

        public virtual Clients IdclientNavigation { get; set; }
        public virtual ICollection<CargosInOrders> CargosInOrders { get; set; }
        public virtual ICollection<OrdersOnFligths> OrdersOnFligths { get; set; }
    }
}
