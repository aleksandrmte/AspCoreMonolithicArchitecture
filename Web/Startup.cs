using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore;
using ApplicationCore.Common.Interfaces;
using Infrastructure;
using Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using NSwag;
using NSwag.Generation.Processors.Security;
using Web.Filters;
using Web.Services;

namespace Web
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
            //application.core
            services.AddApplication();
            //infrastructure
            services.AddInfrastructure(Configuration);
            //web
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddHttpContextAccessor();

            services.AddHealthChecks()
                .AddDbContextCheck<DataContext>();

            services.AddControllersWithViews(options =>
                options.Filters.Add(new ApiExceptionFilter()));

            // configure jwt authentication for api and identity auth for website
            var key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("Secret"));
            services.AddAuthentication()
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    };
                });


            services.AddOpenApiDocument(configure =>
            {
                configure.Title = "MonolithicArchitectureWeb API";
                configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Type into the textbox: Bearer {your JWT token}."
                });

                configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseHealthChecks("/health");
            app.UseStaticFiles();

            app.UseOpenApi();
            app.UseSwaggerUi3(settings =>
            {
                settings.Path = "/api";
            });
           

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
