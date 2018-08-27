namespace DMSC.Assessment.Web
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using DMSC.Assessment.Extensions;
    using DMSC.Assessment.Web.Infrastrusture;
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCustomDbContext();         
            services.AddCustomizedMvc();
            services.RegisterCustomServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {            
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot"))
            });

            app.AddDevMiddlewares();

            app.UseMvc(routeBuilder =>
            {
                app.ApplicationServices.GetRequiredService<IRouteProvider>().RegisterRoutes(routeBuilder);
            });
           
        }
    }
}
