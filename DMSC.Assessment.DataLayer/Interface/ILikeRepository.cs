namespace DMSC.Assessment.Data.Interface
{
    using DMSC.Assessment.Data.Model;

    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface ILikeRepository 
    {
        void SaveChanges();
        void Create(Like like);
        Task<IList<Like>> FindByAsync(Expression<Func<Like, bool>> predicate);
    }
}

