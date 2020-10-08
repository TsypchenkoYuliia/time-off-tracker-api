using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.EF_Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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
        public IEnumerable<IdentityRole> GetAllRoles()
        {
            IEnumerable<IdentityRole> allRoles = _roleManager.Roles.AsNoTracking()
                   .Where(role => role.NormalizedName != "ADMIN")
                   .ToList();

            return allRoles;
        }

        [HttpPost]
        public async Task<ActionResult<User>> SetUserRole(string userId, string role) 
        {
            User user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                try
                {
                    var userRole = await _userManager.GetRolesAsync(user);

                    await _userManager.AddToRoleAsync(user, role);

                    await _userManager.RemoveFromRolesAsync(user, userRole);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Cannot change user role: {UserId}", userId);
                    return Conflict();
                }
            }
            else
            {
                _logger.LogError("User not found! UserId: {Id}", userId);
                return NotFound();
            }

            return Ok(user);
        }
    }
}
