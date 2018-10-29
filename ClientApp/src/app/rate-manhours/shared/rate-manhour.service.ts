import { Injectable } from '@angular/core';
import { BaseRestService } from '../../shared/base-rest.service';
import { RateManhour } from './rate-manhour.model';
import { HttpClient } from '@angular/common/http';
import { HttpErrorHandler } from '../../shared/http-error-handler.service';

@Injectable()
export class RateManhourService extends BaseRestService<RateManhour> {
  constructor(
    http: HttpClient,
    httpErrorHandler: HttpErrorHandler
  ) {
    super(
      http,
      "api/RateManHour/",
      "RateManHourService",
      "RateManHourId",
      httpErrorHandler
    );
  }
}
