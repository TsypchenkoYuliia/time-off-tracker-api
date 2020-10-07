using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain.EF_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TimeOffTracker.WebApi.ViewModels;
using TimeOffTracker.WebApi.ViewModels.Enum;

namespace TimeOffTracker.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private ILogger<AccountController> _logger;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [HttpPost]
        public async Task<HttpStatusCode> Post([FromForm] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { Email = model.Email, UserName = model.Email };

                try
                {
                    var result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, (Enum.GetValues(typeof(Roles)).GetValue(model.Role-1)).ToString());
                        await _signInManager.SignInAsync(user, false);
                    }
                    else
                    {
                        _logger.LogError("InternalServerError");
                        return HttpStatusCode.InternalServerError;
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }

            }
            return HttpStatusCode.OK;
        }
    }
}
