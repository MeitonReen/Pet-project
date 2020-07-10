using System;
using System.Collections.Generic;

namespace lvl1_ApplicationUseCasesByClient.EntityDatabase
{
    public partial class SizesShips
    {
        public SizesShips()
        {
            Ships = new HashSet<Ships>();
        }

        public int IdsizesShips { get; set; }
        public string Name { get; set; }
        public int? Amount { get; set; }

        public virtual ICollection<Ships> Ships { get; set; }
    }
}
