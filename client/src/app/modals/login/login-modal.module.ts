import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginModalComponent } from './login-modal.component';
import { MatButtonModule } from '@angular/material/button';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';




@NgModule({
  declarations: [
    LoginModalComponent
  ],
  imports: [
    CommonModule,
    MatButtonModule,
  ]
})
export class LoginModalModule { }
