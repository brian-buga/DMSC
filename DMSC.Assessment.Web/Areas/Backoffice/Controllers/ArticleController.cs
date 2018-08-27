namespace DMSC.Assessment.Backoffice.Controllers
{
    using DMSC.Assessment.Backoffice.Models;
    using DMSC.Assessment.Data.Interface;
    using DMSC.Assessment.Web.Mapper;

    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
  
    [Area("Backoffice")]
    public class ArticleController : BaseController
    {      
        private readonly IArticleRepository _articleRepository;
        public ArticleController(IArticleRepository articleRepository, IUserRepository userRepository):base(userRepository)
        {
            _articleRepository = articleRepository;
        }
        public async Task<IActionResult> Index()
        {
            var articles = await _articleRepository.GetAllAsync();        

            return View(Map.From(articles));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new ArticleModel() { IsSuccess = false });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ArticleModel articleModel)
        {
            if(!ModelState.IsValid)
            {
                return View(articleModel);
            }

            var model = Map.From(articleModel, CurrentUser);

            _articleRepository.Create(model);
            _articleRepository.SaveChanges();

            ModelState.Clear();

            return View(new ArticleModel() { IsSuccess = true });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {           
            var model = await _articleRepository.GetAsync(Id);
                       
            return View(Map.From(model));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ArticleModel articleModel)
        {
            if (!ModelState.IsValid)
            {
                return View(articleModel);
            }

            var model = Map.From(articleModel, CurrentUser);

            _articleRepository.Edit(model);
            _articleRepository.SaveChanges();

            articleModel.IsSuccess = true;

            return View(articleModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            var model = await _articleRepository.GetAsync(Id);

            _articleRepository.Delete(model);
            _articleRepository.SaveChanges();

            return Ok();
        }
    }
}