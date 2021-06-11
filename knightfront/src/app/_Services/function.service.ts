import { Injectable } from '@angular/core';

@Injectable()
export class FunctionService {

  constructor() { }

  basadon() {
    document.getElementById('collapseOne').classList.add('show');
    window.scrollTo(0, 0);
  }


}
