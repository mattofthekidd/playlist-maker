import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { LoginModalComponent } from './modals/login/login-modal.component';
import { SpotifyAuthService } from './services/spotify-auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  constructor(private dialog: MatDialog, private spotifyAuthService: SpotifyAuthService) {}

  ngOnInit(): void {

  }

  openLoginModal() {
    const loginDialogRef: MatDialogRef<LoginModalComponent> = this.dialog.open(LoginModalComponent, {
      height: '400px',
      width: '600px'
    });
    loginDialogRef.afterClosed();
  }

  public async loginRequest() {
    //TODO return to this after Observables lesson in my Udemy course.
    // await this.spotifyAuthService.login().subscribe(x => console.log("sdasdf"));
  }

}
