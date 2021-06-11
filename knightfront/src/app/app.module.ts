import { ForgotpassComponent } from './WebSite/_shared/forgotpass/forgotpass.component';
import { MainService } from './_Services/_base_services/main.service';
import { LoginComponent } from './WebSite/_shared/login/login.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DefaultLayoutComponent } from './WebSite/_Layout';
import { HomeComponent } from './WebSite/home/home.component';
import { UserAdminModule } from './user-admin/user-admin.module';
import { ErrorHandleService } from './_Services/_base_services/error-Handle.service';
import { AppGlobalErrorHandler } from './app-global-errorHandler';
import { GlobalService } from './_Services/global.service';
import { ToastrService } from './_Services/toastr.service';
import { XHRBackend, HttpModule } from '@angular/http';
import { AuthenticateXHRBackend } from './user-admin/Services/_authService/authenticate-xhr.backend';
import { UserService } from './user-admin/Services/_authService/user.service';
import { DashboardService } from './user-admin/Services/_authService/dashboard.service';
import {HttpClientModule} from 'ngx-http-client';
import { EmailValidator } from './user-admin/Services/directives/email.validator.directive';
import { Myfocus } from './user-admin/Services/directives/myFocus';
import { SpinnerComponent } from './user-admin/Services/spinner/spinner.component';
import { RegisterComponent } from './WebSite/_shared/register/register.component';
import { ConfirmComponent } from './WebSite/_shared/confirm/confirm.component';
import { ResetpasswordComponent } from './WebSite/_shared/resetpassword/resetpassword.component';
import { DataTablesModule } from 'angular-datatables';
import * as $ from 'jquery';

// Components İmport


const APP_CONTAINERS = [
  DefaultLayoutComponent
];

import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { RegisterfirstComponent } from './WebSite/_shared/registerfirst/registerfirst.component';
import { KurallarComponent } from './WebSite/Rehber/kurallar/kurallar.component';
import { SssComponent } from './WebSite/Rehber/sss/sss.component';
import { HikayeComponent } from './WebSite/Rehber/hikaye/hikaye.component';
import { NasiloynanirComponent } from './WebSite/Rehber/nasiloynanir/nasiloynanir.component';
import { MedyaComponent } from './WebSite/medya/medya.component';
import { IletisimformuComponent } from './WebSite/iletisimformu/iletisimformu.component';
import { KnightrankComponent } from './WebSite/knightrank/knightrank.component';
import { HaberlerComponent } from './WebSite/haberler/haberler.component';
import { HaberdetayComponent } from './WebSite/haberdetay/haberdetay.component';
import { HakkimizdaComponent } from './WebSite/hakkimizda/hakkimizda.component';



@NgModule({
  declarations: [
    AppComponent,
    ...APP_CONTAINERS,
    HomeComponent,
    RegisterComponent,
    LoginComponent,
    ResetpasswordComponent,
    ConfirmComponent,
    ForgotpassComponent,
    RegisterfirstComponent,
    KurallarComponent,
    KnightrankComponent,
    SssComponent,
    HikayeComponent,
    NasiloynanirComponent,
    HaberlerComponent,
    HaberdetayComponent,
    MedyaComponent,
    HakkimizdaComponent,
    EmailValidator,
    Myfocus,
    SpinnerComponent,
    IletisimformuComponent
  ],
  exports: [Myfocus, SpinnerComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    DataTablesModule,
    FormsModule,
    UserAdminModule,
    HttpModule,
    TooltipModule.forRoot(),
    HttpClientModule
  ],
  providers: [
    MainService,
    ErrorHandleService,
    { provide: ErrorHandler, useClass: AppGlobalErrorHandler },
    GlobalService,
    ToastrService,
    UserService,
    DashboardService,
    {
      provide: XHRBackend,
      useClass: AuthenticateXHRBackend,
    },

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }  


  

