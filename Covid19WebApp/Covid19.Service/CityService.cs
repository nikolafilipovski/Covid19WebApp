using Covid19.Entities;
using Covid19.Repository.Interfaces;
using Covid19.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19.Service
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public void Add(City city)
        {
            _cityRepository.Add(city);
            // logger
        }

        public void Delete(City city)
        {
            _cityRepository.Delete(city);
            // logger
        }

        public void Edit(City city)
        {
            _cityRepository.Edit(city);
            // logger
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
