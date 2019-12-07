import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { LoginCredentials } from 'src/app/interfaces/LoginCredentials';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass']
})
export class LoginComponent implements OnInit {

  constructor(private fb: FormBuilder) { }
  loginForm: FormGroup;

  ngOnInit() {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      passwoord: ['', Validators.required]
    });
  }

  login(loginForm: LoginCredentials) {
  // TODO Send form
  }

  hasError(controlName: string, errorName: string ): boolean {
    return this.loginForm.controls[controlName].hasError(errorName);
  }
}
