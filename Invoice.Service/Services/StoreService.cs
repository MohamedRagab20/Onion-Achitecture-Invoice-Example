using Invoice.Data.Entities;
using Invoice.Repository;
using Invoice.Repository.Migrations;
using System.Collections.Generic;

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
