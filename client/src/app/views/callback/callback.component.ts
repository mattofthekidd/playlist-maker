import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SpotifyAuthService } from 'src/app/_services/spotify-auth.service';

@Component({
  selector: 'app-callback',
  templateUrl: './callback.component.html',
  styleUrls: ['./callback.component.scss']
})
export class CallbackComponent implements OnInit {
  private code: string = "";
  constructor(
    private route: ActivatedRoute,
    private spotifyAuthService: SpotifyAuthService
  ) {}

  ngOnInit(): void {
    console.log(this.route.snapshot.queryParamMap);
    this.code = !!this.route.snapshot.queryParamMap?.get('code') 
      ? this.route.snapshot.queryParamMap.get('code')! 
      : "";
    this.validateCode();
    this.sendCodeToBackend();
  }

  private validateCode(): void {
    if(this.code === "") {
      console.log("Code is empty. User is not authorized");
      //route user to error page or use this as error page.
    }
  }

  private sendCodeToBackend(): void {
    this.spotifyAuthService.routeCallback(this.code);
  }

}
