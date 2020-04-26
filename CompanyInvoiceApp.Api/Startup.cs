using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyInvoiceApp.Api.Data;
using CompanyInvoiceApp.Api.Model;
using CompanyInvoiceApp.Api.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CompanyInvoiceApp.Api
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

            //Adding the Local SQL serer DBContext
            services.AddDbContext<CompanyInvoiceAppDbContext>(options => 
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString"));
            });

            //Adding service for use in controllers
            services.AddScoped<IRepository<Company>,CompanyRepository>();
            services.AddScoped<IRepository<Invoice>,InvoiceRepository>();


            services.AddControllers().AddNewtonsoftJson(options => {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            }

            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
