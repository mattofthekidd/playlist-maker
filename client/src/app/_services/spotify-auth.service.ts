import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BASE_URL } from '../_constants/urls';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class SpotifyAuthService {

  constructor(private http: HttpClient, private router: Router) { }

  private url: string = `${BASE_URL}/spotifyauth/` as const;

  public login() {
    return this.http.post<string>(this.url + `login`, {}).subscribe({
      next: res => window.location.href = res,
      error: e => console.log(e)
    });
  }

  public async routeCallback(code: string) {
    const params = new HttpParams().set('code', code);
    return await this.http.post<boolean>(this.url + `routeCallback`, null, {params}).subscribe({
      next: res => {
        if(res) this.router.navigate(['/home']);
        else {}//do something?
      },
      error: e => console.log(e)
    })
    
  }

  public async test() {
    return await this.http.get(this.url + "test/");
  }
}
