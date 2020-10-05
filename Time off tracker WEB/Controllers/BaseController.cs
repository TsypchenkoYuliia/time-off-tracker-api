using Microsoft.AspNetCore.Mvc;
using TimeOffTracker.WebApi.Filters;

namespace TimeOffTracker.WebApi.Controllers
{
    [ExceptionFilter]
    public class BaseController : ControllerBase
    {

    }
}