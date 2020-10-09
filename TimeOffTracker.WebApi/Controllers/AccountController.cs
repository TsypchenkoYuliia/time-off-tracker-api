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

namespace TimeOffTracker.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private ILogger<AccountController> _logger;

        public AccountController(UserManager<User> userManager, ILogger<AccountController> logger)
        {
            _userManager = userManager;
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
                        await _userManager.AddToRoleAsync(user, model.Role);
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
