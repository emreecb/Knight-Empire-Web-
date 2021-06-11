import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';


import { BaseService } from './base.service';


// Add the RxJS Observable operators we need in this app.
import { Observable } from 'rxjs';
import { BehaviorSubject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/finally';
import { Router } from '@angular/router';
import { ErrorHandleService } from '../_base_services/error-Handle.service';

@Injectable()

export class UserService extends BaseService {
  baseUrl = '';
  private loggedIn = false;

  constructor(private http: Http, private _http: HttpClient, private router: Router, private errorHandleService: ErrorHandleService) {
    super();
    this.loggedIn = !!localStorage.getItem('auth_token');
    //this.baseUrl = 'http://knightapi.turgutyazici.com/api';
    this.baseUrl = 'http://localhost:54153/api';
  }

  register(email: string, password: string, rolesId: string, ): Observable<any> {
    const body = JSON.stringify({ email, password, rolesId });
    const headers = new Headers({ 'Content-Type': 'application/json' });
    const options = new RequestOptions({ headers: headers });

    return this.http.post(this.baseUrl + '/accounts', body, options)
      .map(res => true)
      .catch(this.handleError);
  }

  login(userName, password) {
    const headers = new Headers();
    headers.append('Content-Type', 'application/json');
    return this.http
      .post(
        this.baseUrl + '/auth/login',
        JSON.stringify({ userName, password }), { headers }
      )
      .map(res => res.json())
      .map(res => {
        localStorage.setItem('auth_token', res.auth_token);
        this.loggedIn = true;
        return true;
      })
      .catch(this.handleError);
  }

  confirm(url) {
    return this.http.get(url);
  }
  resetpass(obj) {
    return this.http.post(this.baseUrl + '/Auth/resetpasword', obj)
    .catch(this.errorHandleService.HandleError);
  }

  logout() {
    localStorage.removeItem('auth_token');
    this.loggedIn = false;
    this.router.navigate(['/login']);
    // this._authNavStatusSource.next(false);
  }

  isLoggedIn() {
    return this.loggedIn;
  }

  facebookLogin(accessToken: string) {
    const headers = new Headers();
    headers.append('Content-Type', 'application/json');
    const body = JSON.stringify({ accessToken });
    return this.http
      .post(
        this.baseUrl + '/externalauth/facebook', body, { headers })
      .map(res => res.json())
      .map(res => {
        localStorage.setItem('auth_token', res.auth_token);
        this.loggedIn = true;
        // this._authNavStatusSource.next(true);
        return true;
      })
      .catch(this.handleError);
  }
}

