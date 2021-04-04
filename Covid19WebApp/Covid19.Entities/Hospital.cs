using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Covid19.Entities
{
    public class Hospital
    {
        [Key]
        public int hospitalID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Hospital Name")]
        public string hospitalName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Hospital location")]
        public string hospitalLocation { get; set; }

        [Display(Name = "Max capacity")]
        [Range(1, 10000, ErrorMessage = "Please enter a valid number!")]
        public int maxCapacity { get; set; }

        [Display(Name = "Current capacity")]
        [Range(1, 10000, ErrorMessage = "Please enter a valid number!")]
        public int currentCapacity { get; set; }

        public ICollection<Patient> patients { get; set; }

    }
}
