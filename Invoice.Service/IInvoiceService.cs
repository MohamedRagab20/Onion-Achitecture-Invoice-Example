using System;
using System.Collections.Generic;
using Invoice.Data.Models;
namespace Invoice.Service
{
    public interface IInvoiceDetailService
    {
        IEnumerable<Invoice.Data.Models.InvoiceDetails> GetInvoiceDetails();
        Invoice.Data.Models.InvoiceDetails GetInvoiceDetail(long id);
        void InsertInvoiceDetail(Invoice.Data.Models.InvoiceDetails invoiceDetails);
        void UpdateInvoiceDetail(Invoice.Data.Models.InvoiceDetails invoiceDetails);
        void DeleteInvoiceDetail(long id);
    }
}
