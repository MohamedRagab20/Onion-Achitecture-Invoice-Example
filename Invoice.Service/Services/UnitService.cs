using Invoice.Data.Entities;
using Invoice.Repository;
using Invoice.Repository.Migrations;
using System.Collections.Generic;

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
