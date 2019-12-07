import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators'
import { environment } from 'src/environments/environment';

export interface IBackendPlainResponse {
  error: boolean;
  data: any;
}

export interface IBackendListReposnse<L>{
  error: boolean;
  data: L[];
}

@Injectable({
  providedIn: 'root'
})
export class AbstractRepositoryService<M, L> {
  baseEndpoint: string;

  constructor(protected http: HttpClient) { }

  getOne(id: number): Observable<M> {
    return this.http.get<IBackendPlainResponse>(`${environment.apiBasePath}${this.baseEndpoint}/${id}`)
      .pipe(
        map(res => res.data)
      );
  }

  getList(): Observable<IBackendListReposnse<L>> {
    return this.http.get<IBackendPlainResponse>(`${environment.apiBasePath}${this.baseEndpoint}`)
      .pipe(
        map(res => res.data)
      );
  }
}
