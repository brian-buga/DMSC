namespace DMSC.Assessment.Data.Repository
{
    using DMSC.Assessment.Data.Interface;
    using DMSC.Assessment.Data.Model;

    using System;
    using System.Linq;

    public class ChartRepository : IChartRepository
    {
        private readonly ApplicationDbContext _context;

        public ChartRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Chart Get(DateTime dateTime)
        {
            var obj = (from o in _context.Likes
                       where o.CreatedAt.Date == dateTime.Date
                       orderby o.CreatedAt
                       group o by o.ArticleId into likes                      
                       select new { c = likes.Count(), y = likes.Key, title =likes.FirstOrDefault().Article.Title }).ToList();

            return new Chart { Title = obj.Select(x => x.title).ToArray(), Likes = obj.Select(x => x.c).ToArray() };
        }
    }
}
