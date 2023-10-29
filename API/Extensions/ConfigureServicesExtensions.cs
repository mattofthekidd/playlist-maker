using System.Configuration;
using API.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace API.Extensions
{
    public static class ConfigureServicesExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration config)
        {
            config = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();
            services.AddHttpContextAccessor();

            services.AddControllers();


            services.AddAuthorization(options =>
            {

            });
            services
                .AddAuthentication(options =>
                {
                    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })
                .AddCookie(options =>
                {
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(50);
                });
            return services;
        }
    }
}
//https://accounts.spotify.com/authorize?client_id=00b49456c4994a4588d27d1c3250bdca&response_type=code&redirect_uri=https%3a%2f%2flocalhost%3a7239%2f&scope=user-read-private+user-read-email+playlist-read-private+playlist-read-collaborative+playlist-modify-private+playlist-modify-public+user-library-modify+user-library-read