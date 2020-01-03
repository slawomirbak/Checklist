import { Injectable } from '@angular/core';
import { AbstractRepositoryService } from './_abstract-repository.service';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DashboardService extends AbstractRepositoryService<any> {
  baseEndpoint = 'api/dashboard';

  constructor(http: HttpClient) {
    super(http);
  }
}
