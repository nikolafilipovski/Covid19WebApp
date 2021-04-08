using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Covid19.Entities
{
    public class City
    {
        [Key]
        [Display(Name = "City")]
        public int cityID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "City Name")]
        public string cityName { get; set; }

        [Required]
        [Range(1, 1000000, ErrorMessage = "Please enter a valid number!")]
        [Display(Name = "City population")]
        public int population { get; set; }

        public ICollection<Hospital> hospitals { get; set; }

    }
}
