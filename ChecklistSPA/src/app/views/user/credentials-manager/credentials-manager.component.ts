import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material';
import { AllertMessageComponent } from './../../../shared/UI/allert-message/allert-message.component';
import { SnackBarInfo } from 'src/app/services/snackbar-info.service';


@Component({
  selector: 'app-credentials-manager',
  templateUrl: './credentials-manager.component.html',
  styleUrls: ['./credentials-manager.component.sass']
})
export class CredentialsManagerComponent implements OnInit {

  selectedIndex: number;
  constructor(private snackBarInfo: SnackBarInfo) {}

  ngOnInit() {
  }

  formError(errorMessage: string) {
    this.snackBarInfo.formError(errorMessage);
  }
  formOk(infoMessage: string) {
    this.snackBarInfo.formOk(infoMessage);
  }
}
