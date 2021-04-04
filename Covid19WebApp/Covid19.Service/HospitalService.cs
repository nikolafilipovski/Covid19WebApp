using Covid19.Entities;
using Covid19.Repository.Interfaces;
using Covid19.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19.Service
{
    public class HospitalService : IHospitalService
    {
        private readonly IHospitalRepository _hospitalRepository;

        public HospitalService(IHospitalRepository hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
        }

        public void Add(Hospital hospital)
        {
            _hospitalRepository.Add(hospital);
        }

        public void Delete(Hospital hospital)
        {
            _hospitalRepository.Delete(hospital);
        }

        public void Edit(Hospital hospital)
        {
            _hospitalRepository.Edit(hospital);
        }

        public Hospital GetHospitalByID(int ID)
        {
            var result = _hospitalRepository.GetHospitalByID(ID);
            return result;
        }

        public IEnumerable<Hospital> GetHospitals()
        {
            var result = _hospitalRepository.GetHospitals();
            return result;
        }
    }
}
