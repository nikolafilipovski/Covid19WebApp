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
    public class HospitalRepository : IHospitalRepository
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<HospitalRepository> _logger;

        public HospitalRepository(DataContext dataContext, ILogger<HospitalRepository> logger)
        {
            _dataContext = dataContext;
            _logger = logger; 
        }

        public void Add(Hospital hospital)
        {
            try
            {
                _dataContext.Hospitals.Add(hospital);
                _dataContext.SaveChanges();
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
                _dataContext.Hospitals.Remove(hospital);
                _dataContext.SaveChanges();
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
                _dataContext.Hospitals.Update(hospital);
                _dataContext.SaveChanges();
                _logger.LogInformation("The hospital was edited!");
            }
            catch (Exception exception)
            {
                _logger.LogError("An error occurred while editing the hospital" + " | " + exception);
                throw;
            }
        }

        public Hospital GetHospitalByID(int ID)
        {
            var result = _dataContext.Hospitals.FirstOrDefault(x => x.hospitalID == ID);
            return result;
        }

        public IEnumerable<Hospital> GetHospitals()
        {
            var result = _dataContext.Hospitals.AsEnumerable();
            return result;
        }
    }
}
