using lvl1_ApplicationUseCasesByClient.EntityDatabase;
using System;
using System.Collections.Generic;

namespace lvl1_ApplicationUseCasesByClient.EntityDatabase
{
	public partial class ContainersForCargosAttributes
    {
        public int Idcontainers { get; set; }
        public int IdattributesForCargos { get; set; }

        public virtual AttributesForCargos IdattributesForCargosNavigation { get; set; }
        public virtual Containers IdcontainersNavigation { get; set; }
    }
}
