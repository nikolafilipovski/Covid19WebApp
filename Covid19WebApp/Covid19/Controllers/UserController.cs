using Covid19.Models;
using Covid19.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IPasswordHasher<IdentityUser> _passwordHasher;
        private readonly IUserService _userService;
        private readonly ILogger<PatientController> _logger;

        public UserController(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IPasswordHasher<IdentityUser> passwordHasher,
            IUserService userService,
            ILogger<PatientController> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _passwordHasher = passwordHasher;
            _userService = userService;
            _logger = logger;
        }

        // GET: UserController
        public ActionResult Index()
        {
            var allUsers = _userManager.Users;
            _logger.LogInformation("All users were listed!");
            return View(allUsers);
        }

        // GET: UserController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return View(user);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            var roles = _roleManager.Roles;
            UserModel userModel = new UserModel();
            userModel.Roles = _userService.Dropdown(roles, null);

            return View(userModel);
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserModel user)
        {
            if (ModelState.IsValid)
            {
                IdentityUser appUser = new IdentityUser
                {
                    UserName = user.userName,
                    Email = user.userEmail,
                    EmailConfirmed = true
                };

                IdentityResult result = await _userManager.CreateAsync(appUser, user.userPassword);
                _logger.LogInformation("New user was created!");

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(appUser, user.userRoleName);
                    _logger.LogInformation("A role was assigned for the user!");
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                        _logger.LogInformation("An error occurred while assigning a role!");
                    }
                }
            }
            return View(user);
        }

        // GET: UserController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            IdentityUser user = await _userManager.FindByIdAsync(id);
            var roles = _roleManager.Roles; 

            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var userModel = new UserModel
                {
                    userID = user.Id,
                    userEmail = user.Email,
                    Roles = _userService.Dropdown(roles, userRoles[0])
                };

                var selectedRoleId = roles.Where(x => x.Name == userRoles[0]).SingleOrDefault().Id;
                userModel.userRoleID = selectedRoleId;
                return View(userModel);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, string email, string password, string RoleName)
        {
            IdentityUser user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var getUserOldRole = _roleManager.FindByNameAsync(userRoles[0]);

                if (!string.IsNullOrEmpty(email))
                {
                    user.Email = email;
                }
                else
                {
                    ModelState.AddModelError("", "Email cannot be empty");
                }

                if (!string.IsNullOrEmpty(password))
                {
                    user.PasswordHash = _passwordHasher.HashPassword(user, password);
                }
                else
                {
                    ModelState.AddModelError("", "Password cannot be empty");
                }

                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                {
                    IdentityResult result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        await _userManager.RemoveFromRoleAsync(user, getUserOldRole.Result.Name);
                        _logger.LogInformation("User was edited!");
                        await _userManager.AddToRoleAsync(user, RoleName); 
                        _logger.LogInformation("New role was assigned!");
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        Errors(result);
                        _logger.LogError("User was not edited, ModelState is not valid!");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
                _logger.LogWarning("There is no user found in database!");
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: UserController/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            IdentityUser user = await _userManager.FindByIdAsync(id);

            return View(user);
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id, IdentityUser identityUser)
        {
            IdentityUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User was deleted!");
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    Errors(result);
                    _logger.LogInformation("An error occurred while deleting a user!");
                }
            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
                _logger.LogWarning("There is no user found in database!");
            }

            return View(nameof(Index), _userManager.Users);
        }

        #region Helper methods

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        #endregion

    }
}
