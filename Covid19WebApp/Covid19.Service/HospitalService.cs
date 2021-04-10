using Covid19.Entities;
using Covid19.Repository.Interfaces;
using Covid19.Service.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Covid19.Service
{
    public class HospitalService : IHospitalService
    {
        private readonly IHospitalRepository _hospitalRepository;
        private readonly ILogger<HospitalService> _logger;

        public HospitalService(IHospitalRepository hospitalRepository, ILogger<HospitalService> logger)
        {
            _hospitalRepository = hospitalRepository;
            _logger = logger;
        }

        public void Add(Hospital hospital)
        {
            try
            {
                _hospitalRepository.Add(hospital);
                _logger.LogInformation("New hospital was added!");
            }
            catch (Exception exception)
            {
                _logger.LogError("An error occurred while adding the hospital" + " | " + exception);
                throw;
            }
        }

        public void Delete(Hospital hospital)
        {
            try
            {
                _hospitalRepository.Delete(hospital);
                _logger.LogInformation("The hospital was deleted!");
            }
            catch (Exception exception)
            {
                _logger.LogError("An error occurred while deleting the hospital" + " | " + exception);
                throw;
            }
        }

        public void Edit(Hospital hospital)
        {
            try
            {
                _hospitalRepository.Edit(hospital);
                _logger.LogInformation("The hospital was updated!");
            }
            catch (Exception exception)
            {
                _logger.LogError("An error occurred while updating the hospital" + " | " + exception);
                throw;
            }
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
            return allCities;
        } 

    }
}
