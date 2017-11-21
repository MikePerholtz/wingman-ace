using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace wingman
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                //.ConfigureAppConfiguration(SetupConfiguration)
                .UseStartup<Startup>()
                .Build();

        //mPerholtz Following was from Wildermuth pluralsight course on 
        //Building a WebApp with ASPnet Core, MVC 6, Angular 4...etc, but I 
        //went with Rick Strahl method of moving the configuration setup
        //To startup.cs.  This was to get a hold of the env variable.
         
        // private static void SetupConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder builder)
        // {
        //     // Removing the default configuration options
        //     builder.Sources.Clear();

        //     builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        //             //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
        //             .AddEnvironmentVariables();
        // }
    }

    
}
