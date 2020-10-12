using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Static.Context;
using Domain.EF_Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using TimeOffTracker.WebApi.Exceptions;
using TimeOffTracker.WebApi.ViewModels;

namespace TimeOffTracker.WebApi.Controllers
{
    [Route("auth/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AccountController : BaseController
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
                    {
                        await _userManager.AddToRoleAsync(user, model.Role);
                        return HttpStatusCode.OK;
                    }

                    StringBuilder sb = new StringBuilder();
                    foreach (IdentityError err in result.Errors)
                    {
                        sb.Append(err.Description).Append(";");
                    }
                    throw new Exception(sb.ToString());

                }
                catch (Exception ex)
                {
                    throw new UserCreateException(ex.Message);
                }
            }
            else
                throw new UserCreateException("Invalid user data");
        }
    }
}
