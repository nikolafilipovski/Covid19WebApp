using Covid19.Entities;
using Covid19.Repository.Interfaces;
using Covid19.Service.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19.Service
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public void Add(Patient patient)
        {
            _patientRepository.Add(patient);
            // loger
        }

        public void Delete(Patient patient)
        {
            _patientRepository.Delete(patient);
            // loger
        }

        public void Edit(Patient patient)
        {
            _patientRepository.Edit(patient);
            // loger
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
