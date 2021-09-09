using DesafioZeDelivery.Abstraction.Interfaces;
using DesafioZeDelivery.Domain.Service;
using DesafioZeDelivery.Infrastructure.Interfaces;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            
            services.AddSingleton(s =>
            {
                var sp = s.GetRequiredService<IZeDeliveryDatabaseSettings>();

                return sp.Configure();
            });

            services.AddScoped<IZeDeliveryService, ZeDeliveryService>();

            services.AddControllers();
            services.AddSwaggerGen();

            var sp = services.BuildServiceProvider();
            var settings = sp.GetRequiredService<IZeDeliveryDatabaseSettings>();
            var clientDb = settings.GetMongoClient();

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

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DesafioZeDelivery v1"));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
