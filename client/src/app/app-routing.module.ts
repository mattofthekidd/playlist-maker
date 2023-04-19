import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './views/home/home.component';
import { CallbackComponent } from './views/callback/callback.component';

const routes: Routes = [
  {path: 'home', component: HomeComponent},
  {path: 'callback', component: CallbackComponent},
  {path: '**', redirectTo: 'home', pathMatch: 'full'}, //TODO: route to a 404 page
];

@NgModule({
  imports: [RouterModule.forRoot(routes)], 
  exports: [RouterModule,]
})
export class AppRoutingModule { }
