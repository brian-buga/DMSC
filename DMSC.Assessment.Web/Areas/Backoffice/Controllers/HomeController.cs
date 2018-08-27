namespace DMSC.Assessment.Backoffice.Controllers
{
    using DMSC.Assessment.Data.Interface;
    using Microsoft.AspNetCore.Mvc;

    using System;

    [Area("Backoffice")]
    public class HomeController : Controller
    {
        private readonly IChartRepository _chartRepository;
        public HomeController(IChartRepository chartRepository)
        {
            _chartRepository = chartRepository;
        }
        public IActionResult Index()
        {
            var model = _chartRepository.Get(DateTime.Now);
            return View(model);
        }
    }
}