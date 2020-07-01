using System.Collections.Generic;
using System.Text.Json.Serialization;
using DogHouseApi.Database;
using DogHouseApi.Filters;
using DogHouseApi.Mappers;
using DogHouseApi.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DogHouseApi
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
            services.AddControllers()
                .AddNewtonsoftJson()
                    .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                        options.JsonSerializerOptions.IgnoreNullValues = true;
                    });

            services.AddControllers(options =>
                options.Filters.Add(new HttpResponseExceptionFilter()));

            services.AddVersionedApiExplorer(config =>
            {
                config.GroupNameFormat = "'v'VVV";
                config.SubstituteApiVersionInUrl = true;
            });
            services.AddApiVersioning(config =>
            {
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.ReportApiVersions = true;
            });
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddScoped<IDogEntityManager, DogEntityManager>();
            services.AddSingleton<IDogMapper, DogMapper>();
            services.AddDbContext<DogDbContext>(optionsAction => optionsAction.UseInMemoryDatabase("DogDatabase"));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {
                    Title = "Dog House API",
                    Version = "v1",
                    Description = "A place to keep your dogs"
                });
                c.SchemaFilter<SchemaExcludeFilter>();
                c.EnableAnnotations();
            });
            services.AddSwaggerGenNewtonsoftSupport();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandler("/error");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger(c =>
            {
                c.PreSerializeFilters.Add((swagger, httpReq) =>
                {
                    swagger.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}" } };
                });
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dog House Api V1");
            });
        }
    }
}
