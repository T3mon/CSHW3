using BLL.Services.DataProviderService;
using DAL;
using DAL.Entities;
using FizzWare.NBuilder;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CustomSolutionsHW3
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
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(Configuration["SqlServerConnectionString"], b => b.MigrationsAssembly("DAL")));

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddScoped<IDataProviderProfilerService, DataProviderProfilerService>();

            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }

        //private void Seed(IApplicationBuilder app)
        //{
        //    var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();

        //    using (var scope = scopeFactory.CreateScope())
        //    {
        //        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        //        var employes = Builder<Employee>.CreateListOfSize(5000)
        //            .All()
        //                .With(c => c.Name = Faker.Name.First())
        //                .With(c => c.LastName = Faker.Name.Last())
        //            .Build();

        //        dbContext.Employees.AddOrUpdate(c => c.Id, employes);
        //    }

        //}

    }
}
