using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Models
{
    public class UserModel
    {
        [Key]
        [Display(Name = "User ID")]
        public string userID { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string userName { get; set; }

        [Required]
        [Display(Name = "Email")]
        //[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2, 6}$", ErrorMessage = "E-mail is not valid!")]
        public string userEmail { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string userPassword { get; set; }

        [Display(Name = "Role")]
        public string userRoleID { get; set; }

        [Display(Name = "Role name")]
        public string userRoleName { get; set; }
        public IQueryable<SelectListItem> Roles { get; set; }

    }
}
