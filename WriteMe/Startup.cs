using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using WriteMe.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using WriteMe.Data.Entities;
using WriteMe.Data.Repository;
using WriteMe.Data.Repository.Interface;
using WriteMe.Services;
using WriteMe.SignalR;

namespace WriteMe
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
            services.AddSignalR(options =>
            {
                options.ClientTimeoutInterval = TimeSpan.FromSeconds(60 * 10);
                options.EnableDetailedErrors = true;
            }).AddMessagePackProtocol(); ;

            services.AddSingleton<IUserIdProvider, CustomUserIdProvider>();
            services.AddScoped<IRepository, Repository>();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"),
                    sqlServerOptionsAction: sqlOptions => { sqlOptions.EnableRetryOnFailure(); }));
            services.AddIdentity<User, IdentityRole<int>>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultUI()
                .AddDefaultTokenProviders();
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 1;

                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });

            services.AddHttpContextAccessor();

            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, AuthMessageSender>();

            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    IConfigurationSection googleAuthNSection =
                        Configuration.GetSection("Authentication:Google");

                    options.ClientId = googleAuthNSection["ClientId"];
                    options.ClientSecret = googleAuthNSection["ClientSecret"];
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.Use(async (context, next) =>
            {
                var logger = LogManager.GetCurrentClassLogger();
                logger.Info(
                    "______________________________________________App is started______________________________________________");
                await next();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
                endpoints.MapHub<ChatHub>("/chat");
            });
        }
    }
}