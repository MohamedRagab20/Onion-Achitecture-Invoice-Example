using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice.Web.Models
{
    public class InvoiceViewModel
    {
        public string InvoiceNo { get; set; }
        public string StoreId { get; set; }
        public string Total { get; set; }
        public string Taxes { get; set; }
        public string Net { get; set; }

        public List<InvoiceDetailViewModel> invoiceDetails { get; set; }
    }
}
