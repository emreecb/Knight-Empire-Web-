import { ErrorHandler } from '@angular/core';

export class AppGlobalErrorHandler implements ErrorHandler {
  handleError(error) {
    console.log(error);
  }
}
