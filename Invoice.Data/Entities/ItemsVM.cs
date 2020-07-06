using System.Collections.Generic;

namespace Invoice.Data.Entities
{
    public partial class ItemsVM
    {
        public ItemsVM()
        {
            InvoiceDetails = new HashSet<InvoiceDetailsVM>();
        }
        public int Id { get; set; }
        public string ItemName { get; set; }

        public virtual ICollection<InvoiceDetailsVM> InvoiceDetails { get; set; }
    }
}
