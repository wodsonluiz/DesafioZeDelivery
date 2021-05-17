using DesafioZeDelivery.Core.Abstractions;
using DesafioZeDelivery.Core.Common;
using DesafioZeDelivery.Core.Service;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Net.Mime;
using System.Text.Json;

namespace DesafioZeDelivery.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddConfigurationZeDelivery(_configuration);

            services.AddSingleton<IZeDeliveryService, ZeDeliveryService>();
            services.AddSingleton<IQueryDataBase, QueryDataBase>();

            services.AddControllers();
            services.AddSwaggerGen();

            var sp = services.BuildServiceProvider();
            var settings = sp.GetRequiredService<IZeDeliveryDatabaseSettings>();
            var clientDb = settings.GetMongoClient();

            //services.AddHealthChecks()
            //    .AddMongoDb(mongoClientSettings: clientDb.Settings, name: "Conexão com o banco de dados MongoDb", failureStatus: HealthStatus.Unhealthy);

            services.AddHealthChecks()
                .AddMongoDb(clientDb.Settings, name: "mongodb", tags: new string[] { "db", "data" });

            services.AddHealthChecksUI().AddInMemoryStorage();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHealthChecks("/status-text");
            //app.UseHealthChecks("/status-json", new HealthCheckOptions()
            //{
            //    ResponseWriter = async (context, report) =>
            //    {
            //        var result = JsonSerializer.Serialize(new
            //        {
            //            currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            //            statusApplication = report.Status.ToString()
            //        }); ;

            //        context.Response.ContentType = MediaTypeNames.Application.Json;
            //        await context.Response.WriteAsync(result);
            //    }
            //});

            app.UseHealthChecks("/healthchecks-data-ui", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecksUI(options =>
            {
                options.UIPath = "/monitor";
            });

            app.UseStaticFiles();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Desafio Zé Delivery");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
