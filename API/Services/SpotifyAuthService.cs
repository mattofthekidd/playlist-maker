//currently not being used

using Microsoft.Extensions.Configuration;

namespace API.Services {
    public interface ISpotifyAuthService {
        // Uri Login();
        // Task<bool> GetCallback(string code);
        Task<HttpResponseMessage> ExchangeToken(string code);
    }

    public class SpotifyAuthService : ISpotifyAuthService {
        private const string SpotifyTokenEndpoint = "https://accounts.spotify.com/api/token";
        private readonly String BASE_URL = "http://localhost:4200";
        private readonly IConfiguration _config;
        public SpotifyAuthService(IConfiguration config) {
            _config = config;
        }
        public async Task<HttpResponseMessage> ExchangeToken(string code) {

            using var httpClient = new HttpClient();
            var requestBody = new Dictionary<string, string> {
                { "code", code },
                { "grant_type", "authorization_code" },
                { "redirect_uri", SPOTIFY_AUTH_CONSTANTS.REDIRECT_URI },
            };

            var basicAuthHeaderValue = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{_config["CLIENT_ID"]}:{_config["CLIENT_SECRET"]}"));
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {basicAuthHeaderValue}");

            var content = new FormUrlEncodedContent(requestBody);
            var response = await httpClient.PostAsync(SpotifyTokenEndpoint, content);
            return response;

        }
    }
}