namespace DMSC.Assessment.Backend.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using System;

    [Area("backend")]
    public class ReportController : Controller
    {   
        public IActionResult Index()
        {            
            return View();
        }
    }
}