namespace DMSC.Assessment.Web
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using DMSC.Assessment.Extensions;

    using Microsoft.Extensions.FileProviders;
    using System.IO;

    public class Startup
    {
        private IHostingEnvironment HostingEnvironment { get; }
        public static IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            HostingEnvironment = env;
            Configuration = configuration;
        }
              
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCustomDbContext();
            services.AddCustomAuthentication();
            services.AddCustomMvc();
            services.RegisterCustomServices();
        }
       
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {            
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot"))
            });

            app.UseAuthentication();
            app.AddDevMiddlewares();

            app.UseMvc(routeBuilder =>
            {
                routeBuilder.MapRoute(
                  name: "areaRoute",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routeBuilder.MapRoute(
                            name: "default",
                            template: "{controller=Home}/{action=Index}/{id?}");

            });       

        }
    }
}
