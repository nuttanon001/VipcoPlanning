import { Injectable } from '@angular/core';
import { BaseRestService } from '../../shared/base-rest.service';
import { PlanMaster } from './plan-master.model';
import { HttpClient, HttpHeaders, HttpParams, HttpHandler } from '@angular/common/http';
import { HttpErrorHandler } from '../../shared/http-error-handler.service';
import { catchError } from 'rxjs/operators';
import { Observable } from 'rxjs/Observable';
import { SummanyReport } from './summany-report';
import { SummanyPlanActual } from './summany-plan-actual';
@Injectable()
export class PlanService extends BaseRestService<PlanMaster> {
  constructor(
    http: HttpClient,
    httpErrorHandler: HttpErrorHandler
  ) {
    super(
      http,
      "api/PlanMaster/",
      "PlanMasterService",
      "PlanMasterId",
      httpErrorHandler
    );
  }

  ////////////////////////
  // Summany PlanMaster //
  ///////////////////////
  summanyPlanMaster(summanyReport: SummanyReport): Observable<any> {
    return this.http.post<any>(this.baseUrl + "SummanyReportByJobNumber/", JSON.stringify(summanyReport),
      {
        headers: new HttpHeaders({
          "Content-Type": "application/json",
        })
      }).pipe(catchError(this.handleError(this.serviceName + "/post summany report", summanyReport)));
  }

  ///////////////////////////
  // Calculator PlanMaster //
  ///////////////////////////
  calculatorPlanMaster(planMaster: PlanMaster): Observable<any> {
    return this.http.post<any>(this.baseUrl + "CalcManHour/", JSON.stringify(planMaster),
      {
        headers: new HttpHeaders({
          "Content-Type": "application/json",
        })
      }).pipe(catchError(this.handleError(this.serviceName + "/post calc", planMaster)));
  }
  // ===================== Over Ride ===============================\\
  /** add Model @param nObject */
  addModel(nObject: PlanMaster): Observable<PlanMaster> {
    return this.http.post<PlanMaster>(this.baseUrl + "CreateV2/", JSON.stringify(nObject),
      {
        headers: new HttpHeaders({
          "Content-Type": "application/json",
        })
      }).pipe(catchError(this.handleError(this.serviceName + "/post model", nObject)));
  }

  /** update with key number */
  updateModelWithKey(uObject: PlanMaster): Observable<PlanMaster> {
    //debug here
    // console.log("UpdateV2");
    return this.http.put<PlanMaster>(this.baseUrl + "UpdateV2/", JSON.stringify(uObject), {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
      }),
      params: new HttpParams().set("key", uObject[this.keyName].toString())
    }).pipe(catchError(this.handleError(this.serviceName + "/put update model", uObject)));
  }
}
