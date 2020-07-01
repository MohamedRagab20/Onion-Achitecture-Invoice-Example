using Invoice.Data.Models;
using Invoice.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invoice.Service
{
    public class InvoiceDetailsService : IInvoiceDetailService
    {
        private readonly Repository.IRepository<InvoiceDetails> repository;

        public InvoiceDetailsService(IRepository<InvoiceDetails> repository)
        {
            this.repository = repository;
        }
        public void DeleteInvoiceDetail(long id)
        {
            throw new NotImplementedException();
        }

        public InvoiceDetails GetInvoiceDetail(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InvoiceDetails> GetInvoiceDetails()
        {
            throw new NotImplementedException();
        }

        public void InsertInvoiceDetail(InvoiceDetails invoiceDetails)
        {
            repository.Insert(invoiceDetails);
        }

        public void UpdateInvoiceDetail(InvoiceDetails invoiceDetails)
        {
            throw new NotImplementedException();
        }
    }
}
