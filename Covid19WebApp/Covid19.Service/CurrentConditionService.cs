using Covid19.Entities;
using Covid19.Repository.Interfaces;
using Covid19.Service.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19.Service
{
    public class CurrentConditionService : ICurrentConditionService
    {
        private readonly ICurrentConditionRepository _currentConditionRepository;
        private readonly ILogger<CurrentConditionService> _logger;

        public CurrentConditionService(ICurrentConditionRepository currentConditionRepository, ILogger<CurrentConditionService> logger)
        {
            _currentConditionRepository = currentConditionRepository;
            _logger = logger;
        }

        public void Add(CurrentCondition currentCondition)
        {
            try
            {
                _currentConditionRepository.Add(currentCondition);
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
                _currentConditionRepository.Delete(currentCondition);
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
                _currentConditionRepository.Edit(currentCondition);
                _logger.LogInformation("The condition was updated!");
            }
            catch (Exception exception)
            {
                _logger.LogError("An error occurred while updating the condition" + " | " + exception);
                throw;
            }
        }

        public CurrentCondition GetCurrentConditionByID(int ID)
        {
            var result = _currentConditionRepository.GetCurrentConditionByID(ID);
            return result;
        }

        public IEnumerable<CurrentCondition> GetCurrentConditions()
        {
            var result = _currentConditionRepository.GetCurrentConditions();
            return result;
        }
    }
}
