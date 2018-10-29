import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActualDetail } from './actual-detail.model';
import { BaseRestService } from '../../shared/base-rest.service';
import { HttpErrorHandler } from '../../shared/http-error-handler.service';

@Injectable()
export class ActualDetailService extends BaseRestService<ActualDetail> {
  constructor(
    http: HttpClient,
    httpErrorHandler: HttpErrorHandler
  ) {
    super(
      http,
      "api/ActualDetail/",
      "ActualDetailService",
      "ActualDetailId",
      httpErrorHandler
    )
  }
}
