import { Component, OnInit } from '@angular/core';
import { SnackBarInfo } from 'src/app/services/snackbar-info.service';
import { DashboardService } from 'src/app/services/dashboard.service';

@Component({
  selector: 'app-dashboard-manager',
  templateUrl: './dashboard-manager.component.html',
  styleUrls: ['./dashboard-manager.component.sass']
})
export class DashboardManagerComponent implements OnInit {

  createsList = false;

  userChecklist$ = this.dashboardService.userChecklist$;

  constructor(private snackbarInfo: SnackBarInfo, private dashboardService: DashboardService) { }

  ngOnInit() {
    this.dashboardService.currentUserChecklist$.subscribe();
  }

  createNewList() {
    this.createsList = true;
  }
  showList() {
    this.createsList = false;
    this.dashboardService.currentUserChecklist$.subscribe();
  }

  checklistError(message) {
    this.snackbarInfo.formError(message);
  }

  checklistOk(message) {
    this.snackbarInfo.formOk(message);
  }
  deleteUserChecklist(checklistId: number) {
    this.dashboardService.delete(checklistId.toString()).subscribe(
      ok => {
        this.checklistOk('List was deleted');
        this.dashboardService.currentUserChecklist$.subscribe();
      },
      error => this.checklistError('Something went wrong. Try again')
    );
  }
}
