using Invoice.Data.Models;
using Invoice.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invoice.Service
{
    public class UnitService : IUnitService
    {
        private readonly IRepository<Units> repository;

        public UnitService(IRepository<Units> repository)
        {
            this.repository = repository;
        }
        public IEnumerable<Units> GetUnits()
        {
            return repository.GetAll();
        }
    }
}
