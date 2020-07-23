using System;
using System.Collections.Generic;

namespace lvl2_ApplicationUseCases.GatewayToDatabase
{
    public partial class StatusesFligths
    {
        public int IdstatusesFligths { get; set; }
        public DateTime DateTimeStatusWasSet { get; set; }
        public DateTime DateTimeOfFlight { get; set; }
        public int Idships { get; set; }
        public int IdstatusesForFligths { get; set; }

        public virtual FlightsSchedule FlightsSchedule { get; set; }
        public virtual StatusesForFligths IdstatusesForFligthsNavigation { get; set; }
    }
}
