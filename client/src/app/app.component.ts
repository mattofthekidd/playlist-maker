import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { LoginModalComponent } from './modals/login/login-modal.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  constructor(private dialog: MatDialog) {}

  ngOnInit(): void {

  }

  openLoginModal() {
    const loginDialogRef: MatDialogRef<LoginModalComponent> = this.dialog.open(LoginModalComponent, {
      height: '400px',
      width: '600px'
    });
    loginDialogRef.afterClosed();
  }

}
