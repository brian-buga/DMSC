namespace DMSC.Assessment.Extensions
{
    using DMSC.Assessment.Data;
    using DMSC.Assessment.Data.Interface;
    using DMSC.Assessment.Data.Repository;

    using DMSC.Assessment.Web;
    using DMSC.Assessment.Web.Filter;
    using DMSC.Assessment.Web.Infrastrusture;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services)
        {            
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                services.AddEntityFrameworkSqlServer();
            
                var connection = Startup.Configuration["Data:LocaldbConnectionString"];
                options.UseSqlServer(connection);
                options.UseLazyLoadingProxies();
                options.UseSqlServer(connection, b => b.MigrationsAssembly("DMSC.Assessment.Web"));
            });
            return services;
        }       

        public static IServiceCollection AddCustomizedMvc(this IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ExceptionFilter));
            })
            .AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            return services;
        }
      
        public static IServiceCollection RegisterCustomServices(this IServiceCollection service)
        {
            service.AddTransient<IDatabaseInitializer, DatabaseInitializer>();
            service.AddTransient<ApplicationDbContext>();

            service.AddTransient<IUserRepository, UserRepository>();
            service.AddTransient<IArticleRepository, ArticleRepository>();
            service.AddTransient<ILikeRepository, LikeRepository>();

            service.AddTransient<IRouteProvider, RouteProvider>();

            return service;
        }
    }
}
