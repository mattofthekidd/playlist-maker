import { Component, OnInit } from '@angular/core';
import {
  MatLegacyDialog as MatDialog,
  MatLegacyDialogRef as MatDialogRef,
} from '@angular/material/legacy-dialog';
import { LoginModalComponent } from './modals/login/login-modal.component';
import { SpotifyAuthService } from './_services/spotify-auth.service';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { LoginModalModule } from './modals/login/login-modal.module';
import { HttpClientModule } from '@angular/common/http';
import { MatDialogModule } from '@angular/material/dialog';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    BrowserModule,
    RouterOutlet,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatButtonModule,
    MatDialogModule,
    LoginModalModule,
    HttpClientModule,
  ],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  constructor(
    private dialog: MatDialog,
    private spotifyAuthService: SpotifyAuthService
  ) {}

  ngOnInit(): void {
    // this.loginRequest();
  }

  // openLoginModal() {
  //   const loginDialogRef: MatDialogRef<LoginModalComponent> = this.dialog.open(LoginModalComponent, {
  //     height: '400px',
  //     width: '600px'
  //   });
  //   loginDialogRef.afterClosed();
  // }

  public async loginRequest() {
    //TODO return to this after Observables lesson in my Udemy course.
    // await this.spotifyAuthService.login().subscribe(x => console.log("sdasdf"));
    this.spotifyAuthService.login();
  }
}
