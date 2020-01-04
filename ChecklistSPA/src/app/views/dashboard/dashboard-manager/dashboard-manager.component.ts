import { Component, OnInit } from '@angular/core';
import { SnackBarInfo } from 'src/app/services/snackbar-info.service';

@Component({
  selector: 'app-dashboard-manager',
  templateUrl: './dashboard-manager.component.html',
  styleUrls: ['./dashboard-manager.component.sass']
})
export class DashboardManagerComponent implements OnInit {

  createsList = false;

  constructor(private snackbarInfo: SnackBarInfo) { }

  ngOnInit() {
  }
  createNewList() {
    this.createsList = true;
  }
  showList() {
    this.createsList = false;
  }

  checklistError(message) {
    this.snackbarInfo.formError(message);
  }

  checklistOk(message) {
    this.snackbarInfo.formOk(message);
  }
}
