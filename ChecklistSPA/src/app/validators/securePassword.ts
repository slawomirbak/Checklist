import { FormControl, FormGroupDirective, NgForm } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material';

export const securePassword = (control: FormControl): {[key: string]: boolean}| null => {
    const secureRegExp = new RegExp('^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])');
    const password = control.value;
    return !secureRegExp.test(password) ? {secure: true} : null;
};

export class SecurePasswordErrorMatcher implements ErrorStateMatcher {
    isErrorState(control: FormControl, form: FormGroupDirective | NgForm ): boolean {
        return control.hasError('secure') && control.dirty && form.submitted;
    }
}
