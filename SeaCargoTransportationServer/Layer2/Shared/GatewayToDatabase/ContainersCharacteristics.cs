using System;
using System.Collections.Generic;

namespace Layer2.Shared.GatewayToDatabase
{
    public partial class ContainersCharacteristics
    {
        public int IdcontainersCharacteristics { get; set; }
        public decimal? Weight { get; set; }
        public decimal? LenghtOut { get; set; }
        public decimal? WidthOut { get; set; }
        public decimal? HeightOut { get; set; }
        public decimal? AmountOut { get; set; }
        public decimal? LenghtIn { get; set; }
        public decimal? HeightIn { get; set; }
        public decimal? WidthIn { get; set; }
        public decimal? AmountIn { get; set; }
        public int? Idcontainers { get; set; }

        public virtual Containers IdcontainersNavigation { get; set; }
    }
}
