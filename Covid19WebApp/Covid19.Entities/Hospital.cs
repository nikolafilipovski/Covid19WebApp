using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Covid19.Entities
{
    public class Hospital
    {
        [Key]
        [Display(Name = "Hospital")]
        public int hospitalID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Hospital Name")]
        public string hospitalName { get; set; }

        [Display(Name = "Max capacity")]
        [Range(1, 10000, ErrorMessage = "Please enter a valid number!")]
        public int maxCapacity { get; set; }

        [Display(Name = "Current capacity")]
        [Range(1, 10000, ErrorMessage = "Please enter a valid number!")]
        public int currentCapacity { get; set; }

        public City city { get; set; }
        public int cityID { get; set; }
        public ICollection<Patient> patients { get; set; }

    }
}
