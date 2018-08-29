namespace DMSC.Assessment.Data.Repository
{
    using DMSC.Assessment.Data.Interface;
    using DMSC.Assessment.Data.Model;

    using Microsoft.EntityFrameworkCore.ChangeTracking;

    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }                                

        public void Create(User entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<User>(entity);
            _context.Set<User>().Add(entity);
        }       

        public User FindBy(Expression<Func<User, bool>> predicate)
        {
            return _context.Set<User>().Where(predicate).FirstOrDefault();
        }
       
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
