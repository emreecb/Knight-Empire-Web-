import { Injectable } from '@angular/core';
declare var toastr: any;
@Injectable()
export class ToastrService {

  constructor() { }

  Success(aciklama?) {
    toastr.success(aciklama);
  }

  hata(aciklama?) {
    toastr.error(aciklama);
  }

  Warning(aciklama?) {
    toastr.warning(aciklama);
  }
}
