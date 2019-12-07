import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { UserRoutes } from './user.routing';
import { SharedModule } from 'src/app/shared/shared.module';



@NgModule({
  declarations: [RegisterComponent, LoginComponent],
  imports: [
    CommonModule,
    UserRoutes,
    SharedModule
  ]
})
export class UserModule { }
