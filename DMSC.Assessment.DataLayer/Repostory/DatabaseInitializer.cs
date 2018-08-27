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
      
        public DatabaseInitializer( ApplicationDbContext context,
         IUserRepository applicationUser)
        {
            _context = context;
            _applicationUser = applicationUser;           
        }

        public void Seed()
        {
            _context.Database.Migrate();
             CreateUsers();              
        }       

        private void CreateUsers()
        {
            if (!_context.Users.Any())
            {
                var adminUser = new User { UserName = "admin@admin.com", FirstName = "Admin first", LastName = "Admin last", Email = "admin@admin.com", Role ="Admin", CreatedAt = DateTime.UtcNow, CreatedBy = "admin@admin.com", Mobile = "07535353535", Password ="123456"};
                _applicationUser.Create(adminUser);               

                var publisherUser = new User { UserName = "user@user.com", FirstName = "Publisher First", LastName = "Publisher Last", Email = "user@user.com", Role = "publisher", CreatedAt = DateTime.UtcNow, CreatedBy = "admin@admin.com", Mobile = "07535353535", Password = "123456" };
                _applicationUser.Create(publisherUser);               
            }

            _applicationUser.SaveChanges();
        }    

    }
}
