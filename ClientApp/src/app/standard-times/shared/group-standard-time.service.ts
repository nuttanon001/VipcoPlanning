import { Injectable } from '@angular/core';
import { BaseRestService } from '../../shared/base-rest.service';
import { GroupStandardTime } from './group-standard-time.model';
import { HttpClient } from '@angular/common/http';
import { HttpErrorHandler } from '../../shared/http-error-handler.service';

@Injectable()
export class GroupStandardTimeService extends BaseRestService<GroupStandardTime> {

  constructor(
    http: HttpClient,
    httpErrorHandler:HttpErrorHandler
  ) {
    super(
      http,
      "api/GroupStandardTime/",
      "GroupStandardTimeService",
      "GroupStandardId",
      httpErrorHandler);
  }

}
