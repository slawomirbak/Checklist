import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpRequest, HttpEventType } from '@angular/common/http';
import { of, throwError, Observable, Subject } from 'rxjs';
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

  put(data: any, path: string = '') {
    return this.http
      .put<IBackendPlainResponse>(`${environment.apiBasePath}/${this.baseEndpoint}/${path}`, data)
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

  delete(path: string) {
    return this.http
      .delete<IBackendPlainResponse>(`${environment.apiBasePath}/${this.baseEndpoint}/${path}`)
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
  upload(files: Set<File>, path: string): { [key: string]: {progress: Observable<number>}} {
    const status: { [key: string]: { progress: Observable<number> } } = {};

    files.forEach(file => {
      const formData: FormData = new FormData();
      formData.append('file', file, file.name);

      const req = new HttpRequest('POST',  `${environment.apiBasePath}/${this.baseEndpoint}/upload/${path}`, formData, {
        reportProgress: true
      });
      const progress = new Subject<number>();

      this.http.request(req).subscribe(event => {
        if (event.type === HttpEventType.UploadProgress) {

          const percentDone = Math.round(100 * event.loaded / event.total);

          progress.next(percentDone);
        } else if (event instanceof HttpResponse) {
          progress.complete();
        }
      });

      status[file.name] = {
        progress: progress.asObservable()
      };
    });

    return status;
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
