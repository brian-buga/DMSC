namespace DMSC.Assessment.Data
{
    using Microsoft.EntityFrameworkCore;
    using DMSC.Assessment.Data.Model;

    public class ApplicationDbContext : DbContext
    {       
        public DbSet<Article> Articles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Like> Likes { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {           
            return base.SaveChanges();
        }
    }
}
