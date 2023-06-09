import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { LoginModalModule } from './modals/login/login-modal.module';
import { HttpClientModule } from '@angular/common/http';
import { ViewsModule } from './_modules/views.module';


@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatButtonModule,
    MatDialogModule,
    LoginModalModule,
    HttpClientModule,
    ViewsModule
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
