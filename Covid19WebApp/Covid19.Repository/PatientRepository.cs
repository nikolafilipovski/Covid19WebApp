using Covid19.Data;
using Covid19.Entities;
using Covid19.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Covid19.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly DataContext _dataContext;

        public PatientRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(Patient patient)
        {
            _dataContext.Patients.Add(patient);
            _dataContext.SaveChanges();
        }

        public void Delete(Patient patient)
        {
            _dataContext.Patients.Remove(patient);
            _dataContext.SaveChanges();
        }

        public void Edit(Patient patient)
        {
            _dataContext.Patients.Update(patient);
            _dataContext.SaveChanges();
        }

        public Patient GetPatientByID(int ID)
        {
            var result = _dataContext.Patients.FirstOrDefault(x => x.patientID == ID);
            return result;
        }

        public IEnumerable<Patient> GetPatients()
        {
            var result = _dataContext.Patients.AsEnumerable();
            return result;
        }
    }
}
