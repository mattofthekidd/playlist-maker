import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './views/home/home.component';
import { LoginModalComponent } from './modals/login/login-modal.component';

const routes: Routes = [
  {path: 'login', component: LoginModalComponent}, //TODO: setup a canActivate guard for this
  {path: 'home', component: HomeComponent},
  {path: '**', redirectTo: 'home'}, //TODO: route to a 404 page
  {path: '', redirectTo: 'home', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)], 
  exports: [RouterModule,]
})
export class AppRoutingModule { }
