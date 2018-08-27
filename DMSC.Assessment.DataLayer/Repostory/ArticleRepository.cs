namespace DMSC.Assessment.Data.Repository
{
    using DMSC.Assessment.Data.Interface;
    using DMSC.Assessment.Data.Model;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class ArticleRepository : IArticleRepository
    {
        private readonly ApplicationDbContext _context;

        public ArticleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Article entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<Article>(entity);
            _context.Set<Article>().Add(entity);
        }

        public void Edit(Article entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<Article>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public void Delete(Article entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<Article>(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public async Task<IEnumerable<Article>> FindByAsync(Expression<Func<Article, bool>> predicate)
        {
            return await _context.Set<Article>().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<Article>> GetAllAsync()
        {
            return await _context.Set<Article>().ToListAsync();
        }

        public async Task<Article> GetAsync(int id)
        {
            return await _context.Set<Article>().FirstOrDefaultAsync(e => e.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

