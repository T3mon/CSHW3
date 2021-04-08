using BLL.Services.DataProviderService;
using Bogus;
using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Linq;

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
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo() { Title = "swagger api", Version = "v1" });
            });
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
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            Seed(app);
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

        private void Seed(IApplicationBuilder app)
        {
            var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();

            using (var scope = scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                if (dbContext.Employees.FirstOrDefault(u => u.Name == "Name 1") == null)
                {

                    for (int i = 1; i <= 5000; i++)
                    {
                        dbContext.Employees.Add(new Employee { Name = "Name " + i, LastName = "LastName " + i });
                        dbContext.SaveChanges();
                        for (int j = 1; j < 2; j++)
                        {
                            dbContext.HiringHistories.Add(new HiringHistorie { CompanyName = "Company " + (i + j - 1), EmployeId = i });
                            dbContext.SaveChanges();
                            for (int k = 0; k < 2; k++)
                            {
                                dbContext.Achievements.Add(new Achievement { Dscription = "Achievement " + (i + k - 1), HiringHistorieId = i });
                            }
                        }
                    }

                }
                dbContext.SaveChanges();
            }

        }

    }
}
