using Covid19.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19.Service.Interfaces
{
    public interface IHospitalService
    {
        void Add(Hospital hospital);
        void Delete(Hospital hospital);
        void Edit(Hospital hospital);
        Hospital GetHospitalByID(int ID);
        IEnumerable<Hospital> GetHospitals();
        IEnumerable<SelectListItem> cityList(IEnumerable<City> cities);

    }
}
