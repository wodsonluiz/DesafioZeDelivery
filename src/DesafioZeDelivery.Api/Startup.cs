using DesafioZeDelivery.Api.Models;
using DesafioZeDelivery.Api.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace DesafioZeDelivery.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ZeDeliveryDatabaseSettings>(Configuration.GetSection(nameof(ZeDeliveryDatabaseSettings)));
            services.AddSingleton<IZeDeliveryDatabaseSettings>(sp => sp.GetRequiredService<IOptions<ZeDeliveryDatabaseSettings>>().Value);

            services.AddScoped<IZeDeliveryService, ZeDeliveryService>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
