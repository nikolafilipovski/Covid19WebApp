using Covid19.Entities;
using Covid19.Repository.Interfaces;
using Covid19.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19.Service
{
    public class CurrentConditionService : ICurrentConditionService
    {
        private readonly ICurrentConditionRepository _currentConditionRepository;

        public CurrentConditionService(ICurrentConditionRepository currentConditionRepository)
        {
            _currentConditionRepository = currentConditionRepository;
        }

        public void Add(CurrentCondition currentCondition)
        {
            _currentConditionRepository.Add(currentCondition);
            // logger
        }

        public void Delete(CurrentCondition currentCondition)
        {
            _currentConditionRepository.Delete(currentCondition);
            // logger
        }

        public void Edit(CurrentCondition currentCondition)
        {
            _currentConditionRepository.Edit(currentCondition);
            // logger
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
