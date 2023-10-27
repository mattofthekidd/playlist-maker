import { Routes } from '@angular/router';
import { CallbackComponent } from 'src/_modules/callback/callback.component';
import { HomeComponent } from 'src/_modules/home/home.component';

export const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    title: 'Home Page',
  },
  { path: 'callback', component: CallbackComponent },
  {
    path: '**',
    component: HomeComponent,
    title: 'Home Page',
  },
];
