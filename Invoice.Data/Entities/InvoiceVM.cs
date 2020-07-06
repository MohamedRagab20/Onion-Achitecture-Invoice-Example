using System;
using System.Collections.Generic;

namespace Invoice.Data.Entities
{
    public partial class InvoiceVM
    {
        public InvoiceVM()
        {
            InvoiceDetails = new HashSet<InvoiceDetailsVM>();
        }
        public int Id { get; set; }
        public int? InvoiceNo { get; set; }
        public int StoreId { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public decimal? Total { get; set; }
        public decimal? Taxes { get; set; }
        public decimal? Net { get; set; }

        public virtual StoresVM Store { get; set; }
        public virtual ICollection<InvoiceDetailsVM> InvoiceDetails { get; set; }
    }
}
