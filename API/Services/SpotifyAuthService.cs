using API.Constants;
using SpotifyAPI.Web;

//currently not being used

namespace API.Services {
    public interface ISpotifyAuthService {
        // Uri Login();
        // Task<bool> GetCallback(string code);

    }

    public class SpotifyAuthService : ISpotifyAuthService {
        private readonly String BASE_URL = "http://localhost:4200";
        private IConfiguration _config;
        public SpotifyAuthService(IConfiguration config) {
            _config = config;
        }

        // public Uri Login() {
        //     var loginRequest = new LoginRequest(
        //         new Uri(SPOTIFY_AUTH_CONSTANTS.REDIRECT_URI),
        //         // new Uri(APP_CONSTANTS.BASE_URL + "/api/spotifyauth/callback"),
        //         _config["SPOTIFY_CLIENT_ID"],
        //         LoginRequest.ResponseType.Code
        //     ) {
        //         Scope = SPOTIFY_AUTH_CONSTANTS.SCOPES
        //     };

        //     return loginRequest.ToUri();
        // }
        // public async Task<bool> GetCallback(string code) {
        //       var response = await new OAuthClient().RequestToken(
        //         new AuthorizationCodeTokenRequest(
        //             _config["SPOTIFY_CLIENT_ID"],
        //             _config["SPOTIFY_CLIENT_SECRET"],
        //             code,
        //             new Uri(SPOTIFY_AUTH_CONSTANTS.REDIRECT_URI)
        //         )
        //     );

        //     var spotify = new SpotifyClient(response.AccessToken);
        //     // Also important for later: response.RefreshToken
        //     return true;
        // }

    }
}