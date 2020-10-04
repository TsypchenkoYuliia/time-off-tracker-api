using Microsoft.AspNetCore.Mvc;
using Time_off_tracker_WEB.Models;

namespace Time_off_tracker_WEB.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public TestViewModel Get()
        {
            TestViewModel model = new TestViewModel();
            model.Smth = "Test";

            return model;
        }

        [HttpPost]
        public void Post()
        {

        }
    }
}