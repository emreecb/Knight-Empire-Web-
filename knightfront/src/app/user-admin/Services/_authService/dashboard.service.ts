import { Injectable } from '@angular/core';
import { Http, Response, Headers, CookieXSRFStrategy } from '@angular/http';

import { BaseService } from './base.service';

import { Observable, Subscriber } from 'rxjs';
import { ErrorHandleService } from '../../../_Services/_base_services/error-Handle.service';

// Add the RxJS Observable operators we need in this app.

@Injectable()
export class DashboardService extends BaseService {
  baseUrl = '';
  homeDetails: any = null;

  constructor(
    private http: Http,
    private errorHandleService: ErrorHandleService
  ) {
    super();
    this.baseUrl = 'http://localhost:54153/api';
    //this.baseUrl = 'http://knightapi.turgutyazici.com/api';
  }

  getHomeDetails(): Observable<any> {
    let headers = new Headers();
      headers.append('Content-Type', 'application/json');
      let authToken = localStorage.getItem('auth_token');
      headers.append('Authorization', `Bearer ${authToken}`);
    return this.http.get(this.baseUrl + "/user/home",{headers})
      .map(response => response.json())
      .catch(this.errorHandleService.HandleError);

  }

}
