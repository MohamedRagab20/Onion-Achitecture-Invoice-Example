using Invoice.Repository.Migrations;
using System.Collections.Generic;
namespace Invoice.Service
{
    public interface IInvoiceDetailService
    {
        IEnumerable<InvoiceDetails> GetInvoiceDetails();
        InvoiceDetails GetInvoiceDetail(long id);
        void InsertInvoiceDetail(InvoiceDetails invoiceDetails);
        void UpdateInvoiceDetail(InvoiceDetails invoiceDetails);
        void DeleteInvoiceDetail(long id);
    }
}
