using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Converters;
using ProjectKaffekop.Core.AppService;
using ProjectKaffekop.Core.AppService.Impl;
using ProjectKaffekop.Core.DomainService;
using ProjectKaffekop.Infrastructure.SQL;
using ProjectKaffekop.Infrastructure.SQL.Repositories;

namespace ProjectKaffekopRestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            if (Environment.IsDevelopment())
            {
                services.AddDbContext<ProjectKaffekopContext>(
                    opt => opt.UseSqlite("Data Source=coffeeCupApp.db"));

            }

            if (Environment.IsProduction())
            {
                services.AddDbContext<ProjectKaffekopContext>(
                    opt => opt.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));
            }

            services.AddScoped<IKaffekopRepository,KaffeKopRepository>();
            services.AddScoped<IKaffekopService, KaffekopService>();

            services.AddCors(opt =>
                opt.AddPolicy("AllowSpecificOrigin", builder => builder.AllowAnyHeader()
                    .AllowAnyMethod().AllowAnyOrigin()));

            services.AddMvc().AddJsonOptions( op => {
                op.SerializerSettings.Converters.Add(new StringEnumConverter());
            });
            
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("AllowSpecificOrigin");
            if (env.IsDevelopment())
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<ProjectKaffekopContext>();
                    ctx.Database.EnsureCreated();
                }
                app.UseDeveloperExceptionPage();
            }
            else
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<ProjectKaffekopContext>();
                    ctx.Database.EnsureCreated();
                }
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
