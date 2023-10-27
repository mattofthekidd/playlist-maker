import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class UserComponent {
  constructor(private httpClient: HttpClient) {}
  public Login() {
    this.httpClient.get(`/login`);
  }
}
