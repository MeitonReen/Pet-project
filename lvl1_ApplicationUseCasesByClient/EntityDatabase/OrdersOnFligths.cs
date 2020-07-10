using System;
using System.Collections.Generic;

namespace lvl1_ApplicationUseCasesByClient.EntityDatabase
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
