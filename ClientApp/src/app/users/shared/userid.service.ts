import { Injectable } from '@angular/core';
import { BaseRestService } from '../../shared/base-rest.service';
import { User } from './user.model';
import { HttpClient } from '@angular/common/http';
import { HttpErrorHandler } from '../../shared/http-error-handler.service';

@Injectable()
export class UseridService extends BaseRestService<User> {
  constructor(
    http: HttpClient,
    httpErrorHandler: HttpErrorHandler
  ) {
    super(
      http,
      "api/User/",
      "UserService",
      "User",
      httpErrorHandler
    )
  }
}
