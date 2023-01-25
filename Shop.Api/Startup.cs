using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Shop.Api.Data;
using Shop.Api.Interfaces;
using Shop.Api.Services;

namespace Shop.Api
{
    // з мейна потрапляємо сюди   (це основа тут підключення інтерфейсів та класів)
    public class Startup
    {
        public Startup(IConfiguration configuration) //передаємо інтерфейс
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // додаємо створені інтерфейси та класи (передаємо їх в мейн)
            services.AddTransient<IproductService, ProductService>();  // інтерфейси викликають методи.   Класи в яких прописані методи
            services.AddTransient< IProductRepo, ProductRepo > ();

            services.AddControllers();
            // додаємо клієнта
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Shop.Api", Version = "v1" });
            });
        }

     // This method gets called by the runtime. Використовуйте цей метод для налаштування конвеєра запитів HTTP.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shop.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
