using Covid19.Data;
using Covid19.Entities;
using Covid19.Repository.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Covid19.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<PatientRepository> _logger;

        public PatientRepository(DataContext dataContext, ILogger<PatientRepository> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        public void Add(Patient patient)
        {
            try
            {
                _dataContext.Patients.Add(patient);
                _dataContext.SaveChanges();
                _logger.LogInformation("New patient was added!");
            }
            catch (Exception exception)
            {
                _logger.LogError("An error occurred while adding the patient" + " | " + exception);
                throw;
            }
        }

        public void Delete(Patient patient)
        {
            try
            {
                _dataContext.Patients.Remove(patient);
                _dataContext.SaveChanges();
                _logger.LogInformation("The patient was deleted!");
            }
            catch (Exception exception)
            {
                _logger.LogError("An error occurred while deleting the patient" + " | " + exception);
                throw;
            }
        }

        public void Edit(Patient patient)
        {
            try
            {
                _dataContext.Patients.Update(patient);
                _dataContext.SaveChanges();
                _logger.LogInformation("The patient was updated!");
            }
            catch (Exception exception)
            {
                _logger.LogError("An error occurred while updating the patient" + " | " + exception);
                throw;
            }
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
