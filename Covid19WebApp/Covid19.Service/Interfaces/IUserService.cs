using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Covid19.Service.Interfaces
{
    public interface IUserService
    {
        IQueryable<SelectListItem> Dropdown(IQueryable<IdentityRole> roles, string? currentRoleName);
    }
}
