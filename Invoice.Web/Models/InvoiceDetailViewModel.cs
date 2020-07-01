using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice.Web.Models
{
    public class InvoiceDetailViewModel
    {
        public string ItemId { get; set; }
        public string UnitId { get; set; }
        public string Price { get; set; }
        public string Qty { get; set; }
        public string Total { get; set; }
        public string Discount { get; set; }
        public string Net { get; set; }
    }
}
