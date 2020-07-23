﻿using System;
using System.Collections.Generic;

namespace lvl2_ApplicationUseCases.GatewayToDatabase
{
    public partial class TypesOfFlights
    {
        public TypesOfFlights()
        {
            FlightsSchedule = new HashSet<FlightsSchedule>();
        }

        public int IdtypesOfFlights { get; set; }
        public string Name { get; set; }

        public virtual ICollection<FlightsSchedule> FlightsSchedule { get; set; }
    }
}
