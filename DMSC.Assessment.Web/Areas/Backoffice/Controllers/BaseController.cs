namespace DMSC.Assessment.Backoffice.Controllers
{
    using DMSC.Assessment.Data.Interface;
    using DMSC.Assessment.Data.Model;

    using Microsoft.AspNetCore.Mvc;

    public class BaseController : Controller
    {
        private readonly IUserRepository _userRepository;
        private const int userId = 3;
        public User CurrentUser => GetCurrentUser();

        public BaseController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        private User GetCurrentUser()
        {                     
            return _userRepository.FindByAsync(x=>x.Id == userId);
        }
    }
}