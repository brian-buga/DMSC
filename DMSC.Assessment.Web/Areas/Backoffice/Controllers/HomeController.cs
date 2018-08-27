namespace DMSC.Assessment.Backoffice.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    [Area("Backoffice")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}