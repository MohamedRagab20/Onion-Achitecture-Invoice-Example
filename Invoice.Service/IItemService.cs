using System;
using System.Collections.Generic;
using System.Text;
using Invoice.Data.Models;
namespace Invoice.Service
{
    public interface IItemService
    {
        IEnumerable<Items> GetItems();
    }
}
