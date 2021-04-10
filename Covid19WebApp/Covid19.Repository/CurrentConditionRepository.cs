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
    public class CurrentConditionRepository : ICurrentConditionRepository
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<CurrentConditionRepository> _logger;

        public CurrentConditionRepository(DataContext dataContext, ILogger<CurrentConditionRepository> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        public void Add(CurrentCondition currentCondition)
        {
            try
            {
                _dataContext.CurrentConditions.Add(currentCondition);
                _dataContext.SaveChanges();
                _logger.LogInformation("New condition was added!");
            }
            catch (Exception exception)
            {
                _logger.LogError("An error occurred while adding the condition" + " | " + exception);
                throw;
            }
        }

        public void Delete(CurrentCondition currentCondition)
        {
            try
            {
                _dataContext.CurrentConditions.Remove(currentCondition);
                _dataContext.SaveChanges();
                _logger.LogInformation("The condition was deleted!");
            }
            catch (Exception exception)
            {
                _logger.LogError("An error occurred while deleting the condition" + " | " + exception);
                throw;
            }
        }

        public void Edit(CurrentCondition currentCondition)
        {
            try
            {
                _dataContext.CurrentConditions.Update(currentCondition);
                _dataContext.SaveChanges();
                _logger.LogInformation("The conditions were updated!");
            }
            catch (Exception exception)
            {
                _logger.LogError("An error occurred while updating the condition" + " | " + exception);
                throw;
            }
        }

        public CurrentCondition GetCurrentConditionByID(int ID)
        {
            var result = _dataContext.CurrentConditions.FirstOrDefault(x => x.currentConditionID == ID);
            return result;
        }

        public IEnumerable<CurrentCondition> GetCurrentConditions()
        {
            var result = _dataContext.CurrentConditions.AsEnumerable();
            return result;
        }
    }
}
