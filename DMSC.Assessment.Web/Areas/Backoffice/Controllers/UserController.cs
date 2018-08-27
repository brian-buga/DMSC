namespace DMSC.Assessment.Backoffice.Controllers
{
    using Microsoft.AspNetCore.Mvc;
   
    [Area("Backoffice")]
    public class UserController : Controller
    {   
        public IActionResult Index()
        {            
            return View();
        }
    }
}