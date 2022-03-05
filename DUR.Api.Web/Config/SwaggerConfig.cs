using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace DUR.Api.Web.Config;

public static class SwaggerConfig
{
    public static IServiceCollection AddSwaggerConfigServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Cevi Dürnten API",
                Version = "v1",
                TermsOfService = new Uri("https://ceviduernten.ch/impressum"),
                Contact = new OpenApiContact
                {
                    Email = "development@ceviduernten.ch",
                    Name = "Cevi Dürnten",
                    Url = new Uri("https://ceviduernten.ch")
                }
            });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
            /*options.AddSecurityDefinition("oauth2", new ApiKeyScheme
            {
                Description = "Standard Authorization header using the Bearer scheme. Example \" bearer {token}\"",
                In = "header",
                Name = "Authorization",
                Type = "apiKey"
            });*/
            options.OperationFilter<SecurityRequirementsOperationFilter>();
        });


        return serviceCollection;
    }

    public static IApplicationBuilder AddSwaggerConfig(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cevi Dürnten API"); });

        return app;
    }
}