import { ErrorHandleService } from './error-Handle.service';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class MainService {
  //private baseUrl = 'http://knightapi.turgutyazici.com/api';
  private baseUrl = 'http://localhost:54153/api';

  private username = 'yziTJGNsYA';
  private password = 'zHWiq6Ts7T';
  constructor(private http: HttpClient, private errorHandleService: ErrorHandleService) {
  }

  Get(url) {
    return this.http.get(this.baseUrl + url,
      { headers: { 'Authorization': 'Basic ' + btoa(this.username + ':' + this.password) } })
      .catch(this.errorHandleService.HandleError);
  }

  GetID(url, id) {
    return this.http.get(this.baseUrl + url + '/' + id,
      { headers: { 'Authorization': 'Basic ' + btoa(this.username + ':' + this.password) } })
      .catch(this.errorHandleService.HandleError);
  }

  Create(url, obj: any, res?: any) {
    return this.http.post(this.baseUrl + url, obj,
      { headers: { 'Authorization': 'Basic ' + btoa(this.username + ':' + this.password) } })
      .catch(this.errorHandleService.HandleError);
  }

  Update(url, obj: any) {
    return this.http.put(this.baseUrl + url, obj,
      { headers: { 'Authorization': 'Basic ' + btoa(this.username + ':' + this.password) } })
      .catch(this.errorHandleService.HandleError);
  }

  Patch(url, id: number, obj: any) {
    return this.http.patch(this.baseUrl + url + '/' + id, obj,
      { headers: { 'Authorization': 'Basic ' + btoa(this.username + ':' + this.password) } })
      .catch(this.errorHandleService.HandleError);
  }
  
  Remove(url, id: number) {
    return this.http.delete(this.baseUrl + url + '/' + id,
      { headers: { 'Authorization': 'Basic ' + btoa(this.username + ':' + this.password) } });
  }
}
