import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { RegisterCredentials } from 'src/app/interfaces/RegisterCredentials';
import { passwordMatcher, PasswordVerifyErrorMatcher } from 'src/app/validators/passwordMatcher';
import { SecurePasswordErrorMatcher, securePassword } from 'src/app/validators/securePassword';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.sass']
})
export class RegisterComponent implements OnInit {

  constructor(private fb: FormBuilder) { }
  registerForm: FormGroup;
  verifyPasswordMatcher = new PasswordVerifyErrorMatcher();
  securePasswordMatcher = new SecurePasswordErrorMatcher();

  ngOnInit() {
    this.registerForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6), securePassword]],
      verifyPassword:  ['', Validators.required],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      address: this.fb.group({
        country: ['', Validators.required],
        city: ['', Validators.required],
        streetAddress: ['', Validators.required],
        postCode: ['', Validators.required]
      })
    }, {validators: passwordMatcher});
  }

  registerUser(registerForm: RegisterCredentials) {
    if (this.registerForm.valid) {
    //TODO: send form 
    }
  }

  hasError(controlName: string, errorName: string): boolean {
    return this.registerForm.controls[controlName].hasError(errorName);
  }

  hasErrorCrossField(errorName: string): boolean {
    return this.registerForm.hasError(errorName);
  }
}
