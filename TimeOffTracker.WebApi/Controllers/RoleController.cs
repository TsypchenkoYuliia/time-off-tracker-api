using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Static.Context;
using Domain.EF_Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TimeOffTracker.WebApi.ViewModels;

namespace TimeOffTracker.WebApi.Controllers
{
    [ApiController]
    [Route("auth/[controller]")]
    public class RoleController : BaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private ILogger<RoleController> _logger;

        public RoleController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, ILogger<RoleController> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> GetAllRoles()
        {
            IEnumerable<string> allRoles = _roleManager.Roles.AsNoTracking()
                   .Select(role => role.Name).Where(roleName => roleName != "ADMIN")
                   .ToList();

            return allRoles;
        }

        [HttpPost]
        public async Task<ActionResult<User>> SetUserRole([FromForm] RoleChangeModel model)
        {
            User user = await _userManager.FindByIdAsync(model.UserId);

            if (user == null)
                throw new RoleChangeException($"Cannot find user with Id: {model.UserId}");
            if (_roleManager.FindByNameAsync(model.Role).Result == null)
                throw new RoleChangeException($"Role does not exist: {model.Role}");
            try
            {
                var userRole = await _userManager.GetRolesAsync(user);

                if (userRole.FirstOrDefault() != model.Role)
                {
                    await _userManager.AddToRoleAsync(user, model.Role);
                    await _userManager.RemoveFromRolesAsync(user, userRole);
                }
            }
            catch (Exception ex)
            {
                throw new RoleChangeException(ex.Message);
            }

            return Ok(user);
        }
    }
}
