namespace DMSC.Assessment.Backend.Controllers
{
    using DMSC.Assessment.Backend.Models;
    using DMSC.Assessment.Data.Interface;
    using DMSC.Assessment.Data.Model;
    using DMSC.Assessment.Web.Controllers;
    using DMSC.Assessment.Web.Mapper;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Authorize]
    [Area("backend")]
    public class ArticleController : BaseController
    {      
        private readonly IArticleRepository _articleRepository;
        public ArticleController(IArticleRepository articleRepository)
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
                     
            _articleRepository.Create(PrepareArticleModel(articleModel));
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
           
            _articleRepository.Edit(PrepareArticleModel(articleModel));
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

        #region private function

        private Article PrepareArticleModel(ArticleModel articleModel)
        {
            var model = Map.From(articleModel, UserId, UserName);

            return model;
        }
        #endregion
    }
}