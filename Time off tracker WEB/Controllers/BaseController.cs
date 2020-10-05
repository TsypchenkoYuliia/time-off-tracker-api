using Microsoft.AspNetCore.Mvc;
using TimeOffTracker.WebApi.Filters;

namespace Time_off_tracker_WEB.Controllers
{
    [ExceptionFilter]
    public class BaseController : ControllerBase
    {

    }
}