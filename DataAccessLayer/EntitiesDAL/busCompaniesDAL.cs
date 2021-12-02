using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccessLayer.Entities;
using DataAccessLayer.DataContext;

// methods for the BusCompanies Entity
namespace DataAccessLayer.EntitiesDAL
{
    public class BusCompaniesDAL : IBusCompaniesDAL
    {
        private readonly DatabaseContext _context;
        public BusCompaniesDAL(DatabaseContext context)
        {
            _context = context;
        }

        // listing all the bus companies
        public List<BusCompanies> GetAllBusCompanies()
        {
            return _context.BusCompanies.ToList();
        }
        // finding a bus company by id
        public BusCompanies GetBusCompaniesById(int id)
        {
            return _context.BusCompanies.Find(id);
        }
        // adding a new bus company
        public void Insert(BusCompanies busCompany)
        {
            _context.BusCompanies.Add(busCompany);
        }
        // updating an already existing bus company
        public void Update(BusCompanies busCompany)
        {
            _context.BusCompanies.Update(busCompany);
        }
        // deleting a bus company
        public void Delete(BusCompanies busCompany)
        {
            _context.BusCompanies.Remove(busCompany);
        }
    }
}
