using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Services;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers {
    public class SpotifyAuthController : BaseApiController {

        private SpotifyAuthService _spotifyAuthService;
        public SpotifyAuthController(SpotifyAuthService spotifyAuthService) {
            _spotifyAuthService = spotifyAuthService;
        }

        [HttpPost("Callback")]
        public async Task<IActionResult> Callback([FromBody]string authorizationCode) {
            try {
                var response = await _spotifyAuthService.ExchangeToken(authorizationCode);
                if (response.IsSuccessStatusCode) {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return Ok(responseContent);
                }
                else {
                    // Handle the error response from Spotify, and return an appropriate error response
                    return BadRequest("Token exchange failed");
                }
            }
            catch (Exception ex) {
                // Handle any exceptions that occur during the token exchange process
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}