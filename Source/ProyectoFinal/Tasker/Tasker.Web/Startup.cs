using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tasker.Web.DataAccess;
using Tasker.Web.DataAccess.Repository;

namespace Tasker.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //Configura la clase encargada de la gestión de datos
            //InMemory = Usamos una base de datos en memoria
            //services.AddDbContext<TaskerDbContext>(options =>
            //                        options.UseInMemoryDatabase("TaskerDB"));

            services.AddDbContext<TaskerDbContext>(options =>
                                    options.UseSqlServer(Configuration.GetConnectionString("TaskerDB")));

            //Le indica al controlador que cuando se llame la interfaz, cree un objeto de la clase
            services.AddTransient<ITaskRepository, TaskRepository>();
           

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
