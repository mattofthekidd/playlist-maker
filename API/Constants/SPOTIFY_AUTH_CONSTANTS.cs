
using System.Collections.ObjectModel;
using SpotifyAPI.Web;

public class SPOTIFY_AUTH_CONSTANTS
{
    //https://developer.spotify.com/documentation/web-api/concepts/scopes
    // public readonly static ReadOnlyCollection<string> SCOPES =
    //     new ReadOnlyCollection<string>(new List<string>(){
    //         "user-read-private", //do I care about this?
    //         "user-read-email", //do I care about this?
    //         "playlist-read-private",
    //         "playlist-read-collaborative",
    //         "playlist-modify-private",
    //         "playlist-modify-public",
    //         "user-library-modify",
    //         "user-library-read",
    //     }
    // );

    public readonly static ICollection<string> SCOPES = new Collection<string>() {
        "user-read-private", //do I care about this?
        "user-read-email", //do I care about this?
        "playlist-read-private",
        "playlist-read-collaborative",
        "playlist-modify-private",
        "playlist-modify-public",
        "user-library-modify",
        "user-library-read",
    };


    public readonly static string REDIRECT_URI = "https://localhost:7239";    // Your redirect uri
    public readonly static string API_URL      = "https://accounts.spotify.com/api/token"; //noticed this was used twice so I moved it here.
    public readonly static string AUTH_URL     = "https://accounts.spotify.com/authorize?";
}
