import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { UserRoutes } from './user.routing';
import { SharedModule } from 'src/app/shared/shared.module';
import { CredentialsManagerComponent } from './credentials-manager/credentials-manager.component';



@NgModule({
  declarations: [RegisterComponent, LoginComponent, CredentialsManagerComponent],
  imports: [
    CommonModule,
    UserRoutes,
    SharedModule
  ]
})
export class UserModule { }
