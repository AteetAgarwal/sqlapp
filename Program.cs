using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Data.AppConfiguration;

namespace sqlapp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration(config =>
                    {
                        var settings = config.Build();
                        /*Below is for using App Configuration resource
                         * config.AddAzureAppConfiguration("Endpoint=https://demoazappconfig.azconfig.io;Id=oreb-l4-s0:46i5eUjEAzFHxIy5ssSC;Secret=Nj1I/iTqKSzsx3C38eZlTx/1clBm9DeA2t0NYKR5Mh4=");*/
                        config.AddAzureAppConfiguration(options => {
                            options.Connect("Endpoint=https://demoazappconfig.azconfig.io;Id=oreb-l4-s0:46i5eUjEAzFHxIy5ssSC;Secret=Nj1I/iTqKSzsx3C38eZlTx/1clBm9DeA2t0NYKR5Mh4=").UseFeatureFlags();
                            }); 
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}
