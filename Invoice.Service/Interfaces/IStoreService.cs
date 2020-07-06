using Invoice.Data.Entities;
using Invoice.Repository.Migrations;
using System.Collections.Generic;

namespace Invoice.Service
{
    public interface IStoreService
    {
        IEnumerable<Stores> GetStores();
    }
}
