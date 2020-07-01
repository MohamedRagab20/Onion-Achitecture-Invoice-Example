using Invoice.Data.Models;
using Invoice.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invoice.Service
{
    public class StoreService : IStoreService
    {
        private readonly Repository.IRepository<Stores> repository;

        public StoreService(IRepository<Stores> repository)
        {
            this.repository = repository;
        }
        public IEnumerable<Stores> GetStores()
        {
            return repository.GetAll();
        }
    }
}
