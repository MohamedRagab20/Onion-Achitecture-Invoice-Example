using System;
using System.Collections.Generic;

namespace Invoice.Repository.Migrations
{
    public partial class Stores : BaseEntity
    {
        public Stores()
        {
            Invoice = new HashSet<Invoice>();
        }

        public string StoreName { get; set; }

        public virtual ICollection<Invoice> Invoice { get; set; }
    }
}
