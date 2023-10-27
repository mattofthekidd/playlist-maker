import { Component, DestroyRef, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SpotifyAuthService } from 'src/_services/spotify-auth.service';
import { ActivatedRoute, Router } from '@angular/router';
import { tap } from 'rxjs';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

@Component({
  selector: 'app-callback',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './callback.component.html',
  styleUrls: ['./callback.component.scss'],
})
export class CallbackComponent implements OnInit {
  constructor(
    private route: ActivatedRoute,
    private spotifyService: SpotifyAuthService,
    private router: Router,
    private destroyRef: DestroyRef
  ) {}

  ngOnInit() {
    // Capture the authorization code from the URL
    this.route.queryParams
      .pipe(
        takeUntilDestroyed(this.destroyRef),
        tap((params: any) => {
          const code = params['code'];

          if (code) {
            // Send the authorization code to your .NET backend for token exchange
            this.spotifyService.exchangeCodeForToken(code);
          } else {
            // Handle the case where no authorization code is present in the URL
            // Redirect the user to an error page or display an error message
            this.router.navigate(['/error']);
          }
        })
      )
      .subscribe();
  }
}
