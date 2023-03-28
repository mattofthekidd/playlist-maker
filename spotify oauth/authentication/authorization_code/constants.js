const CLIENT_ID     = '00b49456c4994a4588d27d1c3250bdca';     // Your client id
const CLIENT_SECRET = '7d133a7f99044b95bec815c9578b8f27'; // Your secret
const REDIRECT_URI  = 'http://localhost:8888/callback';    // Your redirect uri
const API_URL       = 'https://accounts.spotify.com/api/token'; //noticed this was used twice so I moved it here.
const AUTH_URL      = 'https://accounts.spotify.com/authorize?';
module.exports = {CLIENT_ID, CLIENT_SECRET, REDIRECT_URI, API_URL, AUTH_URL};
// Their are a lot more variables that are considered constants (strings) that can be moved here.
// For now I want to focus on getting the app working.
// TODO: move anything with a url string into here.