using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.SpaServices.AngularCli;

using AutoMapper;

using VipcoPlanning.Services;
using VipcoPlanning.Models.Machines;
using VipcoPlanning.Models.Planning;
using Microsoft.EntityFrameworkCore;

namespace VipcoPlanning
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(option =>
                {
                    option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    option.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                });
            // Add AutoMap
            AutoMapper.Mapper.Reset();
            services.AddAutoMapper(typeof(Startup));
            // Change AddDbContextPool if EF Core 2.1
            services.AddDbContextPool<MachineContext>(option =>
                option.UseSqlServer(Configuration.GetConnectionString("MachineConnection")))
                    .AddDbContextPool<PlanningContext>(option => 
                option.UseSqlServer(Configuration.GetConnectionString("PlanningConnection"),
                opts => opts.CommandTimeout((int)System.TimeSpan.FromMinutes(2).TotalSeconds))); // Set SQL COMMAND T IMEOUT

            // Add Repositoy
            services.AddTransient(typeof(IRepositoryMachine<>), typeof(RepositoryMachine<>))
                    .AddTransient(typeof(IRepositoryPlanning<>),typeof(RepositoryPlanning<>));
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            string pathBase = Configuration.GetSection("Hosting")["PathBase"];
            if (string.IsNullOrEmpty(pathBase) == false)
                app.UsePathBase(pathBase);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501
                spa.Options.StartupTimeout = new System.TimeSpan(0, 2, 0);
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
