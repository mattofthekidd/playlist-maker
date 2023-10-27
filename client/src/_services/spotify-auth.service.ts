import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {
  spotifyAuth,
  spotifyLinks,
  spotifyScopes,
} from 'src/_constants/SpotifyAuth.constant';

@Injectable({
  providedIn: 'root',
})
export class SpotifyAuthService {
  private spotifyApiUrl = spotifyLinks.spotifyApiUrl;
  private clientId = spotifyAuth.client_id;
  private redirectUri = spotifyLinks.redirectUri;
  private scope = spotifyScopes.toString(); // Add the necessary scopes for your app

  constructor() {}

  // Method to initiate the Spotify login flow
  initiateLogin() {
    const params = new HttpParams()
      .set('client_id', this.clientId)
      .set('response_type', 'code')
      .set('redirect_uri', this.redirectUri)
      .set('scope', this.scope);

    const loginUrl = `${this.spotifyApiUrl}?${params.toString()}`;
    window.location.href = loginUrl;
  }
}
