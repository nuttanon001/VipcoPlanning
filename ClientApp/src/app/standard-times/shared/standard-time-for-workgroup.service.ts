import { Injectable } from '@angular/core';
import { BaseRestService } from '../../shared/base-rest.service';
import { HttpClient } from '@angular/common/http';
import { HttpErrorHandler } from '../../shared/http-error-handler.service';
import { StandardTimeForWorkgroup } from './standard-time-for-workgroup.model';

@Injectable()
export class StandardTimeForWorkgroupService extends BaseRestService<StandardTimeForWorkgroup> {
  constructor(
    http: HttpClient,
    httpErrorHandler: HttpErrorHandler
  ) {
    super(
      http,
      "api/StandardTimeForWorkGroup/",
      "StandardTimeForWorkGroupService",
      "StandardTimeForId",
      httpErrorHandler
    );
  }
}
