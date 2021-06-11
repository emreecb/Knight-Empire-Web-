import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { ToastrService } from '../toastr.service';

@Injectable()
export class ErrorHandleService {

  constructor(private toastService: ToastrService) { }
  HandleError(error: Response) {

    if (error.status === 400) {
      return Observable.throw('Hatalı istek');
    }
    if (error.status === 401) {
      return Observable.throw('Yetkiniz Yok');
    }
    if (error.status === 404) {
      return Observable.throw('Veri Bulunamadı');

    }
    return Observable.throw('Beklenmeyen Bir Hata Oluştu');
  }
}
