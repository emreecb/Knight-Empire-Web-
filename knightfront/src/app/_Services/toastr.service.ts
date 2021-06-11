import { Injectable } from '@angular/core';
declare var toastr: any;
@Injectable()
export class ToastrService {

  constructor() { }

  Success(msg?) {
    toastr.success(msg);
  }

  hata(msg?) {
    toastr.error(msg);
  }

  Warning(msg?) {
    toastr.warning(msg);
  }
}
