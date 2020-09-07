using System;
using System.Collections.Generic;

namespace Layer2.Shared.GatewayToDatabase
{
    public partial class Ships
    {
        public Ships()
        {
            FlightsSchedule = new HashSet<FlightsSchedule>();
            StatusesShips = new HashSet<StatusesShips>();
        }

        public int Idships { get; set; }
        public string ShipNumber { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public int? AmountFreeSpace { get; set; }
        public int? IdsizesShips { get; set; }
        public int? IdtypesShips { get; set; }

        public virtual SizesShips IdsizesShipsNavigation { get; set; }
        public virtual TypesShips IdtypesShipsNavigation { get; set; }
        public virtual ICollection<FlightsSchedule> FlightsSchedule { get; set; }
        public virtual ICollection<StatusesShips> StatusesShips { get; set; }
    }
}
