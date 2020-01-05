import { Routes, RouterModule } from '@angular/router';
import { DashboardManagerComponent } from './dashboard-manager/dashboard-manager.component';
import { OneChecklistComponent } from './one-checklist/one-checklist.component';

const routes: Routes = [
  {
    path: ':id',
    component: OneChecklistComponent
  },
  {
    path: '',
    component: DashboardManagerComponent
  }
];

export const DashboardRoutes = RouterModule.forChild(routes);
