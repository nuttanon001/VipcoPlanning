import { Injectable } from '@angular/core';
import { BaseRestService } from '../../shared/base-rest.service';
import { PlanShipment } from './plan-shipment.model';
import { HttpErrorHandler } from '../../shared/http-error-handler.service';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class PlanShipmentService extends BaseRestService<PlanShipment> {

  constructor(
    http: HttpClient,
    httpErrorHandler: HttpErrorHandler
  ) {
    super(
      http,
      "api/PlanShipment/",
      "PlanShipmentService",
      "PlanShipmentId",
      httpErrorHandler
    );
  }
}
