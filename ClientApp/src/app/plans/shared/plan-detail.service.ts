import { Injectable } from '@angular/core';
import { BaseRestService } from '../../shared/base-rest.service';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { HttpErrorHandler } from '../../shared/http-error-handler.service';
import { catchError } from 'rxjs/operators';
import { Observable } from 'rxjs/Observable';
import { PlanDetail } from './plan-detail.model';

@Injectable()
export class PlanDetailService extends BaseRestService<PlanDetail> {

  constructor(
    http: HttpClient,
    httpErrorHandler: HttpErrorHandler
  ) {
    super(
      http,
      "api/PlanDetail/",
      "PlanDetailService",
      "PlanDetailId",
      httpErrorHandler
    );
  }
}
