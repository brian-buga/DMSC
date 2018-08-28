namespace DMSC.Assessment.Extensions
{
    using DMSC.Assessment.Data;
    using DMSC.Assessment.Data.Interface;
    using DMSC.Assessment.Data.Repository;

    using DMSC.Assessment.Web;
    using DMSC.Assessment.Web.Filter;
    using DMSC.Assessment.Web.Services;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Http;
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

        public static IServiceCollection AddCustomMvc(this IServiceCollection services)
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

        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(o =>
            {
                o.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                o.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                o.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            }).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
                 options =>
                 {
                     options.LoginPath = new PathString("/account/login");
                     options.LogoutPath = new PathString("/account/logout");
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
            service.AddTransient<IChartRepository, ChartRepository>();
            service.AddTransient<IUserManager, UserManager>();

            return service;
        }
    }
}
