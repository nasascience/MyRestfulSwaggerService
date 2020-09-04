using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication;
using MyRestfulSwaggerService.Helpers;
using MyRestfulSwaggerService.Extensions;

namespace MyRestfulSwaggerService
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
            services.AddControllers();
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();

            // configure basic authentication 
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication",  options =>
                {
                  
                });
                    //options.AllowInsecureProtocol = !_environment.IsProduction();
                    //options.Realm = "RGCore.Loanbook";
                //    options.Events = new BasicAuthenticationEventsBaseControlContext.BasicAuthenticationEvents
                //    {
                //        OnValidateCredentials = context =>
                //        {
                //            var clientUsername = context.Request.Headers["ClientUsername"].ToString();
                //            var clientType = context.Request.Headers["ClientType"].ToString();
                //            var validationResult = _securityService.ValidateRequest(context.Username, context.Password).Result;
                //            if (validationResult.IsValid)
                //            {
                //                var claims = new[]
                //                {
                //                new Claim(ClaimTypes.NameIdentifier, context.Username),
                //                new Claim(ClaimTypes.Name, context.Username),
                //                new Claim("LenderName", validationResult.LenderName),
                //                new Claim("LenderId", validationResult.LenderId.ToString()),
                //                new Claim("ClientUsername", clientUsername),
                //                new Claim("ClientType", clientType),
                //            };
                //                context.Principal = new ClaimsPrincipal(new ClaimsIdentity(claims, context.Scheme.Name));
                //                context.Success();
                //            }
                //            return System.Threading.Tasks.Task.CompletedTask;
                //        },
                //        OnAuthenticationFailed = context => throw context.Exception
                //    };
                //});

            services.ConfigureLocalServices();

            //services.AddAuthentication("Basic")
            //    .AddBasic(options =>
            //    {
            //        options.AllowInsecureProtocol = !_environment.IsProduction();
            //        options.Realm = "RGCore.Loanbook";
            //        options.Events = new BasicAuthenticationEventsBaseControlContext.BasicAuthenticationEvents
            //        {
            //            OnValidateCredentials = context =>
            //            {
            //                var clientUsername = context.Request.Headers["ClientUsername"].ToString();
            //                var clientType = context.Request.Headers["ClientType"].ToString();
            //                var validationResult = _securityService.ValidateRequest(context.Username, context.Password).Result;
            //                if (validationResult.IsValid)
            //                {
            //                    var claims = new[]
            //                    {
            //                        new Claim(ClaimTypes.NameIdentifier, context.Username),
            //                        new Claim(ClaimTypes.Name, context.Username),
            //                        new Claim("LenderName", validationResult.LenderName),
            //                        new Claim("LenderId", validationResult.LenderId.ToString()),
            //                        new Claim("ClientUsername", clientUsername),
            //                        new Claim("ClientType", clientType),
            //                    };
            //                    context.Principal = new ClaimsPrincipal(new ClaimsIdentity(claims, context.Scheme.Name));
            //                    context.Success();
            //                }
            //                return System.Threading.Tasks.Task.CompletedTask;
            //            },
            //            OnAuthenticationFailed = context => throw context.Exception
            //        };
            //    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
