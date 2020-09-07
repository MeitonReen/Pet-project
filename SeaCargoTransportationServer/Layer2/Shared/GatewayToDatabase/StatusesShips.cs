using System;
using System.Collections.Generic;

namespace Layer2.Shared.GatewayToDatabase
{
    public partial class StatusesShips
    {
        public int IdstatusesShips { get; set; }
        public int Idships { get; set; }
        public DateTime DateTimeStatusWasSet { get; set; }
        public int IdstatusesForShips { get; set; }

        public virtual Ships IdshipsNavigation { get; set; }
        public virtual StatusesForShips IdstatusesForShipsNavigation { get; set; }
    }
}
