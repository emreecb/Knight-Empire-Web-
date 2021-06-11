import { Injectable } from '@angular/core';
import { MainService } from './_base_services/main.service';
import { ErrorHandleService } from './_base_services/error-Handle.service';
import { HttpClient } from '@angular/common/http';
import { ToastrService } from './toastr.service';


@Injectable()
export class GlobalService extends MainService {
  public logo ;


  constructor(http: HttpClient, errorHandleService: ErrorHandleService, private toastr: ToastrService) {
    super(http, errorHandleService);

  }
  // logogetir() {
  //   this.GetID('/firmabilgileri', 1).subscribe((resp: any) => {
  //     this.logo = resp.logo;
  //   });
  // }

  yukariCIK(){
      const body = $('html, body');
      body.stop().animate({
        scrollTop: 0
      }, 500, 'swing', function () {
      });
  }
  loading(state: boolean, msg: string) {
    const toast =  this.toastr;
    if (state) {
      $('#loadingWrapper').fadeToggle(500).delay(700);
    } else {
      $('#loadingWrapper').fadeToggle(500, function () {
        if(state==false)
        toast.Success(msg + 'Yapıldı.');
      });
    }
  }
}

