namespace DMSC.Assessment.Web.Controllers
{
    using DMSC.Assessment.Data.Interface;
    using DMSC.Assessment.Web.Mapper;

    using Microsoft.AspNetCore.Mvc;

    using System.Threading.Tasks;

    public class NewsController : Controller
    {
        private readonly IArticleRepository _articleRepository;

        public NewsController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<IActionResult> Index()
        {
            var articles = await _articleRepository.FindByAsync(x => x.Active == true);

            return View(Map.From(articles));
        }

        public async Task<IActionResult> Detail(int id)
        {
            var model = await _articleRepository.GetAsync(id);         
            return View(Map.From(model));           
        }
    }
}
