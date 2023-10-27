export const spotifyAuth = {
  client_id: '00b49456c4994a4588d27d1c3250bdca',
  client_secret: 'b49462e48d784c06a4dca32893d347f5',
} as const;

export const spotifyLinks = {
  spotifyApiUrl: 'https://accounts.spotify.com/authorize',
  redirectUri: 'http://localhost:4200/callback',
} as const;

export const spotifyScopes = [
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
