import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingPageComponent } from './views/landing-page/landing-page.component';
import { LoginModalComponent } from './modals/login/login-modal.component';

const routes: Routes = [
  {path: 'login', component: LoginModalComponent}, //TODO: setup a canActivate guard for this
  {path: 'landingPage', component: LandingPageComponent},
  {path: '**', redirectTo: 'landingPage'}, //TODO: route to a 404 page
  {path: '', redirectTo: 'landingPage', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)], 
  exports: [RouterModule,]
})
export class AppRoutingModule { }
