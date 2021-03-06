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

        public Hospital hospital { get; set; }
        public int hospitalID { get; set; }
        public string hospitalName { get; set; }


    }
}
