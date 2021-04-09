using Covid19.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Models
{
    public class HospitalViewModel
    {
        #region Hospital

        public int hospitalID { get; set; }

        public string hospitalName { get; set; }

        public int maxCapacity { get; set; }

        public int currentCapacity { get; set; }

        public City city { get; set; }
        public int cityID { get; set; }
        public string cityName { get; set; }

        #endregion

        #region Patient

        public int patientID { get; set; }

        public string patientName { get; set; }

        public DateTime dateOfBirth { get; set; }

        public Hospital hospital { get; set; }

        #endregion

    }
}
