namespace DMSC.Assessment.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class MyAccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
