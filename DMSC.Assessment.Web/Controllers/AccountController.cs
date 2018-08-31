namespace DMSC.Assessment.Web.Controllers
{
    using DMSC.Assessment.Data.Interface;
    using DMSC.Assessment.Data.Model;
    using DMSC.Assessment.Web.Infrastructure;
    using DMSC.Assessment.Web.Model;
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
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginModel() { returnUrl = returnUrl } );
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

            Authentication(user);          

            switch (user.Role)
            {
                case Roles.ADMIN:
                case Roles.PUBLISHER:
                    return RedirectToAction("index", "home", new { area = "backend" });
                 
                case Roles.USER:

                    if (!string.IsNullOrEmpty(loginModel.returnUrl))
                    {
                        return LocalRedirect(loginModel.returnUrl);
                    }

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

        private async void Authentication(User user)
        {
            await AuthenticationHttpContextExtensions.SignInAsync(HttpContext, CookieAuthenticationDefaults.AuthenticationScheme, _userManager.Principal(user));
        }

        #endregion
    }
}