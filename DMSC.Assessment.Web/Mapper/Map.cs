namespace DMSC.Assessment.Web.Mapper
{
    using DMSC.Assessment.Backoffice.Models;
    using DMSC.Assessment.Data.Model;

    using System;
    using System.Collections.Generic;

    public static class Map
    {
        public static Article From(ArticleModel articleModel, User user)
        {
            var article = new Article()
            {
                Id = articleModel.Id,            
                Title = articleModel.Title,
                Content = articleModel.Content,
                Published = articleModel.Published,
                Active = articleModel.Active,

                CreatedAt = DateTime.UtcNow,              
                CreatedBy = user.Email,
                UserId = user.Id
            };

            return article;
        }

        public static ArticleModel From(Article article)
        {
            var articleModel = new ArticleModel()
            {
                Id = article.Id,
                Title = article.Title,
                Author = article.Author.FirstName + " " + article.Author.LastName,
                Content = article.Content,
                Published = article.Published,
                Likes = article.Likes.Count,
                Active = article.Active,
                IsSuccess = false
            };

            return articleModel;
        }

        public static List<ArticleModel> From(IEnumerable<Article> articles)
        {
            var _articleModel = new List<ArticleModel>();
            
            foreach (var article in articles)
            {
                var articleModel = new ArticleModel()
                {
                    Id = article.Id,
                    Title = article.Title,
                    Author = article.Author.FirstName + " " + article.Author.LastName,
                    Content = article.Content,
                    Published = article.Published,
                    Likes = article.Likes.Count,
                    Active = article.Active
                };

                _articleModel.Add(articleModel);
            }           

            return _articleModel;
        }
    }
}
