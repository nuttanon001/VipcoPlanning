import { Injectable } from '@angular/core';
import { BaseRestService } from '../../shared/base-rest.service';
import { BillMaterial } from './bill-material.model';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { HttpErrorHandler } from '../../shared/http-error-handler.service';
import { catchError } from 'rxjs/operators';
import { Observable } from "rxjs/Observable";

@Injectable()
export class BillMaterialService extends BaseRestService<BillMaterial> {
  constructor(
    http: HttpClient,
    httpErrorHandler: HttpErrorHandler,
  ) {
    super(
      http,
      "api/BillofMaterial/",
      "BillMaterialService",
      "BillofMaterialId",
      httpErrorHandler
    );
  }
  // Get from sagex3
  //http://192.168.2.31/extends-sagex3/api/BomLevel/

  getAllFromSageX3(): Observable<Array<any>> {
    return this.http.get<Array<BillMaterial>>("http://192.168.2.31/extends-sagex3/api/BomLevel/")
      .pipe(catchError(this.handleError(this.serviceName + "/get all model from sagex3.", new Array<any>())));
  }

  // Insert from sagex3
  insertFromSageX3(nObject: Array<BillMaterial>): Observable<any> {
    return this.http.post<BillMaterial>(this.baseUrl + "GetBomFromSageX3/", JSON.stringify(nObject),
      {
        headers: new HttpHeaders({
          "Content-Type": "application/json",
        })
      }).pipe(catchError(this.handleError(this.serviceName + "/port insert bom from sagex3", {})));
  }

  // ===================== Over Ride ===============================\\
  /** add Model @param nObject */
  addModel(nObject: BillMaterial): Observable<BillMaterial> {
    return this.http.post<BillMaterial>(this.baseUrl + "CreateV2/", JSON.stringify(nObject),
      {
        headers: new HttpHeaders({
          "Content-Type": "application/json",
        })
      }).pipe(catchError(this.handleError(this.serviceName + "/post model", nObject)));
  }

  /** update with key number */
  updateModelWithKey(uObject: BillMaterial): Observable<BillMaterial> {
    //debug here
    console.log("UpdateV2");
    return this.http.put<BillMaterial>(this.baseUrl + "UpdateV2/", JSON.stringify(uObject), {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
      }),
      params: new HttpParams().set("key", uObject[this.keyName].toString())
    }).pipe(catchError(this.handleError(this.serviceName + "/put update model", uObject)));
  }
}
