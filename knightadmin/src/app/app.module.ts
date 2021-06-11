import { FormsModule } from '@angular/forms';
import { ToastrService } from './_Services/toastr.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DefaultLayoutComponent } from './containers';
// breadcrumb
import { BreadcrumbsModule } from 'ng2-breadcrumbs';
// default pages
import { P404Component } from './views/defaultPages/error/p404/p404.component';
import { P500Component } from './views/defaultPages/error/p500/p500.component';
import { LoginComponent } from './views/defaultPages/login/login.component';
import { ForgotPassComponent } from './views/defaultPages/forgotPass/forgotPass.component';

// Services
import { HttpClientModule } from '@angular/common/http';
import { MainService } from './_Services/_base_services/main.service';
import { ErrorHandleService } from './_Services/_base_services/error-Handle.service';
import { AppGlobalErrorHandler } from './app-global-errorHandler';
import { GlobalService } from './_Services/global.service';
// dataTables
import { DataTablesModule } from 'angular-datatables';
import { UserService } from './_Services/_authService/user.service';
import { XHRBackend, HttpModule } from '@angular/http';
import { AuthenticateXHRBackend } from './_Services/_authService/authenticate-xhr.backend';
import { myFocus } from './_Services/_authService/directives/myFocus';
import { EmailValidator } from './_Services/_authService/directives/email.validator.directive';
import { SpinnerComponent } from './_Services/_authService/spinner/spinner.component';
import { DashboardService } from './_Services/_authService/dashboard.service';
import { AuthGuard } from './_Services/_authService/auth.guard';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { ResetpasswordComponent } from './views/defaultPages/resetpassword/resetpassword.component';
import { RegisterComponent } from './views/defaultPages/register/register.component';

const APP_CONTAINERS = [
  DefaultLayoutComponent
];

@NgModule({
  declarations: [
    AppComponent,
    ...APP_CONTAINERS,
    P404Component,
    P500Component,
    LoginComponent,
    ForgotPassComponent,
    myFocus,
    EmailValidator,
    RegisterComponent,
    SpinnerComponent,
    ResetpasswordComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BreadcrumbsModule,
    HttpClientModule,
    HttpModule,
    FormsModule,
    BrowserModule,
    DataTablesModule,
    AngularFontAwesomeModule
  ],
  exports: [myFocus, SpinnerComponent],
  providers: [
      MainService,
      ErrorHandleService,
      { provide: ErrorHandler, useClass: AppGlobalErrorHandler },
      ToastrService,
      GlobalService,
      DashboardService,
      AuthGuard,
      UserService,
      {
        provide: XHRBackend,
        useClass: AuthenticateXHRBackend
      }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
