using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.IO;
using Microsoft.AspNetCore.Authentication.Cookies;
using WingmanFleet.Lockdown;
using WingmanFleet.Models;
using Microsoft.EntityFrameworkCore;
//using WingmanFleet.Lockdown;

namespace Wingman
{
    public class Startup
    {
        readonly IHostingEnvironment HostingEnvironment;
        IConfigurationRoot Configuration { get; }
        public Startup(IHostingEnvironment env)
        {
            //mPerholtz
            HostingEnvironment = env;
            
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            
            Configuration = builder.Build();            
        }

        // mPerholtz - see Rick Strahl's in depth article on using IConfigurationRoot and
        // IConfiguration along with Dependency Injection with AddSingleton
        //https://weblog.west-wind.com/posts/2016/may/23/strongly-typed-configuration-settings-in-aspnet-core
        


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // set up and configure Authentication - make sure to call .UseAuthentication()
            services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(o =>
				{
					o.LoginPath = "/api/login";
					o.LogoutPath = "/api/logout";
				});

            services.AddDbContext<WingmanContext>(cfg =>
                {
                    var connStr = Configuration["Data:SqlServerConnectionString"];
                    cfg.UseSqlServer(connStr, opt => opt.EnableRetryOnFailure());
                }
            );
            // Also make top level configuration availab (for EF configuration and access to connection string)
            services.AddSingleton<IConfigurationRoot>(Configuration);
            services.AddSingleton<IConfiguration>(Configuration);

            //services.AddTransient<AccountRepository>();

            services.AddMvc(options =>
            {
                // options.Filters.Add(new ApiExceptionFilter()); //mperholtz - manually added this line of code to demonstrate usage.
            });

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure( IApplicationBuilder app, 
                                IHostingEnvironment env, 
                                LoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();


            app.UseAuthentication();

            app.UseDefaultFiles();
            app.UseStaticFiles();


            app.UseMvcWithDefaultRoute();  

            // catch-all handler for HTML5 client routes - serve index.html
            // mPerholtz: running ng build or npm run build will trigger webpack or angular-cli
            // to dump some neccessary files (like index.html) into the wwwroot directory where
            // they can be served to the client
            app.Run(async context =>
	        {
		        context.Response.ContentType = "text/html";
				await context.Response.SendFileAsync(Path.Combine(env.WebRootPath, "index.html"));
	        });

            #region "mPerholtz EXPAND to see was the original code for serving up index.html."
                    
            // app.Use(async (context, next) =>
            // {
            //     await next();

            //     // If there's no available file and the request doesn't contain an extension, we're probably trying to access a page.
            //     // Rewrite request to use app root
            //     if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value) && !context.Request.Path.Value.StartsWith("/api"))
            //     {
            //         context.Request.Path = "../Wingmanangular/index.html";
            //         context.Response.StatusCode = 200; // Make sure we update the status code, otherwise it returns 404
            //         await next();
            //     }
            // });

            #endregion
            
          
        }
    }
}
