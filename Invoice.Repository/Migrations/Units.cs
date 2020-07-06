using System;
using System.Collections.Generic;

namespace Invoice.Repository.Migrations
{
    public partial class Units : BaseEntity
    {
        public Units()
        {
            InvoiceDetails = new HashSet<InvoiceDetails>();
        }

        public string UnitName { get; set; }

        public virtual ICollection<InvoiceDetails> InvoiceDetails { get; set; }
    }
}
