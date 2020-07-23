﻿using System;
using System.Collections.Generic;

namespace lvl2_ApplicationUseCases.GatewayToDatabase
{
    public partial class TypesShips
    {
        public TypesShips()
        {
            Ships = new HashSet<Ships>();
            TypesShipsImplementCargoAttributes = new HashSet<TypesShipsImplementCargoAttributes>();
        }

        public int IdtypesShips { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Ships> Ships { get; set; }
        public virtual ICollection<TypesShipsImplementCargoAttributes> TypesShipsImplementCargoAttributes { get; set; }
    }
}
