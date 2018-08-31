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
        private readonly IUserRepository _user;
        private readonly ILikeRepository _likeRepository;

        public DatabaseInitializer( ApplicationDbContext context, ILikeRepository likeRepository,
         IUserRepository user)
        {
            _likeRepository = likeRepository;
            _context = context;
            _user = user;           
        }

        public void Seed()
        {
            _context.Database.Migrate();
             CreateUsers();
             //CreateLikes();
        }       

        private void CreateUsers()
        {
            if (!_context.Users.Any())
            {
                var adminUser = new User { UserName = "admin@pressford.com", FirstName = "Admin first", LastName = "Admin last", Email = "admin@admin.com", Role ="Admin", CreatedAt = DateTime.UtcNow, CreatedBy = "admin@admin.com", Mobile = "07535353535", Password ="123456"};
                _user.Create(adminUser);               

                var publisherUser = new User { UserName = "publisher@pressford.com", FirstName = "Publisher First", LastName = "Publisher Last", Email = "publisher@pressford.com", Role = "Publisher", CreatedAt = DateTime.UtcNow, CreatedBy = "admin@admin.com", Mobile = "07535353535", Password = "123456" };
                _user.Create(publisherUser);

                var publisherUser1 = new User { UserName = "publisher1@pressford.com", FirstName = "Publisher1 First", LastName = "Publisher1 Last", Email = "publisher1@pressford.com", Role = "Publisher", CreatedAt = DateTime.UtcNow, CreatedBy = "admin@admin.com", Mobile = "07535353535", Password = "123456" };
                _user.Create(publisherUser);

                var publisherUser2 = new User { UserName = "publisher2@pressford.com", FirstName = "Publisher2 First", LastName = "Publisher2 Last", Email = "publisher2@pressford.com", Role = "Publisher", CreatedAt = DateTime.UtcNow, CreatedBy = "admin@admin.com", Mobile = "07535353535", Password = "123456" };
                _user.Create(publisherUser);

                var employerUser = new User { UserName = "employee@pressford.com", FirstName = "Employee First", LastName = "Employee Last", Email = "employee@pressford.com", Role = "Employee", CreatedAt = DateTime.UtcNow, CreatedBy = "admin@admin.com", Mobile = "07535353535", Password = "123456" };
                _user.Create(employerUser);

                var employerUser1 = new User { UserName = "employee1@pressford.com", FirstName = "Employee1 First", LastName = "Employee1 Last", Email = "employee1@pressford.com", Role = "Employee", CreatedAt = DateTime.UtcNow, CreatedBy = "admin@admin.com", Mobile = "07535353535", Password = "123456" };
                _user.Create(employerUser1);

                var employerUser2 = new User { UserName = "employee2@pressford.com", FirstName = "Employee2 First", LastName = "Employee2 Last", Email = "employee2@pressford.com", Role = "Employee", CreatedAt = DateTime.UtcNow, CreatedBy = "admin@admin.com", Mobile = "07535353535", Password = "123456" };
                _user.Create(employerUser2);

                var employerUser3 = new User { UserName = "employe3e@pressford.com", FirstName = "Employee3 First", LastName = "Employee3 Last", Email = "employee3@pressford.com", Role = "Employee", CreatedAt = DateTime.UtcNow, CreatedBy = "admin@admin.com", Mobile = "07535353535", Password = "123456" };
                _user.Create(employerUser3);

                var employerUser4 = new User { UserName = "employee4@pressford.com", FirstName = "Employee4 First", LastName = "Employee4 Last", Email = "employee4@pressford.com", Role = "Employee", CreatedAt = DateTime.UtcNow, CreatedBy = "admin@admin.com", Mobile = "07535353535", Password = "123456" };
                _user.Create(employerUser4);
            }

            _user.SaveChanges();
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
