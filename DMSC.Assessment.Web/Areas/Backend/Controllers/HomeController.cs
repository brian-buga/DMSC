namespace DMSC.Assessment.Backend.Controllers
{
    using DMSC.Assessment.Data.Interface;
    using Microsoft.AspNetCore.Mvc;

    using System;

    [Area("backend")]
    public class HomeController : Controller
    {
        private readonly IChartRepository _chartRepository;
        public HomeController(IChartRepository chartRepository)
        {
            _chartRepository = chartRepository;
        }
     
        public IActionResult Index()
        {
            var model = _chartRepository.Get(DateTime.Now.AddDays(-3));
            return View(model);
        }
    }
}