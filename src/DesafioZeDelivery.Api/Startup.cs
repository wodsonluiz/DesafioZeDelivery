using DesafioZeDelivery.Core.Abstractions;
using DesafioZeDelivery.Core.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
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
            services.AddControllers();
            services.AddSwaggerGen();

            var sp = services.BuildServiceProvider();
            var settings = sp.GetRequiredService<IZeDeliveryDatabaseSettings>();
            var clientDb = new MongoClient(settings.ConnectionString);

            services.AddHealthChecks()
                .AddMongoDb(mongoClientSettings: clientDb.Settings, name: "Conexão com o banco de dados MongoDb", failureStatus: HealthStatus.Unhealthy);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Desafio Zé Delivery");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapHealthChecks("/healthcheck",
                    new HealthCheckOptions
                    {
                        ResponseWriter = async (context, report) =>
                        {
                            var result = JsonSerializer.Serialize(
                                new
                                {
                                    status = report.Status.ToString(),
                                    monitors = report.Entries.Select(e => new { key = e.Key, value = Enum.GetName(typeof(HealthStatus), e.Value.Status) })
                                });
                            context.Response.ContentType = MediaTypeNames.Application.Json;
                            await context.Response.WriteAsync(result);
                        }
                    }
                );
            });
        }
    }
}
