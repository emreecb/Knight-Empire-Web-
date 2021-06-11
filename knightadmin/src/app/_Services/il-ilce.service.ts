import { ToastrService } from './toastr.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';

@Injectable()
export class IlIlceService {
  constructor(private http: HttpClient, private toast: ToastrService) {
    this.getJSON().subscribe(data => {
    //  this.toast.Success();
      console.log(data);
    });
  }

  public getJSON(): Observable<any> {
    return this.http.get('./assets/il-ilce.json');
  }


}
