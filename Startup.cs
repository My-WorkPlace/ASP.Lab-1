using ASP.Lab_1.Data;
using ASP.Lab_1.Data.Interfaces;
using ASP.Lab_1.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ASP.Lab_1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // receive conString from config 
            var connection = Configuration.GetConnectionString("DefaultConnection");
            // add context AppContextDataBase such as service
            services.AddDbContext<AppDBContent>(options =>
                options.UseSqlServer(connection));
            services.AddTransient<IAllSites,SiteRepository>();
            services.AddTransient<ISitesCategory,CategoryRepository>();
            services.AddMvc(mvcOptions =>
            {
                mvcOptions.EnableEndpointRouting = false;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseMvcWithDefaultRoute();//call default controller
            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContent context = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Initial(context);
            }
        }
    }
}
