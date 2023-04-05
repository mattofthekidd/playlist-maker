import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SpotifyAuthService {

  constructor(private http: HttpClient) { }

  private url: string = 'https://localhost:7239/api/spotifyauth/';

  public async getAccessToken() {
    // await this.http.get(url + )
  }

  public async login() {
    console.log("login request started")
    return await this.http.get(this.url + "login").subscribe(res => {
      return res;
    });
  }

  public async test() {
    return await this.http.get(this.url + "test/");
  }
}
