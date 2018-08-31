namespace DMSC.Assessment.Backend.Controllers
{ 
    using Microsoft.AspNetCore.Mvc;

    using System;

    [Area("backend")]
    public class SettingController : Controller
    {   
        public IActionResult Index()
        {            
            return View();
        }
    }
}