namespace DMSC.Assessment.Data.Repository
{
    using DMSC.Assessment.Data.Interface;
    using DMSC.Assessment.Data.Model;

    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;

    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly ApplicationDbContext _context;     
        private readonly IUserRepository _applicationUser;
        private readonly ILikeRepository _likeRepository;


        public DatabaseInitializer( ApplicationDbContext context, ILikeRepository likeRepository,
         IUserRepository applicationUser)
        {
            _likeRepository = likeRepository;
            _context = context;
            _applicationUser = applicationUser;           
        }

        public void Seed()
        {
            _context.Database.Migrate();
             CreateUsers();
             CreateLikes();
        }       

        private void CreateUsers()
        {
            if (!_context.Users.Any())
            {
                var adminUser = new User { UserName = "admin@admin.com", FirstName = "Admin first", LastName = "Admin last", Email = "admin@admin.com", Role ="Admin", CreatedAt = DateTime.UtcNow, CreatedBy = "admin@admin.com", Mobile = "07535353535", Password ="123456"};
                _applicationUser.Create(adminUser);               

                var publisherUser = new User { UserName = "user@user.com", FirstName = "Publisher First", LastName = "Publisher Last", Email = "user@user.com", Role = "publisher", CreatedAt = DateTime.UtcNow, CreatedBy = "admin@admin.com", Mobile = "07535353535", Password = "123456" };
                _applicationUser.Create(publisherUser);

                var employerUser = new User { UserName = "employee@user.com", FirstName = "employee First", LastName = "employee Last", Email = "employee@user.com", Role = "employee", CreatedAt = DateTime.UtcNow, CreatedBy = "admin@admin.com", Mobile = "07535353535", Password = "123456" };
                _applicationUser.Create(employerUser);
            }

            _applicationUser.SaveChanges();
        }
        
        private void CreateLikes()
        {
            if (!_context.Likes.Any())
            {
                for (int i = 0; i < 4; i++)
                {
                    _likeRepository.Create(new Like { UserId = 5, ArticleId = 15, CreatedAt = DateTime.UtcNow, CreatedBy = "user@user.com" });
                }

                for (int i = 0; i < 3; i++)
                {
                    _likeRepository.Create(new Like { UserId = 5, ArticleId = 16, CreatedAt = DateTime.UtcNow, CreatedBy = "user@user.com" });
                }

                for (int i = 0; i < 10; i++)
                {
                    _likeRepository.Create(new Like { UserId = 5, ArticleId = 17, CreatedAt = DateTime.UtcNow, CreatedBy = "user@user.com" });
                }

                for (int i = 0; i < 8; i++)
                {
                    _likeRepository.Create(new Like { UserId = 5, ArticleId = 18, CreatedAt = DateTime.UtcNow, CreatedBy = "user@user.com" });
                }

                for (int i = 0; i < 5; i++)
                {
                    _likeRepository.Create(new Like { UserId = 5, ArticleId = 1008, CreatedAt = DateTime.UtcNow, CreatedBy = "user@user.com" });
                }
            }

            _likeRepository.SaveChanges();
        }

    }
}
