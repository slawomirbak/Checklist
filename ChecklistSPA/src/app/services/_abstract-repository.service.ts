import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { of, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

export interface IBackendPlainResponse {
  isSuccessful: boolean;
  errorMessage: string;
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
        map((res: IBackendPlainResponse) => {
          if (!res.isSuccessful) {
            throw new Error(res.errorMessage);
          }
          if (res.data) {
            return res.data;
          }
        }),
        catchError(this.errorHandler)
      );
  }

  getList(filters = {}) {
    return this.http
      .get<IBackendPlainResponse>(
        `${environment.apiBasePath}/${this.baseEndpoint}` +
          AbstractRepositoryService.serializeFilters(filters)
      )
      .pipe(
        map((res: IBackendPlainResponse) => {
          if (!res.isSuccessful) {
            throw new Error(res.errorMessage);
          }
          if (res.data) {
            return res.data;
          }
        }),
        catchError(this.errorHandler)
      );
  }

  post(path: string, data: any) {
    return this.http
      .post<IBackendPlainResponse>(`${environment.apiBasePath}/${this.baseEndpoint}/${path}`, data)
      .pipe(
        map((res: IBackendPlainResponse) => {
          if (!res.isSuccessful) {
            throw new Error(res.errorMessage);
          }
          if (res.data) {
            return res.data;
          }
        }),
        catchError(this.errorHandler)
      );
  }

  private errorHandler(error: any) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = `Error: ${error.error.message}`;
    } else if (typeof error.error === 'string' ) {
      errorMessage = error.error;
    } else {
      errorMessage = error.statusText;
    }
    return throwError(errorMessage);
  }
}
