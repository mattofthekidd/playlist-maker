using API.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using SpotifyAPI.Web;
using static SpotifyAPI.Web.Scopes;

namespace API {
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
      services.AddHttpContextAccessor();
      services.AddSingleton(SpotifyClientConfig.CreateDefault());
      services.AddControllers();
      services.AddScoped<SpotifyClientBuilder>();
      services.AddScoped<ISpotifyAuthService, SpotifyAuthService>();

      services.AddAuthorization(options =>
      {
        options.AddPolicy("Spotify", policy =>
        {
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
            UserReadEmail, UserReadPrivate, PlaylistReadPrivate, PlaylistReadCollaborative
          };
          options.Scope.Add(string.Join(",", scopes));
        });

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(WebApplication app, IWebHostEnvironment env) {
      
      if (env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
      }
      else {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        // app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();

      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();
      
      app.MapControllers();
      app.Run();
    }
  }
}
