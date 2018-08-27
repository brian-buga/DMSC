namespace DMSC.Assessment.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IBaseRepository<T> where T : EntityBase, new() 
    {
        Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        void Create(T entity);
        void Edit(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}
