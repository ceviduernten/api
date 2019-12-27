using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using DUR.Api.Presentation;
using DUR.Api.Presentation.Mapper;
using DUR.Api.Repo.Nextcloud;
using DUR.Api.Services;
using DUR.Api.Settings;
using DUR.Api.Web.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DUR.Api.Web
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
            services.AddAutoMapper(c => c.AddProfile<Mappers>(), typeof(Startup));
            services.Configure<GeneralSettings>(Configuration.GetSection("GeneralSettings"));
            services.Configure<NextcloudInterfaceSettings>(Configuration.GetSection("NextcloudInterfaceSettings"));
            services.AddSwaggerConfigServices();
            services.AddSingleton(Configuration);
            services.AddOptions();
            services.AddCorsConfigServices();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAutofac();
            services.AddMemoryCache();
            services.AddMvc();
            services.Configure<MvcOptions>(options =>
            {
                options.EnableEndpointRouting = false;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.AddSwaggerConfig();
            app.UseAuthorization();
            app.AddCorsConfig();
            app.UseHttpsRedirection();
            app.AddRouteConfig();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            ServicesInjector.RegisterModule(builder);
            QueriesInjector.RegisterModule(builder);
            PresenterInjector.RegisterModule(builder);
            MapperInjector.RegisterModule(builder);
            NextcloudRepositoryInjector.RegisterModule(builder);
        }
    }
}
