import { Injectable } from '@angular/core';
import { BaseRestService } from '../../shared/base-rest.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { HttpErrorHandler } from '../../shared/http-error-handler.service';
import { ActualDaily } from './actual-daily.model';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ChartOption } from './chart-option.model';
import { ChartResult } from './chart-result.model';

@Injectable()
export class ActualDailyService extends BaseRestService<ActualDaily> {
  constructor(
    http: HttpClient,
    httpErrorHandler: HttpErrorHandler
  ) {
    super(
      http,
      "api/ActualDaily/",
      "ActualDailyService",
      "ActualDailyId",
      httpErrorHandler
    )
  }

  /** CreateAndUpdate */
  arrayCreateAndUpdate(records?: Array<ActualDaily>): Observable<any> {
    return this.http.post<any>(this.baseUrl + "CreateAndUpdate/", JSON.stringify(records), {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
      })}).pipe(catchError(this.handleError(this.serviceName + "/create or update array model", {})));
  }

  /** TableActualDaily */
  getTableActualDaily(nObject: ChartOption): Observable<ChartResult> {
    return this.http.post<ChartResult>(this.baseUrl + "TableActualDaily/", JSON.stringify(nObject),
      { headers: new HttpHeaders({
          "Content-Type": "application/json",
        })
      }).pipe(catchError(this.handleError(this.serviceName + "/chart result has error", <ChartResult>{})));
  }
}
