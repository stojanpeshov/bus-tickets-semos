using DataAccessLayer.Entities;
using DataAccessLayer.EntitiesDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public class BusCompaniesBLL
    {
        private readonly BusCompaniesDAL _busCompany;
        public BusCompaniesBLL(BusCompaniesDAL busCompany)
        {
            _busCompany = busCompany;
        }

        public IEnumerable<BusCompanies> GetAllBusCompanies()
        {
            return _busCompany.GetAllBusCompanies();
        }

        public void Insert (BusCompanies busCompany)
        {
            _busCompany.Insert(busCompany);
        }
    }
}
