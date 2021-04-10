using Covid19.Entities;
using Covid19.Repository.Interfaces;
using Covid19.Service.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19.Service
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly ILogger<CityService> _logger;

        public CityService(ICityRepository cityRepository, ILogger<CityService> logger)
        {
            _cityRepository = cityRepository;
            _logger = logger;
        }

        public void Add(City city)
        {
            try
            {
                _cityRepository.Add(city);
                _logger.LogInformation("New City was created!");
            }
            catch (Exception exception)
            {
                _logger.LogError("An error occurred while creating the City" + " | " + exception);
                throw;
            }
        }

        public void Delete(City city)
        {
            try
            {
                _cityRepository.Delete(city);
                _logger.LogInformation("The City was deleted!");
            }
            catch (Exception exception)
            {
                _logger.LogError("An error occurred while deleting the City" + " | " + exception);
                throw;
            }
        }

        public void Edit(City city)
        {
            try
            {
                _cityRepository.Edit(city);
                _logger.LogInformation("The City was updated!");
            }
            catch (Exception exception)
            {
                _logger.LogError("An error occurred while updating the City" + " | " + exception);
                throw;
            }
        }

        public IEnumerable<City> GetCities()
        {
            var result = _cityRepository.GetCities();
            return result;
        }

        public City GetCityByID(int ID)
        {
            var result = _cityRepository.GetCityByID(ID);
            return result;
        }
    }
}
