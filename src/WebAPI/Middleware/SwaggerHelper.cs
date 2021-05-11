using System.IO;
using System.Reflection;
using WebAPI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using WebAPI.Filters;

namespace WebAPI.Middleware
{
    public static class SwaggerHelper
    {
        public static IServiceCollection AddCustomSwaggerGen(this IServiceCollection services, Startup startup)
        {
            services.AddVersionedApiExplorer(o =>
                {
                    o.GroupNameFormat = "'v'VVV";
                    o.SubstituteApiVersionInUrl = true;
                });

            services.AddApiVersioning(options => options.ReportApiVersions = true);

            services.AddSwaggerGen(
                options =>
                {
                    var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerDoc(description.GroupName, new OpenApiInfo()
                        {
                            Title = $"{startup.GetType().Assembly.GetCustomAttribute<System.Reflection.AssemblyProductAttribute>().Product} {description.ApiVersion}",
                            Version = description.ApiVersion.ToString(),
                            Description = description.IsDeprecated ? $"{startup.GetType().Assembly.GetCustomAttribute<AssemblyDescriptionAttribute>().Description} - DEPRECATED" : startup.GetType().Assembly.GetCustomAttribute<AssemblyDescriptionAttribute>().Description,
                        });
                    }

                    options.OperationFilter<SwaggerDefaultValues>();

                    options.IncludeXmlComments(Path.Combine(
                                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"{startup.GetType().Assembly.GetName().Name}.xml"
                                ));

                });

            return services;
        }

        public static IApplicationBuilder UserCustomSwaggerGen(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    var provider = app.ApplicationServices.GetRequiredService<IApiVersionDescriptionProvider>();
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }
                });

            return app;
        }

    }
}