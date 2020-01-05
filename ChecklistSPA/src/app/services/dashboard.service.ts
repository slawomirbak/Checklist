import { Injectable } from '@angular/core';
import { AbstractRepositoryService } from './_abstract-repository.service';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';
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
      console.log(data)
      this.userChecklist$.next(data)
    })
  );
}
