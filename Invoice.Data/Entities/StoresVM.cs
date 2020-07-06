using System.Collections.Generic;

namespace Invoice.Data.Entities
{
    public partial class StoresVM
    {
        public StoresVM()
        {
            Invoice = new HashSet<InvoiceVM>();
        }
        public int Id { get; set; }
        public string StoreName { get; set; }

        public virtual ICollection<InvoiceVM> Invoice { get; set; }
    }
}
