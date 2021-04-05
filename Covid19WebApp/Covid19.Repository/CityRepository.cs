using Covid19.Data;
using Covid19.Entities;
using Covid19.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Covid19.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly DataContext _dataContext;

        public CityRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(City city)
        {
            _dataContext.Cities.Add(city);
            _dataContext.SaveChanges();
            // logger
        }

        public void Delete(City city)
        {
            _dataContext.Cities.Remove(city);
            _dataContext.SaveChanges();
            // logger
        }

        public void Edit(City city)
        {
            _dataContext.Cities.Update(city);
            _dataContext.SaveChanges();
            // logger
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
