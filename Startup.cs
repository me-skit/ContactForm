using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SkeletonNetCore.Config;
using SkeletonNetCore.DAO;
using SkeletonNetCore.DAO.Impl;
using SkeletonNetCore.Models;
using SkeletonNetCore.Services;
using SkeletonNetCore.Services.Impl;
using SkeletonNetCore.Services.Models;

namespace SkeletonNetCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Setting up routes to lowercase
            services.AddRouting(options => options.LowercaseUrls = true);

            // Dependency Injection
            services.AddDbContext<ApiDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("ConnectionStrings")));
            services.AddTransient<ISvc<Product>, ProductSvcImpl>();
            services.AddTransient<IDao<ProductDto>, ProductDaoImpl>();
            services.AddTransient<ISvc<Contact>, ContactSvcImpl>();
            services.AddTransient<IDao<ContactDto>, ContactDaoImpl>();

            services.AddCors(options =>
            {
            options.AddPolicy("Todos",
                builer => builer.WithOrigins("*").WithHeaders("*").WithMethods("*"));
            });

            services.AddControllers();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Incubadora",
                    Version = "v1",
                    Description = "An ASP.NET Core Web API for managing loan requesting",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Contact",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "License",
                        Url = new Uri("https://example.com/license")
                    }
                });
                // using System.Reflection;
                string xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsStaging())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.yaml", "Incubadora v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("Todos");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
                });
            });
        }
    }
}
