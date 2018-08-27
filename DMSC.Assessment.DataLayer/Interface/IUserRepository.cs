namespace DMSC.Assessment.Data.Interface
{
    using DMSC.Assessment.Data.Model;
    using System;
    using System.Linq.Expressions;

    public interface IUserRepository 
    {
        User FindByAsync(Expression<Func<User, bool>> predicate);
        void Create(User entity);
        void SaveChanges();
    }
}
