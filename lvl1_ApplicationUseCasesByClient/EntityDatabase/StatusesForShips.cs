using System;
using System.Collections.Generic;

namespace lvl1_ApplicationUseCasesByClient.EntityDatabase
{
    public partial class StatusesForShips
    {
        public StatusesForShips()
        {
            StatusesShips = new HashSet<StatusesShips>();
        }

        public int IdstatusesForShips { get; set; }
        public string Status { get; set; }

        public virtual ICollection<StatusesShips> StatusesShips { get; set; }
    }
}
