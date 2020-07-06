using Invoice.Data.Entities;
using Invoice.Repository;
using Invoice.Repository.Migrations;
using System;
using System.Collections.Generic;

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
