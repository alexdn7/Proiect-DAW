using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Proiect_DAW.Data;
using Proiect_DAW.Helpers.JwtUtils;
using Proiect_DAW.Helpers.Seeders;
using Proiect_DAW.Repositories;
using Proiect_DAW.Repositories.LocatieRepository;
using Proiect_DAW.Repositories.ProducatorRepository;
using Proiect_DAW.Repositories.ProdusRepository;
using Proiect_DAW.Repositories.UsersRepository;
using Proiect_DAW.Repositories.VanzatorRepository;
using Proiect_DAW.Services.LocatieService;
using Proiect_DAW.Services.ProducatorService;
using Proiect_DAW.Services.ProdusService;
using Proiect_DAW.Services.Users;
using Proiect_DAW.Services.VanzatorService;
using Swashbuckle.AspNetCore;

namespace Proiect_DAW
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

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProdusRepository, ProdusRepository>();
            services.AddScoped<IVanzatorRepository, VanzatorRepository>();
            services.AddScoped<IProducatorRepository, ProducatorRepository>();
            services.AddScoped<ILocatieRepository, LocatieRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IVanzatorService, VanzatorService>();
            services.AddScoped<IProducatorService, ProducatorService>();
            services.AddScoped<IProdusService, ProdusService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILocatieService, LocatieService>();
            services.AddScoped<IJwtUtils, JwtUtils>();
            services.AddControllers();


            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //using (var serviceScope = app.ApplicationServices.CreateScope())
                //{
                // var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
                // context.Database.EnsureCreated();
                // var seeder = new Seeder(context);
                // seeder.Seeder();
                //}
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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
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
    }
}
