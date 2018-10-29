import { Injectable } from '@angular/core';
import { BaseRestService } from '../../shared/base-rest.service';
import { ActualBom } from './actual-bom.model';
import { HttpClient } from '@angular/common/http';
import { HttpErrorHandler } from '../../shared/http-error-handler.service';

@Injectable()
export class ActualBomService extends BaseRestService<ActualBom> {
  constructor(
    http: HttpClient,
    httpErrorHandler: HttpErrorHandler
  ) {
    super(
      http,
      "api/ActualBom/",
      "ActualBomService",
      "ActualBomId",
      httpErrorHandler
    )
  }
}
