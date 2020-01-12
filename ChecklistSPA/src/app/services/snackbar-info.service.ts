import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material';
import { AllertMessageComponent } from '../shared/UI/allert-message/allert-message.component';

@Injectable({
    providedIn: 'root'
})
export class SnackBarInfo {
    constructor(private snackBar: MatSnackBar) {}

    formError(errorMessage: string) {
        this.snackBar.openFromComponent(AllertMessageComponent, {
            data: { message: errorMessage, error: true},
            duration: 5 * 1000,
        });
    }
    formOk(infoMessage: string) {
        this.snackBar.openFromComponent(AllertMessageComponent, {
            data: { message: infoMessage, error: false},
            duration: 5 * 1000,
        });
    }
}
