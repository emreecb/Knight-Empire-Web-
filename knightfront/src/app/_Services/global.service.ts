import { Injectable } from '@angular/core';
import { MainService } from './_base_services/main.service';
import { ErrorHandleService } from './_base_services/error-Handle.service';
import { HttpClient } from '@angular/common/http';
import { ToastrService } from './toastr.service';
import { DashboardService } from '../user-admin/Services/_authService/dashboard.service';


@Injectable()
export class GlobalService extends MainService {

  constructor(http: HttpClient,
    dashService:DashboardService, errorHandleService: ErrorHandleService, private toastr: ToastrService) {
    super(http, errorHandleService);
  }

  mana: number = 0;
  manax: string = "0%";
  exp: number = 0;
  expx: string = "0%";
  level:number=0;
  leveloran:any=0;
  leveloranwidth:any=0

  funcmana(obj?, obj2?,level?,levelexp?) {
    this.mana = obj;
    this.manax = obj + "%";
    this.exp = obj2;
    this.expx = obj2 + "%";
    this.level=level;
    var x=obj2/levelexp
    x=x*100;

    this.leveloran= (x).toFixed(2) + "%";
    this.leveloranwidth = (x).toFixed() + "%";
  }


  loading(state: boolean, msg: string) {
    const toast = this.toastr;
    if (state) {
      $('#loadingWrapper').fadeToggle(500).delay(700);
    } else {
      $('#loadingWrapper').fadeToggle(500, function () {
        if (state == false)
          toast.Success(msg + 'Yapıldı.');
      });
    }
  }

  orderBySira(list: any[]) {
    list.sort(function (obj1, obj2) {
      return obj1.sira - obj2.sira;
    });
  }


}
