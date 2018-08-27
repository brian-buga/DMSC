namespace DMSC.Assessment.Web.Controllers
{
    using DMSC.Assessment.Data.Interface;
    using DMSC.Assessment.Web.Models;

    using Microsoft.AspNetCore.Mvc;

    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }

            var model = _userRepository.FindByAsync(x => x.Email == loginModel.UserName);

            if(model == null)
            {
                ModelState.AddModelError("UserName", "Username not found");
                return View(loginModel);
            }
           
            if (model.Password != loginModel.Password)
            {
                ModelState.AddModelError("Password", "Password not found");
                return View(loginModel);
            }

            return RedirectToActionPermanent("index", "dashboard", new { area = "BackOffice", userName = loginModel.UserName });
        }

    }
}