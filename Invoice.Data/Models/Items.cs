using System;
using System.Collections.Generic;

namespace Invoice.Data.Models
{
    public partial class Items : BaseEntity
    {
        public Items()
        {
            InvoiceDetails = new HashSet<InvoiceDetails>();
        }

        public string ItemName { get; set; }

        public virtual ICollection<InvoiceDetails> InvoiceDetails { get; set; }
    }
}
