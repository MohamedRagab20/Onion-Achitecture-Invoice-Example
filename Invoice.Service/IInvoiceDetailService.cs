using System;
using System.Collections.Generic;
using Invoice.Data.Models;
namespace Invoice.Service
{
    public interface IInvoiceService
    {
        IEnumerable<Invoice.Data.Models.Invoice> GetInvoices();
        Invoice.Data.Models.Invoice GetInvoice(long id);
        void InsertInvoice(Invoice.Data.Models.Invoice invoice);
        void UpdateInvoice(Invoice.Data.Models.Invoice invoice);
        void DeleteInvoice(long id);
    }
}
