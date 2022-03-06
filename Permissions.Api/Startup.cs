using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Permissions.Api.Extensions;
using Permissions.Data.Permissions.Context;
using System.Linq;

namespace Permissions.Api
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
            services
                .ConfigureDatabases(Configuration)
                .ConfigureMediator()
                .ConfigureDependencies(Configuration)
                .ConfigureCors()
                .ConfigureSwagger();


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, PermissionsContext permissionsContext)
        {

            if (!permissionsContext.permitTypes.Any())
            {
                permissionsContext.permitTypes.Add(new Domain.Application.PermitType.PermitType { Description = "ENFERMEDAD" });
                permissionsContext.permitTypes.Add(new Domain.Application.PermitType.PermitType { Description = "DILIGENCIA" });
                permissionsContext.permitTypes.Add(new Domain.Application.PermitType.PermitType { Description = "OTROS" });

                permissionsContext.SaveChanges();
            }


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseGlobalErrorHandler();

            app.UseSwagger();

            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("v1/swagger.json", "Api Inspecciones Virtuales V1");
            });

            app.UseCors(builder =>
            {
                builder.AllowAnyHeader();
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
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
