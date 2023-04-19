import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeModule } from '../views/home/home.module';
import { CallbackModule } from '../views/callback/callback.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    HomeModule,
    CallbackModule
  ],
  exports: [
    HomeModule,
    CallbackModule,
  ]
})
export class ViewsModule { }
