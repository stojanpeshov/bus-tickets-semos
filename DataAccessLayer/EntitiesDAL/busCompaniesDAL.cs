using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccessLayer.Entities;
using DataAccessLayer.DataContext;

// methods for the BusCompanies Entity
namespace DataAccessLayer.EntitiesDAL
{
    public class busCompaniesDAL
    {
        DatabaseContext db = new DatabaseContext();

        // listing all the bus companies
        public List<BusCompanies> GetAllBusCompanies()
        {
            return db.BusCompanies.ToList();
        }
        // finding a bus company by id
        public BusCompanies GetBusCompaniesById (int id)
        {
            return db.BusCompanies.Find(id);
        }
        // adding a new bus company
        public void Insert (BusCompanies busCompany)
        {
            db.BusCompanies.Add(busCompany);
        }
        // updating an already existing bus company
        public void Update (BusCompanies busCompany)
        {
            db.BusCompanies.Update(busCompany);
        }
        // deleting a bus company
        public void Delete (BusCompanies busCompany)
        {
            db.BusCompanies.Remove(busCompany);
        }
    }
}
