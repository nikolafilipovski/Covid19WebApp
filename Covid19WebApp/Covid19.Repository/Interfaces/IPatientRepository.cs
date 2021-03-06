using Covid19.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19.Repository.Interfaces
{
    public interface IPatientRepository
    {
        void Add(Patient patient);
        void Delete(Patient patient);
        void Edit(Patient patient);
        Patient GetPatientByID(int ID);
        IEnumerable<Patient> GetPatients();
    }
}
