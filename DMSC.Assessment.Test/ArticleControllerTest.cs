namespace DMSC.Assessment.Test
{
    using DMSC.Assessment.Backend.Controllers;
    using DMSC.Assessment.Backend.Models;
    using DMSC.Assessment.Data.Interface;
    using DMSC.Assessment.Data.Model;

    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class ArticleControllerTest
    {
        private Mock<IArticleRepository> mockArticleRepos;   
        private ArticleController controller;

        public ArticleControllerTest()
        {
            mockArticleRepos = new Mock<IArticleRepository>(MockBehavior.Default);          
            controller = new ArticleController(mockArticleRepos.Object);
        }

        [Fact]
        public async void IndexView_ShouldReturnArticleModels()
        {           
            mockArticleRepos.Setup(x => x.GetAllAsync()).ReturnsAsync(new List<Article>());

            var target = await controller.Index();
            var viewResult = Assert.IsType<ViewResult>(target);
            var model = Assert.IsAssignableFrom<List<ArticleModel>>(viewResult.ViewData.Model);

            Assert.Equal(0, model.Count);
        }

        [Fact]
        public void Create_ShouldReturn_ArticleModel()
        {          
            var target = controller.Create();
            var viewResult = Assert.IsType<ViewResult>(target);

            Assert.IsAssignableFrom<ArticleModel>(viewResult.ViewData.Model);           
        }

        [Fact]
        public void Create_ShouldReturn_ModelWithIsSuccess_Equalfalse()
        {
            var target = controller.Create();
            var viewResult = Assert.IsType<ViewResult>(target);
            var model = Assert.IsAssignableFrom<ArticleModel>(viewResult.ViewData.Model);

            Assert.Equal(false, model.IsSuccess);
        }

        [Fact]
        public void WhenSave_CreateShouldReturn_ModelWithIsSuccess_Equaltrue()
        {
            mockArticleRepos.Setup(x => x.Create(It.IsAny<Article>()));
            mockArticleRepos.Setup(x => x.SaveChanges());
                 
            var target = controller.Create(new ArticleModel() { Author = "publisher@tester.com", Active = false, Published = DateTime.Now, Content = "Test", Title = "Test" } );
           
            var viewResult = Assert.IsType<ViewResult>(target);
            var model = Assert.IsAssignableFrom<ArticleModel>(viewResult.ViewData.Model);

            Assert.Equal(true, model.IsSuccess);
        }

        [Fact]
        public async void EditShouldReturnArticleModel()
        {
            mockArticleRepos.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(new Article() { Author = new User { FirstName = "publisher", LastName = "publisher" }, Likes = new List<Like>(), Id = 15, UserId = 5, Active = false, Published = DateTime.Now, Content = "Test", Title = "Test" });
          
            var target = await controller.Edit(It.IsAny<int>());

            var viewResult = Assert.IsType<ViewResult>(target);

            Assert.IsAssignableFrom<ArticleModel>(viewResult.ViewData.Model);           
        }

        [Fact]
        public void WhenSave_EditShouldReturn_ModelWithIsSuccess_Equaltrue()
        {
            mockArticleRepos.Setup(x => x.Create(It.IsAny<Article>()));
            mockArticleRepos.Setup(x => x.SaveChanges());

            var target = controller.Edit(new ArticleModel() { Id = 15, Author = "publisher@tester.com", Active = false, Published = DateTime.Now, Content = "Test", Title = "Test" });

            var viewResult = Assert.IsType<ViewResult>(target);
            var model = Assert.IsAssignableFrom<ArticleModel>(viewResult.ViewData.Model);

            Assert.Equal(true, model.IsSuccess);
        }

        [Fact]
        public async void Delete_ShouldReturn_Ok()
        {
            mockArticleRepos.Setup(x => x.Delete(It.IsAny<Article>()));
            mockArticleRepos.Setup(x => x.SaveChanges());

            var target = await controller.Delete(It.IsAny<int>());

            Assert.IsType<OkResult>(target);           
        }
    }
}
