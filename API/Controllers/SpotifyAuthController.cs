using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers {
    public class SpotifyAuthController : BaseApiController {
        private const string SpotifyTokenEndpoint = "https://accounts.spotify.com/api/token";
        private const string YourSpotifyClientId = "YOUR_SPOTIFY_CLIENT_ID";
        private const string YourSpotifyClientSecret = "YOUR_SPOTIFY_CLIENT_SECRET";

        public async Task<IActionResult> Callback(string authorizationCode) {
            try {
                using var httpClient = new HttpClient();
                var requestBody = new Dictionary<string, string>
                {
                    { "code", authorizationCode },
                    { "grant_type", "authorization_code" },
                    { "redirect_uri", SPOTIFY_AUTH_CONSTANTS.REDIRECT_URI },
                };

                var basicAuthHeaderValue = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{SPOTIFY_AUTH_CONSTANTS.}:{YourSpotifyClientSecret}"));
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {basicAuthHeaderValue}");

                var content = new FormUrlEncodedContent(requestBody);
                var response = await httpClient.PostAsync(SpotifyTokenEndpoint, content);

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