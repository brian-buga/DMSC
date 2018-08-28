namespace DMSC.Assessment.Backoffice.Controllers
{
    using DMSC.Assessment.Data.Interface;
    using DMSC.Assessment.Data.Model;

    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;


    public class BaseController : Controller
    {
        private readonly IUserRepository _userRepository;      
        private User _appUser;
        public User CurrentUser => GetCurrentUser();

        public BaseController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        private User GetCurrentUser()
        {
            if (!User.Identity.IsAuthenticated)
                return null;

            if (_appUser != null)
                return _appUser;

            var id = User?.Claims.FirstOrDefault(x => x.Type == "id")?.Value;
            return _userRepository.FindByAsync(x=>x.Id == (id!=null ? int.Parse(id) : 0));
        }
    }
}