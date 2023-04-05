using System.Reflection.Metadata;

namespace API.Services
{
    public interface ISpotifyAuthService {
        // string GenRandomString(int length);
        string GenLoginString();
    }

    public class SpotifyAuthService : ISpotifyAuthService
    {
        private string GenRandomString(int length) {
            var text = "";
            const string possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            for(int i = 0; i < length; i++) {
                var rand = new Random();
                var pos = rand.NextDouble() * possible.Length;
                text += possible[(int)pos];
            }
            return text;
        }

        public string GenLoginString() {
            return SPOTIFY_AUTH_CONSTANTS.AUTH_URL +
                "response_type=code&" + 
                $"client_id={API_CONSTANTS.CLIENT_ID}&" +
                $"scope={SPOTIFY_AUTH_CONSTANTS.SCOPES}&" +
                $"redirect_uri={SPOTIFY_AUTH_CONSTANTS.REDIRECT_URI}&" +
                $"state={GenRandomString(16)}";
        }
    }
}