using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bug_MapToIPv4
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
                    webBuilder.ConfigureLogging(logging => 
                    {
                        logging.ClearProviders();
                        logging.AddConsole();
                    });
                    
                    webBuilder.ConfigureKestrel(kestrel =>
                    {
                        kestrel.ListenAnyIP(5001);
                        kestrel.ListenAnyIP(5000);
                        kestrel.AddServerHeader = false;
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}
