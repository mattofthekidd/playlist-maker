using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using SpotifyAPI.Web;

namespace API.Controllers
{
    
    public class SpotifyAuthController : BaseApiController
    {
        private ISpotifyAuthService _service;
        public SpotifyAuthController(ISpotifyAuthService service) {
            _service = service;
        }

        [HttpGet("login")]
        public async Task<HttpResponseMessage> Login() {
            using var http = new HttpClient();
            //https://johnnycrazy.github.io/SpotifyAPI-NET/docs/authorization_code
            // used this in created the auth. My goal is not to work on auth but to build a tool for playlist generation

            //https://accounts.spotify.com/authorize?response_type=code&client_id=12345&
            //scope=user-read-private%20user-read-email&redirect_uri=http%3A%2F%2Flocalhost%3A8888%2Fcallback&state=xyz

            // var x = await _http.GetAsync(_service.GenLoginString());
            // return x;
            var loginRequest = new LoginRequest(
                new Uri(SPOTIFY_AUTH_CONSTANTS.REDIRECT_URI),
                API_CONSTANTS.CLIENT_ID,
                LoginRequest.ResponseType.Code
            ) {
                Scope = SPOTIFY_AUTH_CONSTANTS.SCOPES
            };
            return await http.GetAsync(loginRequest.ToUri());        

        }

        [HttpGet("callback")] 
        public async Task Callback(string code) {
            var response = await new OAuthClient().RequestToken(
                new AuthorizationCodeTokenRequest(API_CONSTANTS.CLIENT_ID, API_CONSTANTS.CLIENT_SECRET, code, new Uri(SPOTIFY_AUTH_CONSTANTS.REDIRECT_URI))
            );

            var spotify = new SpotifyClient(response.AccessToken);
            
            
        }

        [HttpGet("test")]
        public IActionResult Test() {
            return StatusCode(200);
        }
    }
}
