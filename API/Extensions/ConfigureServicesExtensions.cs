using API.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using SpotifyAPI.Web;

namespace API.Extensions
{
    public static class ConfigureServicesExtensions {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration config) {
            services.AddHttpContextAccessor();
            services.AddSingleton(SpotifyClientConfig.CreateDefault());
            services.AddScoped<ISpotifyClientBuilder, SpotifyClientBuilder>();
            services.AddScoped<ISpotifyAuthService, SpotifyAuthService>();
            services.AddControllers();

            services.AddAuthorization(options => {
                options.AddPolicy("Spotify", policy => {
                    policy.AuthenticationSchemes.Add("Spotify");
                    policy.RequireAuthenticatedUser();
                });
            });
            services
                .AddAuthentication(options => {
                    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })
                .AddCookie(options => {
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(50);
                })
                .AddSpotify(options => {
                    options.ClientId = config["SPOTIFY_CLIENT_ID"];
                    options.ClientSecret = config["SPOTIFY_CLIENT_SECRET"];
                    // options.CallbackPath = "/api/spotifyauth/callback";
                    // options.CallbackPath = "/Auth/callback";
                    options.SaveTokens = true;
                    
                    // options.Scope.Add("user-read-private");
                    // options.Scope.Add(string.Join(",", SPOTIFY_AUTH_CONSTANTS.SCOPES));
                });
            return services;
        }
    }
}
//https://accounts.spotify.com/authorize?client_id=00b49456c4994a4588d27d1c3250bdca&response_type=code&redirect_uri=https%3a%2f%2flocalhost%3a7239%2f&scope=user-read-private+user-read-email+playlist-read-private+playlist-read-collaborative+playlist-modify-private+playlist-modify-public+user-library-modify+user-library-read