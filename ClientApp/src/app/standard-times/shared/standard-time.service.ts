import { Injectable } from '@angular/core';
import { BaseRestService } from '../../shared/base-rest.service';
import { StandardTime } from './standard-time.model';
import { HttpClient, HttpParams } from '@angular/common/http';
import { HttpErrorHandler } from '../../shared/http-error-handler.service';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class StandardTimeService extends BaseRestService<StandardTime> {
  constructor(
    http: HttpClient,
    httpErrorHandler: HttpErrorHandler
  ) {
    super(
      http,
      "api/StandardTime/",
      "StandardTimeService",
      "StandardTimeId",
      httpErrorHandler
    );
  }

  /** get one with key number */
  getRateMaster(modifiedBy?: string): Observable<any> {
    // Add safe, URL encoded search parameter if there is a search term
    const options = modifiedBy ? { params: new HttpParams().set("ModifiedBy", modifiedBy) } : {};
    return this.http.get<any>(this.baseUrl + "GetRateMaster/", options)
      .pipe(catchError(this.handleError(this.serviceName + "/get rate master", {})));
  }
}
