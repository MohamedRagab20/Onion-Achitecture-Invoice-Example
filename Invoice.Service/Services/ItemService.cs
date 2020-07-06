using Invoice.Data.Entities;
using Invoice.Repository;
using Invoice.Repository.Migrations;
using System.Collections.Generic;

namespace Invoice.Service
{
    public class ItemService : IItemService
    {
        private readonly Repository.IRepository<Items> repository;

        public ItemService(IRepository<Items> repository)
        {
            this.repository = repository;
        }
        public IEnumerable<Items> GetItems()
        {
            return repository.GetAll();
        }
    }
}
