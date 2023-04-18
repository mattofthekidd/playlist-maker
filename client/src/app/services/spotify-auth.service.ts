import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BASE_URL } from '../constants/urls';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class SpotifyAuthService {

  constructor(private http: HttpClient, private router: Router) { }

  private url: string = 'https://localhost:7239/api/spotifyauth/';

  public async getAccessToken() {
    // await this.http.get(url + )
  }

  public login() {
    //this should only be called if our token is invalid
    console.log("login request started");
    return this.http.post<string>(BASE_URL + `login`, {}).subscribe({
      next: res => window.location.href = res,
      error: e => console.log(e)
    });
  }

  // public async callback(code: string) {
  //   return await this.http.post(BASE_URL + "callback", code).subscribe({
  //     next: res => {
  //       console.log(res);
  //     },
  //     error: e => console.log(e)
  //   })
  // }

  public async test() {
    return await this.http.get(BASE_URL + "test/");
  }
}
