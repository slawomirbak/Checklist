import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { RegisterCredentials } from 'src/app/interfaces/RegisterCredentials';
import { passwordMatcher, PasswordVerifyErrorMatcher } from 'src/app/validators/passwordMatcher';
import { securePassword } from 'src/app/validators/securePassword';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.sass']
})
export class RegisterComponent implements OnInit {
  @Output() registerError: EventEmitter<string> = new EventEmitter<string>();
  @Output() registerOk: EventEmitter<boolean> = new EventEmitter<boolean>();

  constructor(private fb: FormBuilder, private userService: UserService) { }
  registerForm: FormGroup;
  verifyPasswordMatcher = new PasswordVerifyErrorMatcher();

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
      this.userService.post('register', registerForm).subscribe(
        ok => this.registerOk.emit(true),
        error => this.registerError.emit(error)
      );
    }
  }

  hasError(controlName: string, errorName: string): boolean {
    return this.registerForm.controls[controlName].hasError(errorName);
  }

  hasErrorCrossField(errorName: string): boolean {
    return this.registerForm.hasError(errorName);
  }
}
