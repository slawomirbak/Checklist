import { Injectable } from '@angular/core';
import { AbstractRepositoryService } from './_abstract-repository.service';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService extends AbstractRepositoryService<any> {

  baseEndpoint = 'user';

  constructor(http: HttpClient) {
    super(http);
  }
}
