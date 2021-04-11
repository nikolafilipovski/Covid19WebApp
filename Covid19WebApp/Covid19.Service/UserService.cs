using Covid19.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Covid19.Service
{
    public class UserService : IUserService
    {
        public IQueryable<SelectListItem> Dropdown(IQueryable<IdentityRole> roles)
        {
            List<SelectListItem> roleList = new List<SelectListItem>();
            roleList.Add(new SelectListItem { Value = "0", Text = "Select role ..." });

            foreach (var item in roles)
            {
                roleList.Add(new SelectListItem { Value = item.Id, Text = item.Name });
            }
            return roleList.AsQueryable();
        }
    }
}
