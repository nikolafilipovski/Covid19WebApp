using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Covid19.Entities
{
    public class CurrentCondition
    {
        [Key]
        public int currentConditionID { get; set; }

        [Display(Name = "Confirmed cases")]
        [Range(1, 2000000, ErrorMessage = "Please enter a valid number!")]
        public int confirmedCases { get; set; }

        [Display(Name = "Active cases")]
        [Range(1, 100000, ErrorMessage = "Please enter a valid number!")]
        public int activeCases { get; set; }

        [Display(Name = "Recovered")]
        [Range(1, 2000000, ErrorMessage = "Please enter a valid number!")]
        public int recovered { get; set; }

        [Display(Name = "Confirmed deaths")]
        [Range(1, 100000, ErrorMessage = "Please enter a valid number!")]
        public int confirmedDeaths { get; set; }

        public ICollection<Patient> patients { get; set; }

    }
}
