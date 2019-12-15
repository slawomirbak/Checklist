import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material';
import { AllertMessageComponent } from './../../../shared/UI/allert-message/allert-message.component';


@Component({
  selector: 'app-credentials-manager',
  templateUrl: './credentials-manager.component.html',
  styleUrls: ['./credentials-manager.component.sass']
})
export class CredentialsManagerComponent implements OnInit {

  selectedIndex: number;
  constructor(private snackBar: MatSnackBar) {}

  ngOnInit() {
  }

  registerError(message: string) {
    this.snackBar.openFromComponent(AllertMessageComponent,{
      data: message,
      duration: 5 * 1000,
    });
  }
  registerOk() {
    this.snackBar.openFromComponent(AllertMessageComponent, {
      data: 'Account was created successfully. Please log in.',
      duration: 5 * 1000,
    });
    this.selectedIndex = 0;
  }
}
