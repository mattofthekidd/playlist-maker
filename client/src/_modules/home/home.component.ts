import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { SpotifyAuthService } from 'src/_services/spotify-auth.service';
import {MatListModule} from '@angular/material/list';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    CommonModule,
    MatButtonModule,
    MatDividerModule,
    MatToolbarModule,
    MatIconModule,
    MatListModule,
  ],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent {
  constructor(private spotifyAuthService: SpotifyAuthService) {}
public fakeList_sideMenu = [
  {name: "one", description: "first item"},
  {name: "two", description: "second item"},
  {name: "three", description: "third item"},
  {name: "four", description: "fourth item"},
  
]
public fakeList_mainMenu = [
  {name: "one", description: "first item"},
  {name: "two", description: "second item"},
  {name: "three", description: "third item"},
  {name: "four", description: "fourth item"},
  
]

  public login(): void {
    this.spotifyAuthService.initiateLogin();
  }
  public searchMusic(): void {}
}
