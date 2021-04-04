using Covid19.Data;
using Covid19.Entities;
using Covid19.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Covid19.Repository
{
    public class HospitalRepository : IHospitalRepository
    {
        private readonly DataContext _dataContext;

        public HospitalRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(Hospital hospital)
        {
            _dataContext.Hospitals.Add(hospital);
            _dataContext.SaveChanges();
            // tuka treba loger
        }

        public void Delete(Hospital hospital)
        {
            _dataContext.Hospitals.Remove(hospital);
            _dataContext.SaveChanges();
            // loger
        }

        public void Edit(Hospital hospital)
        {
            _dataContext.Hospitals.Update(hospital);
            _dataContext.SaveChanges();
            // loger
        }

        public Hospital GetHospitalByID(int ID)
        {
            var result = _dataContext.Hospitals.FirstOrDefault(x => x.hospitalID == ID);
            return result;
        }

        public IEnumerable<Hospital> GetHospitals()
        {
            var result = _dataContext.Hospitals.AsEnumerable();
            return result;
        }
    }
}
