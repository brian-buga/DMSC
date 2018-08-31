namespace DMSC.Assessment.Web.Controllers
{
    using DMSC.Assessment.Data.Interface;
    using DMSC.Assessment.Data.Model;
    using Microsoft.AspNetCore.Mvc;

    using System;
    using System.Threading.Tasks;

    public class LikeController : BaseController
    {
        private readonly ILikeRepository _likeRepository;
      
        public LikeController(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(int articleId)
        {
            var valid = await ValidateVote(articleId);

            if(valid == 0)
            {
                var model = new Like()
                {
                    UserId = UserId,
                    ArticleId = articleId,

                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = UserName
                };

                _likeRepository.Create(model);
                _likeRepository.SaveChanges();
            }           
                      
            return Ok(await PrepareLike(articleId));
        }

        #region private function

        private async Task<int> PrepareLike(int articleId)
        {
            var model = await _likeRepository.FindByAsync(x => x.ArticleId == articleId);
            return model.Count;
        }

        private async Task<int> ValidateVote(int articleId)
        {
            var model = await _likeRepository.FindByAsync(x => x.ArticleId == articleId && x.UserId == UserId);
            return model.Count;
        }

        #endregion
    }
}