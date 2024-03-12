using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Services;

namespace WebApplication3
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Enable CORS
            services.AddCors(c => {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            // JSON Serializers
            services.AddMvc().AddJsonOptions(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
            .AddJsonOptions(options => (options.SerializerSettings.ContractResolver as DefaultContractResolver).IgnoreSerializableAttribute = true);
            
            

            //services.Add(new ServiceDescriptor(typeof(Test), new Test(Configuration.GetConnectionString("ItemAppConnection"))));
            //services.AddControllersWithViews();
            //services.AddControllers();

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
           
            services.AddSingleton<Services.IInventoryServices, Services.InventoryService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Enable Cors
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts(); // https로 force?
            }

            app.UseHttpsRedirection(); // http -> https ?
            app.UseMvc(); 
        }
    }
}
