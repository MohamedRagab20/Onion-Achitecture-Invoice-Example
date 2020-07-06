using Invoice.Repository.Migrations;
using System.Collections.Generic;
namespace Invoice.Service
{
    public interface IItemService
    {
        IEnumerable<Items> GetItems();
    }
}
