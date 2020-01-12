import { Routes, RouterModule } from '@angular/router';
import { CredentialsManagerComponent } from './credentials-manager/credentials-manager.component';

const routes: Routes = [
  {
    path: 'login',
    component: CredentialsManagerComponent
  },
  {
    path: '',
    component: CredentialsManagerComponent
  }
];

export const UserRoutes = RouterModule.forChild(routes);
