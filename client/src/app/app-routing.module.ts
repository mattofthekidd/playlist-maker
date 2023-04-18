import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './views/home/home.component';

const routes: Routes = [
  {path: '', redirectTo: 'home', pathMatch: 'full'},
  {path: 'home', component: HomeComponent},
  {path: '**', redirectTo: 'home'}, //TODO: route to a 404 page
];

@NgModule({
  imports: [RouterModule.forRoot(routes)], 
  exports: [RouterModule,]
})
export class AppRoutingModule { }
