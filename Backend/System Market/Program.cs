using System;
using Super_Market.Persistence.Contexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Super_Market
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var host = CreateHostBuilder(args).Build();
            
            //config required for use on database in memory
          /* using (var scope = host.Services.CreateScope())
            {
             
               var services = scope.ServiceProvider;
                var context = services.GetRequiredService<AppDbContext>();
               context.Database.EnsureCreated();
            }
            */
            
            host.Run();

            IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                    });
        }
    }
}