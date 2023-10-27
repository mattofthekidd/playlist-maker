import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, tap } from 'rxjs';
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

  public authToken = new BehaviorSubject<string | undefined>(undefined);

  constructor(private httpClient: HttpClient) {}

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

  exchangeCodeForToken(code: string) {
    console.log('excahnge', code);
    this.httpClient
      .post<string>(`${spotifyLinks.backendUrl}/api/spotifyAuth/callback`, code)
      .pipe(
        tap((x: string) => {
          console.log(x);
          this.authToken.next(x);
        })
      )
      .subscribe();
  }
}
