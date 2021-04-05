using Covid19.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19.Repository.Interfaces
{
    public interface ICityRepository
    {
        void Add(City city);
        void Delete(City city);
        void Edit(City city);
        City GetCityByID(int ID);
        IEnumerable<City> GetCities();
    }
}
