using System.Net;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Permissions.Data.Permissions.Context;
using Permissions.Data.Permissions.Repositories;
using Permissions.Domain.Application.Permit;
using Permissions.Domain.Application.PermitType;
using Permissions.Domain.Application.PermitType.Queries.GetAllPermitType;
using Serilog;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Permissions.Api.Extensions
{
    public static class ServiceExtensions
    {
        #region Implementation Cors
        public static IServiceCollection ConfigureCors(this IServiceCollection services)
        {

            services.AddCors();

            return services;
        }

        #endregion

        #region Implementation Conexion Db 
        public static IServiceCollection ConfigureDatabases(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<PermissionsContext>(options => options.UseSqlServer(configuration.GetConnectionString("PermissionsDb")));


            return services;
        }
        #endregion

        #region Implementation Dependencies 
        public static IServiceCollection ConfigureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddTransient<IPermitTypeRepository, PermitTypeRepository>();
            services.AddTransient<IPermitRepository, PermitRepository>();

            return services;
        }

        #endregion

        #region Implementation Swagger

        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "V1",
                    Title = "Inspecciones Virtuales API",
                    Description = "Api Expuesto por Andres Valbuena Prueba Permisos"
                });

            });


            return services;
        }

        #endregion

        #region Configuration Mediator 

        public static IServiceCollection ConfigureMediator(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetAllPermitTypesQueryHandler));

            return services;
        }

        #endregion

        #region Configuration Erros

        /// <summary>
        /// Configures the error global handler.
        /// </summary>
        /// <param name="app">Application builder.</param>
        /// <returns>IApplicationBuilder.</returns>
        public static IApplicationBuilder UseGlobalErrorHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    Log.Logger.Error(contextFeature.Error, "General api error");

                    await context
                        .Response
                        .WriteAsync(new ErrorResponse(context.Response.StatusCode, "Se ha producido un error")
                        {
                            ErrorDetail = JsonConvert.SerializeObject(contextFeature.Error)
                        }.ToString());
                });
            });

            return app;
        }
        #endregion
    }
}
