using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using WriteMe.Data;
using WriteMe.Data.Entities;

namespace WriteMe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            InitializeAdminAndUser(host);
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });

        private static async void InitializeAdminAndUser(IHost host)
        {
            var logger = NLogBuilder.ConfigureNLog("Nlog.config").GetCurrentClassLogger();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var userManager = services.GetRequiredService<UserManager<User>>();
                    await RoleInitializer.InitializeAsync(userManager);
                    logger.Info("Roles created succesfully");
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "An error occurred while seeding the database.");
                }
            }
        }
    }
}