using DataAccessLayer.Entities;
using System.Collections.Generic;

namespace DataAccessLayer.EntitiesDAL
{
    public interface IBusCompaniesDAL
    {
        void Delete(BusCompanies busCompany);
        List<BusCompanies> GetAllBusCompanies();
        BusCompanies GetBusCompaniesById(int id);
        void Insert(BusCompanies busCompany);
        void Update(BusCompanies busCompany);
    }
}