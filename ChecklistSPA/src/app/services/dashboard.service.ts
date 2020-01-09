import { Injectable } from '@angular/core';
import { AbstractRepositoryService } from './_abstract-repository.service';
import { HttpClient, HttpRequest, HttpEventType, HttpResponse } from '@angular/common/http';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class DashboardService extends AbstractRepositoryService<any> {
  baseEndpoint = 'api/dashboard';

  userChecklist$ = new BehaviorSubject(null);

  constructor(http: HttpClient) {
    super(http);
  }

  currentUserChecklist$ = this.getList().pipe(
    tap(data => {
      this.userChecklist$.next(data);
    })
  );
}
