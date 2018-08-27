namespace DMSC.Assessment.Web.Controllers
{
    using DMSC.Assessment.Data.Interface;
    using DMSC.Assessment.Web.Mapper;

    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class HomeController : Controller
    {
        private readonly IArticleRepository _articleRepository;

        public HomeController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
        public async Task<IActionResult> Index()
        {
            var articles = await _articleRepository.FindByAsync(x=>x.Active == true);

            return View(Map.From(articles));          
        }      
    }
}
