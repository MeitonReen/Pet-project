using System;
using System.Collections.Generic;

namespace lvl2_ApplicationUseCases.GatewayToDatabase
{
    public partial class OrdersOnFligths
    {
        public DateTime DateTimeOfFlight { get; set; }
        public int Idships { get; set; }
        public int Idorder { get; set; }
        public int Idclient { get; set; }

        public virtual FlightsSchedule FlightsSchedule { get; set; }
        public virtual Orders Id { get; set; }
    }
}
