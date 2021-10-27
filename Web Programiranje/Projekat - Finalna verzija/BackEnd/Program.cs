using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Server
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
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseKestrel(opt =>
                    {
                        opt.Listen(IPAddress.Loopback, port: 5006, opt => opt.UseHttps());
                        //opt.ListenAnyIP(5003, opt => opt.UseHttps());
                        // opt.ListenLocalhost(5004, opt => opt.UseHttps());
                        //opt.ListenLocalhost(5005, opt => opt.UseHttps());
                    });
                });
    }
}
