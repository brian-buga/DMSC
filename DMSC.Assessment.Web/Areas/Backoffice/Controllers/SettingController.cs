namespace DMSC.Assessment.Backoffice.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using System;

    [Area("Backoffice")]
    public class ReportController : Controller
    {   
        public IActionResult Index()
        {            
            return View();
        }
    }
}