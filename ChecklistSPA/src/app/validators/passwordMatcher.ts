import { FormGroup, FormControl, FormGroupDirective, NgForm } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material';

export const passwordMatcher = (formGroup: FormGroup): {[key: string]: boolean}| null => {
    const password = formGroup.get('password').value;
    const verifyPasswrod = formGroup.get('verifyPassword').value;
    return password !== verifyPasswrod ? {verifyPassword: true} : null;
};

export class PasswordVerifyErrorMatcher implements ErrorStateMatcher {
    isErrorState(control: FormControl, form: FormGroupDirective | NgForm ): boolean {
        return form.hasError('verifyPassword') && control.dirty && form.submitted;
    }
}
