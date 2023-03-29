import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingPageComponent } from './pages/landing-page/landing-page.component';
import { LoginComponent } from './pages/login/login.component';

const routes: Routes = [
  // {path: 'login', component: LoginComponent},
  {path: 'landingPage', component: LandingPageComponent},
  {path: '**', redirectTo: 'landingPage'}, //eventually a 404 page
  {path: '', redirectTo: 'landingPage', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule,]
})
export class AppRoutingModule { }
