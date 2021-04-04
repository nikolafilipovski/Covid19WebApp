using Covid19.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19.Service.Interfaces
{
    public interface IPatientService
    {
        void Add(Patient patient);
        void Delete(Patient patient);
        void Edit(Patient patient);
        Patient GetPatientByID(int ID);
        IEnumerable<Patient> GetPatients();
    }
}
