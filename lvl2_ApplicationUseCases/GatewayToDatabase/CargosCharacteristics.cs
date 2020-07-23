using System;
using System.Collections.Generic;

namespace lvl2_ApplicationUseCases.GatewayToDatabase
{
    public partial class CargosCharacteristics
    {
        public int IdcargosCharacteristics { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Length { get; set; }
        public decimal? Wigth { get; set; }
        public decimal? Height { get; set; }
        public decimal? Amount { get; set; }
        public int? IdcargosInOrders { get; set; }

        public virtual CargosInOrders IdcargosInOrdersNavigation { get; set; }
    }
}
