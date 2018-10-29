import { Injectable } from '@angular/core';
import { BaseRestService } from '../../shared/base-rest.service';
import { StandardTime } from './standard-time.model';
import { HttpClient } from '@angular/common/http';
import { HttpErrorHandler } from '../../shared/http-error-handler.service';

@Injectable()
export class StandardTimeService extends BaseRestService<StandardTime> {
  constructor(
    http: HttpClient,
    httpErrorHandler: HttpErrorHandler
  ) {
    super(
      http,
      "api/StandardTime/",
      "StandardTimeService",
      "StandardTimeId",
      httpErrorHandler
    );
  }
}
