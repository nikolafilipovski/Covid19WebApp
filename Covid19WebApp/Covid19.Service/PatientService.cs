using Covid19.Entities;
using Covid19.Repository.Interfaces;
using Covid19.Service.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19.Service
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly ILogger<PatientService> _logger;

        public PatientService(IPatientRepository patientRepository, ILogger<PatientService> logger)
        {
            _patientRepository = patientRepository;
            _logger = logger;
        }

        public void Add(Patient patient)
        {
            try
            {
                _patientRepository.Add(patient);
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
                _patientRepository.Delete(patient);
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
                _patientRepository.Edit(patient);
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
            var result = _patientRepository.GetPatientByID(ID);
            return result;
        }

        public IEnumerable<Patient> GetPatients()
        {
            var result = _patientRepository.GetPatients();
            return result;
        }

        public IEnumerable<SelectListItem> hospitalList(IEnumerable<Hospital> hospitals)
        {
            List<SelectListItem> allHospitals = new List<SelectListItem>();
            allHospitals.Add(new SelectListItem { Value = "0", Text = "Select Hospital" });
            foreach (var item in hospitals)
            {
                allHospitals.Add(new SelectListItem { Value = item.hospitalID.ToString(), Text = item.hospitalName });
            }
            return allHospitals;
        }

    }
}
