using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    public class SpotifyAuthController : BaseApiController {
        private ISpotifyClientBuilder _spotifyClientBuilder;
        private readonly ISpotifyAuthService _authService;

        public SpotifyAuthController(ISpotifyClientBuilder spotifyClientBuilder, ISpotifyAuthService authService) {
            _spotifyClientBuilder = spotifyClientBuilder;
            _authService = authService;
        }

        // [HttpPost("login")]
        // public async Task<SpotifyClient> Login() {
        //     SpotifyClient spotify = await _spotifyClientBuilder.BuildClient();
        //     return spotify;
        // }

        [HttpPost("login")]
        public Uri Login() {
            return _authService.Login();
        }

        [HttpPost("callback")]
        public async Task<RedirectResult> Callback(string code) {
            await _authService.GetCallback(code);
            return Redirect("http://localhost:4200/home");
        }

        // [HttpPost("test")]
        // public IActionResult Test() {
        //     return StatusCode(200, "boyoooh");
        // }
    }
}
