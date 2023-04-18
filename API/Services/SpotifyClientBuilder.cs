using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using SpotifyAPI.Web;

namespace API.Services
{
  public interface ISpotifyClientBuilder {
    Task<SpotifyClient> BuildClient();
  }
  public class SpotifyClientBuilder: ISpotifyClientBuilder {
    // private readonly HttpClient _http;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly SpotifyClientConfig _spotifyClientConfig;

    public SpotifyClientBuilder(
      // HttpClient http,
      IHttpContextAccessor httpContextAccessor, 
      SpotifyClientConfig spotifyClientConfig
    ) {
      // _http = http;
      _httpContextAccessor = httpContextAccessor;
      _spotifyClientConfig = spotifyClientConfig;
    }

    // public async Task<SpotifyClient> BuildClient()
    // {
    //   var token = await _httpContext.GetTokenAsync("Spotify", "access_token");

    //   return new SpotifyClient(_spotifyClientConfig.WithToken(token));
    // }
      public async Task<SpotifyClient> BuildClient() {
      var token = await _httpContextAccessor.HttpContext.GetTokenAsync("Spotify", "access_token");

      return new SpotifyClient(_spotifyClientConfig.WithToken(token));
    }
  }
}
