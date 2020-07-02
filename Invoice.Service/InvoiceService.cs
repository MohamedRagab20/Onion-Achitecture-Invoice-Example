using Invoice.Data.Models;
using Invoice.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Transactions;

namespace Invoice.Service
{
    public class InvoiceService : IInvoiceService
    {
        private readonly Repository.IRepository<Invoice.Data.Models.Invoice> repository;
        private readonly DynamcisLinkDBContext _context;
        private readonly IInvoiceDetailService invDetailsService;

        public InvoiceService(IRepository<Invoice.Data.Models.Invoice> repository, DynamcisLinkDBContext _context, IInvoiceDetailService invDetailsService)
        {
            this.repository = repository;
            this._context = _context;
            this.invDetailsService = invDetailsService;
        }

        public void DeleteInvoice(long id)
        {
            throw new NotImplementedException();
        }

        public Data.Models.Invoice GetInvoice(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Data.Models.Invoice> GetInvoices()
        {
            return repository.GetAll();
        }

        public void InsertInvoice(Data.Models.Invoice invoice)
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
        public void UpdateInvoice(Data.Models.Invoice invoice)
        {
            throw new NotImplementedException();
        }
    }
}
