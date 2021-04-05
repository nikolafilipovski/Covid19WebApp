using Covid19.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19.Service.Interfaces
{
    public interface ICurrentConditionService
    {
        void Add(CurrentCondition currentCondition);
        void Delete(CurrentCondition currentCondition);
        void Edit(CurrentCondition currentCondition);
        CurrentCondition GetCurrentConditionByID(int ID);
        IEnumerable<CurrentCondition> GetCurrentConditions();
    }
}
