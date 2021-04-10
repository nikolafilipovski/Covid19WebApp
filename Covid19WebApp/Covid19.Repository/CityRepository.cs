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
    public class CityRepository : ICityRepository
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<CityRepository> _logger;

        public CityRepository(DataContext dataContext, ILogger<CityRepository> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        public void Add(City city)
        {
            try
            {
                _dataContext.Cities.Add(city);
                _dataContext.SaveChanges();
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
                _dataContext.Cities.Remove(city);
                _dataContext.SaveChanges();
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
                _dataContext.Cities.Update(city);
                _dataContext.SaveChanges();
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
            var result = _dataContext.Cities.AsEnumerable();
            return result;
        }

        public City GetCityByID(int ID)
        {
            var result = _dataContext.Cities.FirstOrDefault(x => x.cityID == ID);
            return result;
        }
    }
}
