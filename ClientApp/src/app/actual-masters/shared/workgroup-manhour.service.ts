import { Injectable } from '@angular/core';
import { BaseRestService } from '../../shared/base-rest.service';
import { WorkgroupManhour } from './workgroup-manhour.model';
import { HttpClient, HttpParams } from '@angular/common/http';
import { HttpErrorHandler } from '../../shared/http-error-handler.service';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ActualDetail } from './actual-detail.model';
import { ActualBom } from './actual-bom.model';

@Injectable()
export class WorkgroupManhourService extends BaseRestService<WorkgroupManhour> {
  constructor(
    http: HttpClient,
    httpErrorHandler: HttpErrorHandler
  ) {
    super(
      http,
      "api/WorkGroupTotalManHour/",
      "WorkGroupTotalManHourService",
      "WorkGroupTotalManHourId",
      httpErrorHandler
    )
  }

  /** GetWorkGroupTotalMH */
  getWorkGroupTotalManHour(PlanMasterId?:number): Observable<Array<ActualDetail> | any> {
    // Add safe, URL encoded search parameter if there is a search term
    const options = { params: new HttpParams().set("PlanMasterId", PlanMasterId.toString()) };
    return this.http.get<ActualDetail>(this.baseUrl + "GetWorkGroupTotalMH/", options)
      .pipe(catchError(this.handleError(this.serviceName + "/get one model", new Array<ActualDetail>() )));
  }

  /** GetBomTotalMH */
  getBomTotalManHour(PlanMasterId?: number): Observable<Array<ActualBom> | any> {
    // Add safe, URL encoded search parameter if there is a search term
    const options = { params: new HttpParams().set("PlanMasterId", PlanMasterId.toString()) };
    return this.http.get<ActualDetail>(this.baseUrl + "GetBomTotalMH/", options)
      .pipe(catchError(this.handleError(this.serviceName + "/get one model", new Array<ActualBom>())));
  }
}
