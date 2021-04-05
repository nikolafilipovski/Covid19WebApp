using Covid19.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19.Service.Interfaces
{
    public interface ICityService
    {
        void Add(City city);
        void Delete(City city);
        void Edit(City city);
        City GetCityByID(int ID);
        IEnumerable<City> GetCities();
    }
}
