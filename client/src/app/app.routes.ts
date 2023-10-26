import { Routes } from '@angular/router';
import { HomeComponent } from './views/home/home.component';
import { CallbackComponent } from './views/callback/callback.component';

export const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'callback', component: CallbackComponent },
  { path: '**', redirectTo: 'home', pathMatch: 'full' }, //TODO: route to a 404 page
];
