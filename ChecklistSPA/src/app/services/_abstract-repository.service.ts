import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { of } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

export interface IBackendPlainResponse {
  error: boolean;
  data: any;
}

@Injectable({
  providedIn: 'root'
})
export class AbstractRepositoryService<M> {
  baseEndpoint: string;

  public static serializeFilters(filters: {}): string {
    const query = [];

    for (const p in filters) {
      if (filters.hasOwnProperty(p) && filters[p]) {
        query.push(
          encodeURIComponent(p) + '=' + encodeURIComponent(filters[p])
        );
      }
    }
    return query.join('&').length ? '?' + query.join('&') : '';
  }

  constructor(protected http: HttpClient) {}

  getOne(id: number) {
    return this.http
      .get<IBackendPlainResponse>(
        `${environment.apiBasePath}/${this.baseEndpoint}/${id}`
      )
      .pipe(
        map(res => res.data),
        catchError(err => {
          this.errorHandler(err);
          return of(false);
        })
      );
  }

  getList(filters = {}) {
    return this.http
      .get<IBackendPlainResponse>(
        `${environment.apiBasePath}/${this.baseEndpoint}` +
          AbstractRepositoryService.serializeFilters(filters)
      )
      .pipe(
        map(res => res.data),
        catchError(err => {
          this.errorHandler(err);
          return of(false);
        })
      );
  }

  post(path: string, data: any) {
    return this.http
      .post<IBackendPlainResponse>(`${environment.apiBasePath}/${this.baseEndpoint}/${path}`, data)
      .pipe(
        map(res => res.data),
        catchError(err => {
          this.errorHandler(err);
          return of(false);
        })
      );
  }

  private errorHandler(err: any) {
    // TODO: Impalment this handler
    throw new Error("Method not implemented.");
  }
}
