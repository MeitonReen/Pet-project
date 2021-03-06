﻿using System;
using System.Collections.Generic;

namespace Layer2.Shared.GatewayToDatabase
{
    public partial class StatusesForFligths
    {
        public StatusesForFligths()
        {
            StatusesFligths = new HashSet<StatusesFligths>();
        }

        public int IdstatusesForFligths { get; set; }
        public string Status { get; set; }

        public virtual ICollection<StatusesFligths> StatusesFligths { get; set; }
    }
}
