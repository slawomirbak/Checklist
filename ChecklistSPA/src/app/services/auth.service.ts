import { Injectable } from '@angular/core';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  refreshToken() {
     return of([]);
  }
  getJwtToken() {
      return '';
  }
  isLoggedIn(): boolean {
    return false;
  }

  constructor() { }
}
