using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    public class SpotifyAuthController : BaseApiController {
        private ISpotifyClientBuilder _spotifyClientBuilder;
        private readonly ISpotifyAuthService _spotifyAuthService;

        public SpotifyAuthController(ISpotifyClientBuilder spotifyClientBuilder, ISpotifyAuthService spotifyAuthService) {
            _spotifyClientBuilder = spotifyClientBuilder;
            _spotifyAuthService = spotifyAuthService;
        }

        [HttpPost("login")]
        public Uri Login() {
            return _spotifyAuthService.Login();
        }

        [HttpPost("routeCallback")]
        public async Task<bool> RouteCallback(string code) {
            return await _spotifyAuthService.GetCallback(code);
            // return Redirect("http://localhost:4200/home");
        }
    }
}
