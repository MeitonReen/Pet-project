﻿using System;
using System.Collections.Generic;

namespace lvl2_ApplicationUseCases.GatewayToDatabase
{
    public partial class FlightsSchedule
    {
        public FlightsSchedule()
        {
            OrdersOnFligths = new HashSet<OrdersOnFligths>();
            StatusesFligths = new HashSet<StatusesFligths>();
        }

        public int? IdtypesOfFlights { get; set; }
        public DateTime DateTimeOfFlight { get; set; }
        public int Idships { get; set; }

        public virtual Ships IdshipsNavigation { get; set; }
        public virtual TypesOfFlights IdtypesOfFlightsNavigation { get; set; }
        public virtual ICollection<OrdersOnFligths> OrdersOnFligths { get; set; }
        public virtual ICollection<StatusesFligths> StatusesFligths { get; set; }
    }
}
