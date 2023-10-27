export const spotifyAuth = {
  client_id: '',
  client_secret: '',
} as const;

export const spotifyLinks = {
  spotifyApiUrl: 'https://accounts.spotify.com/authorize',
  redirectUri: 'http://localhost:4200/callback',
} as const;

const spotifyScopes = [
  'ugc-image-upload',
  'user-read-recently-played',
  'user-top-read',
  'user-read-playback-position',
  'user-read-playback-state',
  'user-modify-playback-state',
  'user-read-currently-playing',
  'app-remote-control',
  'streaming',
  'playlist-modify-public',
  'playlist-modify-private',
  'playlist-read-private',
  'playlist-read-collaborative',
  'user-library-modify',
  'user-library-read',
  'user-read-email',
  'user-read-private',
  'user-follow-modify',
  'user-follow-read',
] as const;
