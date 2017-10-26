using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.IO;
using Microsoft.AspNetCore.Authentication.Cookies;
//using WingmanFleet.Lockdown;

namespace wingman
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
            // set up and configure Authentication - make sure to call .UseAuthentication()
            services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(o =>
				{
					o.LoginPath = "/api/login";
					o.LogoutPath = "/api/logout";
				});
                
            //services.AddTransient<AccountRepository>();

            services.AddMvc(options =>
            {
                // options.Filters.Add(new ApiExceptionFilter()); //mperholtz - manually added this line of code to demonstrate usage.
            });

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.Use(async (context, next) =>
            {
                await next();

                // If there's no available file and the request doesn't contain an extension, we're probably trying to access a page.
                // Rewrite request to use app root
                if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value) && !context.Request.Path.Value.StartsWith("/api"))
                {
                    context.Request.Path = "/index.html";
                    context.Response.StatusCode = 200; // Make sure we update the status code, otherwise it returns 404
                    await next();
                }
            });

            app.UseAuthentication();

            app.UseDefaultFiles();
            app.UseStaticFiles();


            app.UseMvcWithDefaultRoute();  
           
          
        }
    }
}
