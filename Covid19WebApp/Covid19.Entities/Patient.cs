using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Covid19.Entities
{
    public class Patient
    {
        [Key]
        public int patientID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Patient Name")]
        public string patientName { get; set; }

        [Required]
        [Display(Name = "Day of birth")]
        public DateTime dateOfBirth { get; set; }

        [Display(Name = "Cured")]
        public string cured { get; set; }

        [Display(Name = "Receiving treatment")]
        public string ill { get; set; }

        [Display(Name = "Deceased")]
        public string deceased { get; set; }

        public Hospital hospital { get; set; }
        public int hospitalID { get; set; }

    }
}
