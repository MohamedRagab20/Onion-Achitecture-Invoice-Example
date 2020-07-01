using Invoice.Data.Models;
using Invoice.Repository;
using System;
using System.Collections.Generic;
using System.Text;

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
