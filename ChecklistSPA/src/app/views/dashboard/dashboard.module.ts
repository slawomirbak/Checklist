import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardManagerComponent } from './dashboard-manager/dashboard-manager.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { DashboardRoutes } from './dashboard.routing';



@NgModule({
  declarations: [DashboardManagerComponent],
  imports: [
    CommonModule,
    DashboardRoutes,
    SharedModule
  ]
})
export class DashboardModule { }
