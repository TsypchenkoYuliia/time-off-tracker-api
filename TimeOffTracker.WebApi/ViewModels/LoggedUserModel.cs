using Domain.EF_Models;

namespace TimeOffTracker.WebApi.ViewModels
{
    public class LoggedUserModel
    {
        public User User { get; set; }
        public string Token { get; set; }
    }
}
