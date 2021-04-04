using Covid19.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19.Repository.Interfaces
{
    public interface IHospitalRepository
    {
        void Add(Hospital hospital);
        void Delete(Hospital hospital);
        void Edit(Hospital hospital);
        Hospital GetHospitalByID(int ID);
        IEnumerable<Hospital> GetHospitals();
    }
}
