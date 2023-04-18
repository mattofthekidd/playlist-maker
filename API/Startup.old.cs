using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace YourApplicationNamespace
{
    public class Startup
    {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

    public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            // Register your services here
            // services.AddTransient<IMyService, MyService>();
            // services.AddScoped<IOtherService, OtherService>();
            // services.AddSingleton<ILogger, Logger>();
            // ...

            services.AddAuthorization(options => {
                options.AddPolicy("Spotify", policy => {
                    policy.AuthenticationSchemes.Add("Spotify");
                    policy.RequireAuthenticatedUser();
                });
            });
      services
        .AddAuthentication(options =>
        {
          options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        })
        .AddCookie(options =>
        {
          options.ExpireTimeSpan = TimeSpan.FromMinutes(50);
        })
        .AddSpotify(options =>
        {
          options.ClientId = Configuration["SPOTIFY_CLIENT_ID"];
          options.ClientSecret = Configuration["SPOTIFY_CLIENT_SECRET"];
          options.CallbackPath = "/Auth/callback";
          options.SaveTokens = true;

          var scopes = new List<string> {
            // UserReadEmail, UserReadPrivate, PlaylistReadPrivate, PlaylistReadCollaborative
          };
          options.Scope.Add(string.Join(",", scopes));
        });
            services.AddControllers(); // Add MVC Controller services
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // Use the developer exception page in development environment
            }

            app.UseRouting(); // Enable routing

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // Map controllers to endpoints
            });
        }
    }
}