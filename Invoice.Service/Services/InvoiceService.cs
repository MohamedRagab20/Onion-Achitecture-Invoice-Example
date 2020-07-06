using Invoice.Data.Entities;
using Invoice.Repository;
using Invoice.Repository.Migrations;
using System;
using System.Collections.Generic;

namespace Invoice.Service
{
    public class InvoiceService : IInvoiceService
    {
        private readonly Repository.IRepository<Invoice.Repository.Migrations.Invoice> repository;
        private readonly DynamcisLinkDBContext _context;
        private readonly IInvoiceDetailService invDetailsService;

        public InvoiceService(IRepository<Invoice.Repository.Migrations.Invoice> repository, DynamcisLinkDBContext _context, IInvoiceDetailService invDetailsService)
        {
            this.repository = repository;
            this._context = _context;
            this.invDetailsService = invDetailsService;
        }

        public void DeleteInvoice(long id)
        {
            throw new NotImplementedException();
        }

        public Invoice.Repository.Migrations.Invoice GetInvoice(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Invoice.Repository.Migrations.Invoice> GetInvoices()
        {
            return repository.GetAll();
        }

        public void InsertInvoice(Invoice.Repository.Migrations.Invoice invoice)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                {
                    repository.Insert(invoice);
                    try
                    {
                        foreach (InvoiceDetails detail in invoice.InvoiceDetails)
                        {
                            detail.InvoiceId = invoice.Id;
                            invDetailsService.InsertInvoiceDetail(detail);
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                    }
                }
                repository.SaveChanges();
            }
        }
        public void UpdateInvoice(Invoice.Repository.Migrations.Invoice invoice)
        {
            throw new NotImplementedException();
        }
    }
}
