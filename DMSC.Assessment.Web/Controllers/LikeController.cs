namespace DMSC.Assessment.Web.Controllers
{
    using DMSC.Assessment.Data.Interface;
    using DMSC.Assessment.Data.Model;

    using Microsoft.AspNetCore.Mvc;
    using System;

    public class LikeController : Controller
    {
        private readonly ILikeRepository _likeRepository;

        public LikeController(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        [HttpPost]
        public IActionResult Create(int articleId)
        {           
            var model = new Like()
            {
                ArticleId = articleId,
                CreatedAt = DateTime.UtcNow
            };

           _likeRepository.Create(model);
           _likeRepository.SaveChanges();

            return Ok();
        }
    }
}