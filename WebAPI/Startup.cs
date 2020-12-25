using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RecomendadosYoutube.Application.Implementations;
using RecomendadosYoutube.Application.Repository;
using RecomendadosYoutube.Application.Services;
using RecomendadosYoutube.Infra.Repository;
using RecomendadosYoutube.WebAPI.Middlewares;
using RecomendadosYoutube.WebAPI.Models;

namespace WebAPI
{
    public class Startup
    {
        protected readonly IConfiguration _Configuration;

        public Startup(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Recomendados Youtube", Version = "v1" });
            });

            services.AddDependencyInjection()
                .AddAutoMapper();
            
            services.AddControllers();

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
                options.Filters.Add(new ProducesResponseTypeAttribute(typeof(FailureResultModel), 500));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseYoutubeGetRecomendadosFactory();

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseMvc();
        }
    }

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            return services
                .AddTransient<IYoutubeGetRecomendadosService, YoutubeGetRecomendadosServices>()
                .AddSingleton<IYoutubeGetRecomendadosFactory, YoutubeGetRecomendadosFactory>()
                .AddTransient<YoutubeBRGetRecomendadosRepository>()
                .AddTransient<YoutubeUSGetRecomendadosRepository>()
                .AddTransient<YoutubeFRGetRecomendadosRepository>()
                .AddScoped<ExceptionHandlingMiddleware>();
        }

        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => t.IsSubclassOf(typeof(Profile)));

            return services.AddAutoMapper(types.ToArray());
        }
    }

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseYoutubeGetRecomendadosFactory(this IApplicationBuilder app)
        {
            app.ApplicationServices.GetService<IYoutubeGetRecomendadosFactory>()
                .Register("BR", typeof(YoutubeBRGetRecomendadosRepository))
                .Register("US", typeof(YoutubeUSGetRecomendadosRepository))
                .Register("FR", typeof(YoutubeFRGetRecomendadosRepository));

            return app;
        }
    }
}
