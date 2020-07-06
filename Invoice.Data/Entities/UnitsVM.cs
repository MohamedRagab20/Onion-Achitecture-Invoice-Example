using System.Collections.Generic;

namespace Invoice.Data.Entities
{
    public partial class UnitsVM
    {
        public UnitsVM()
        {
            InvoiceDetails = new HashSet<InvoiceDetailsVM>();
        }
        public int Id { get; set; }
        public string UnitName { get; set; }

        public virtual ICollection<InvoiceDetailsVM> InvoiceDetails { get; set; }
    }
}
