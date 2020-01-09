import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardManagerComponent } from './dashboard-manager/dashboard-manager.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { DashboardRoutes } from './dashboard.routing';
import { ChecklistFormComponent } from './checklist-form/checklist-form.component';
import { OneChecklistComponent } from './one-checklist/one-checklist.component';
import { UploadDialogComponent } from 'src/app/shared/UI/upload-dialog/upload-dialog.component';



@NgModule({
  declarations: [DashboardManagerComponent, ChecklistFormComponent, OneChecklistComponent],
  imports: [
    CommonModule,
    DashboardRoutes,
    SharedModule
  ],
  entryComponents: [UploadDialogComponent]
})
export class DashboardModule { }
