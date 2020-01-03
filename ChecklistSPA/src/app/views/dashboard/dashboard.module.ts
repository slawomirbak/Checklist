import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardManagerComponent } from './dashboard-manager/dashboard-manager.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { DashboardRoutes } from './dashboard.routing';
import { ChecklistFormComponent } from './checklist-form/checklist-form.component';



@NgModule({
  declarations: [DashboardManagerComponent, ChecklistFormComponent],
  imports: [
    CommonModule,
    DashboardRoutes,
    SharedModule
  ]
})
export class DashboardModule { }
