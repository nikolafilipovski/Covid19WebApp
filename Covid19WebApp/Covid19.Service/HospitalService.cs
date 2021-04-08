using Covid19.Entities;
using Covid19.Repository.Interfaces;
using Covid19.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

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

        public IEnumerable<SelectListItem> cityList(IEnumerable<City> cities)
        {
            List<SelectListItem> allCities = new List<SelectListItem>();
            allCities.Add(new SelectListItem { Value = "0", Text = "Select City" });
            foreach (var item in cities)
            {
                allCities.Add(new SelectListItem { Value = item.cityID.ToString(), Text = item.cityName });
            }
            return allCities.AsEnumerable();
        } 


    }
}
