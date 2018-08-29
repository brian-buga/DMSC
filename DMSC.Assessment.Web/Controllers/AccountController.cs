namespace DMSC.Assessment.Web.Controllers
{
    using DMSC.Assessment.Data.Interface;
    using DMSC.Assessment.Data.Model;
    using DMSC.Assessment.Web.Infrastructure;
    using DMSC.Assessment.Web.Models;
    using DMSC.Assessment.Web.Services;

    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserManager _userManager;

        public AccountController(IUserRepository userRepository, IUserManager userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
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

            var user = _userRepository.FindBy(x => x.Email == loginModel.UserName);

            if(user == null)
            {
                ModelState.AddModelError("UserName", "Username not found");
                return View(loginModel);
            }
           
            if (user.Password != loginModel.Password)
            {
                ModelState.AddModelError("Password", "Password not found");
                return View(loginModel);
            }

            AuthenticationUser(user);

            switch (user.Role)
            {
                case Roles.ADMIN:
                case Roles.PUBLISHER:
                    return RedirectToAction("index", "home", new { area = "backoffice" });
                 
                case Roles.USER:
                    return RedirectToAction("index", "home", new { area = "" });                   
            }

            return View(loginModel);
        }
       
        public async Task<IActionResult> LogOut()
        {
            await AuthenticationHttpContextExtensions.SignOutAsync(HttpContext);

            return RedirectToAction("index", "home", new { area = "" } );
        }

        #region private function

        private async void AuthenticationUser(User user)
        {
            await AuthenticationHttpContextExtensions.SignInAsync(HttpContext, CookieAuthenticationDefaults.AuthenticationScheme, _userManager.Principal(user));
        }

        #endregion
    }
}