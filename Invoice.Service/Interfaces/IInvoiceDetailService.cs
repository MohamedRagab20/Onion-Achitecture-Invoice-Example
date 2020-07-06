using System.Collections.Generic;
namespace Invoice.Service
{
    public interface IInvoiceService
    {
        IEnumerable<Invoice.Repository.Migrations.Invoice> GetInvoices();
        Invoice.Repository.Migrations.Invoice GetInvoice(long id);
        void InsertInvoice(Invoice.Repository.Migrations.Invoice invoice);
        void UpdateInvoice(Invoice.Repository.Migrations.Invoice invoice);
        void DeleteInvoice(long id);
    }
}
