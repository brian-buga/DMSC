namespace DMSC.Assessment.Backend.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Area("backend")]
    public class UserController : Controller
    {   
        public IActionResult Index()
        {            
            return View();
        }
    }
}