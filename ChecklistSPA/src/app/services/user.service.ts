import { Injectable } from '@angular/core';
import { AbstractRepositoryService } from './_abstract-repository.service';
import { HttpClient } from '@angular/common/http';
import { of, Observable, BehaviorSubject } from 'rxjs';
import { LoginCredentials } from '../interfaces/LoginCredentials';
import { tap, mapTo, map } from 'rxjs/operators';
import { ITokens } from '../models/ITokens';

@Injectable({
  providedIn: 'root'
})
export class UserService extends AbstractRepositoryService<any> {
  baseEndpoint = 'api/user';

  constructor(http: HttpClient) {
    super(http);
  }

  private readonly JWT_TOKEN = 'JWT_TOKEN';
  private readonly REFRESH_TOKEN = 'REFRESH_TOKEN';
  private loggedUser$ = new BehaviorSubject(this.getRefreshToken());

  isLoggedIn$ = this.loggedUser$.pipe(
    map(userName => !!userName)
  );

  login(credentials: LoginCredentials): Observable<boolean> {
    return this.post('login', credentials).pipe(
      tap(tokens => this.doLoginUser(credentials.email, tokens)),
      mapTo(true)
    );
  }

  logout() {
    return this.post('logout', { refreshToken: this.getRefreshToken() }).pipe(
      tap(() => this.doLogoutUser()),
      mapTo(true)
    );
  }

  refreshToken() {
    return this.post('refresh', { refreshToken: this.getRefreshToken() }).pipe(
      tap((tokens: ITokens) => this.storeJwtToken(tokens.jwt))
    );
  }

  getJwtToken() {
    return localStorage.getItem(this.JWT_TOKEN);
  }

  isLoggedIn(): boolean {
    return !!this.loggedUser$.value;
  }

  private doLoginUser(username: string, tokens: ITokens) {
    this.loggedUser$.next(username);
    this.storeTokens(tokens);
  }

  private doLogoutUser() {
    this.loggedUser$.next(null);
    this.removeTokens();
  }

  private storeTokens(tokens: ITokens) {
    localStorage.setItem(this.JWT_TOKEN, tokens.jwt);
    localStorage.setItem(this.REFRESH_TOKEN, tokens.refreshToken);
  }

  private removeTokens() {
    localStorage.removeItem(this.JWT_TOKEN);
    localStorage.removeItem(this.REFRESH_TOKEN);
  }

  private storeJwtToken(jwt: string) {
    localStorage.setItem(this.JWT_TOKEN, jwt);
  }

  private getRefreshToken() {
    return localStorage.getItem(this.REFRESH_TOKEN);
  }
}
