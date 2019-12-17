import { Routes, RouterModule } from '@angular/router';
import { DashboardManagerComponent } from './dashboard-manager/dashboard-manager.component';

const routes: Routes = [
  {
    path: '',
    component: DashboardManagerComponent
  }
];

export const DashboardRoutes = RouterModule.forChild(routes);
