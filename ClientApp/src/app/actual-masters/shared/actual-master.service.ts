import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActualMaster } from './actual-master.model';
import { BaseRestService } from '../../shared/base-rest.service';
import { HttpErrorHandler } from '../../shared/http-error-handler.service';
import { ChartOption } from './chart-option.model';
import { Observable } from 'rxjs';
import { ChartResult } from './chart-result.model';
import { catchError } from 'rxjs/operators';

@Injectable()
export class ActualMasterService extends BaseRestService<ActualMaster> {
  constructor(
    http: HttpClient,
    httpErrorHandler: HttpErrorHandler
  ) {
    super(
      http,
      "api/ActualMaster/",
      "ActualMasterService",
      "ActualMasterId",
      httpErrorHandler
    )
  }

  /** add Model @param nObject */
  getChartResult(nObject: ChartOption, subString: string = "ChartManHour/"): Observable<ChartResult> {
    // debug here
    // console.log("Path:", this.baseUrl);
    // console.log("Data is:", JSON.stringify(nObject));

    return this.http.post<ChartResult>(this.baseUrl + subString, JSON.stringify(nObject),
      {
        headers: new HttpHeaders({
          "Content-Type": "application/json",
        })
      }).pipe(catchError(this.handleError(this.serviceName + "/chart result has error", <ChartResult>{})));
  }
}
