using System;
using System.Collections.Generic;

namespace Invoice.Repository.Migrations
{
    public partial class InvoiceDetails : BaseEntity
    {
        public int InvoiceId { get; set; }
        public int ItemId { get; set; }
        public int UnitId { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public decimal? Total { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Net { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual Items Item { get; set; }
        public virtual Units Unit { get; set; }
    }
}
