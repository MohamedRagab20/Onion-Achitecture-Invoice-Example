using System;
using System.Collections.Generic;

namespace Invoice.Repository.Migrations
{
    public partial class Invoice : BaseEntity
    {
        public Invoice()
        {
            InvoiceDetails = new HashSet<InvoiceDetails>();
        }

        public int? InvoiceNo { get; set; }
        public int StoreId { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public decimal? Total { get; set; }
        public decimal? Taxes { get; set; }
        public decimal? Net { get; set; }

        public virtual Stores Store { get; set; }
        public virtual ICollection<InvoiceDetails> InvoiceDetails { get; set; }
    }
}
