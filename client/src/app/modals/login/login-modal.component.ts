import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login-modal.component.html',
  styleUrls: ['./login-modal.component.scss']
})
export class LoginModalComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  public authenticate = (loginMethod: string) => {
    // this.spotifyAuth.login();
    console.log(`sign in ${loginMethod}`);
  }
  

}
