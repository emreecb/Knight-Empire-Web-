import { Changepassword } from './../../models/Changepassword';
import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable, Subscriber } from 'rxjs';

import { BaseService } from './base.service';

import { HttpClient } from '@angular/common/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/finally';
import { Router } from '@angular/router';
import { ErrorHandleService } from '../../../_Services/_base_services/error-Handle.service';
import { User } from '../../models/User';
import { DashboardService } from './dashboard.service';
import { navItems } from '../../adminlayout/_nav';

@Injectable()
export class UserService extends BaseService {
  private baseUrl = '';
  private loggedIn = false;
  private bayi = false;
  navItems_ = navItems;

  constructor(
    private http: Http,
    private _http: HttpClient,
    private router: Router,
    private errorHandleService: ErrorHandleService,
    private dashService: DashboardService
  ) {
    super();
    this.loggedIn = !!localStorage.getItem('auth_token');
    //this.baseUrl = 'http://knightapi.turgutyazici.com/api';
    this.baseUrl = 'http://localhost:54153/api';

  }

  register(obj): Observable<any> {
    const headers = new Headers({ 'Content-Type': 'application/json' });
    const options = new RequestOptions({ headers: headers });

    return this.http
      .post(this.baseUrl + '/accounts', obj, options)
      .map(res => true)
      .catch(this.handleError);
  }

  login(userName, password) {
    localStorage.setItem('role', '1');
    const headers = new Headers();
    headers.append('Content-Type', 'application/json');
    return this.http
      .post(
        this.baseUrl + '/auth/login',
        JSON.stringify({ userName, password }),
        { headers }
      )
      .map(res => res.json())
      .map(res => {
        localStorage.setItem('auth_token', res.auth_token);
        this.loggedIn = true;
        this.getHomeDetails();
        return true;
      })
      .catch(this.handleError);
  }

  getHomeDetails() {
    localStorage.setItem('bayi', 'false');
    const headers = new Headers();
    headers.append('Content-Type', 'application/json');
    const authToken = localStorage.getItem('auth_token');
    headers.append('Authorization', `Bearer ${authToken}`);
    this.http
      .get(this.baseUrl + '/user/home', { headers }).subscribe((resp: any) => {
        const user = resp.json();
        this.dashService.homeDetails=user;
        if(user.identity.emailConfirmed==false){
          this.logout();
          alert("Mailinizi Aktifleştirin")
        }
      });

  }

  changepassword(obj: Changepassword) {
    return this.http.post(this.baseUrl + '/Auth/ChangePassword', obj);
  }
  update(obj: User) {
    return this.http.post(this.baseUrl + '/Auth/userupdate', obj);
  }

  forgetpass(obj) {
    return this.http
      .post(this.baseUrl + '/Auth/ForgotPassword', obj)
      .catch(this.errorHandleService.HandleError);
  }

  confirm(url) {
    return this.http.get(url);
  }
  resetpass(obj) {
    return this.http
      .post(this.baseUrl + '/Auth/resetpasword', obj)
      .catch(this.errorHandleService.HandleError);
  }

  logout() {
    localStorage.removeItem('auth_token');
    localStorage.removeItem('user');
    localStorage.removeItem('role');
    localStorage.removeItem('bayi');
    localStorage.clear();
    this.loggedIn = false;
    this.bayi = false;
    this.dashService.homeDetails = null;
    this.router.navigate(['']);
  }

  isLoggedIn() {
    return this.loggedIn;
  }

  facebookLogin(accessToken: string) {
    const headers = new Headers();
    headers.append('Content-Type', 'application/json');
    const body = JSON.stringify({ accessToken });
    return this.http
      .post(this.baseUrl + '/externalauth/facebook', body, { headers })
      .map(res => res.json())
      .map(res => {
        localStorage.setItem('auth_token', res.auth_token);
        this.loggedIn = true;
        return true;
      })
      .catch(this.handleError);
  }
}
