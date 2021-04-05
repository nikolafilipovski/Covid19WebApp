using Covid19.Data;
using Covid19.Entities;
using Covid19.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Covid19.Repository
{
    public class CurrentConditionRepository : ICurrentConditionRepository
    {
        private readonly DataContext _dataContext;

        public CurrentConditionRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(CurrentCondition currentCondition)
        {
            _dataContext.CurrentConditions.Add(currentCondition);
            _dataContext.SaveChanges();
            // logger
        }

        public void Delete(CurrentCondition currentCondition)
        {
            _dataContext.CurrentConditions.Remove(currentCondition);
            _dataContext.SaveChanges();
            // logger
        }

        public void Edit(CurrentCondition currentCondition)
        {
            _dataContext.CurrentConditions.Update(currentCondition);
            _dataContext.SaveChanges();
            // logger
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
