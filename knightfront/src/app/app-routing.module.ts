import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DefaultLayoutComponent } from './WebSite/_Layout';
import { HomeComponent } from './WebSite/home/home.component';
import { LoginComponent } from './WebSite/_shared/login/login.component';
import { RegisterComponent } from './WebSite/_shared/register/register.component';
import { ConfirmComponent } from './WebSite/_shared/confirm/confirm.component';
import { ForgotpassComponent } from './WebSite/_shared/forgotpass/forgotpass.component';
import { ResetpasswordComponent } from './WebSite/_shared/resetpassword/resetpassword.component';
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

export const routes: Routes = [


  { path: '', redirectTo: '/Anasayfa', pathMatch: 'full' },
  {
    path: '',
    component: DefaultLayoutComponent,
    children: [
      { path: 'Anasayfa', component: HomeComponent },
      { path: 'register/:id', component: RegisterComponent },      
      { path: 'login', component: LoginComponent },
      { path: 'confirm', component: ConfirmComponent },
      { path: 'forgotpass', component: ForgotpassComponent },
      { path: 'registerfirst', component: RegisterfirstComponent },
      { path: 'kurallar', component: KurallarComponent },
      { path: 'sikcasorulansorular', component: SssComponent },
      { path: 'hikaye', component: HikayeComponent },
      { path: 'nasiloynanir', component: NasiloynanirComponent },
      { path: 'medya', component: MedyaComponent },
      { path: 'resetpass', component: ResetpasswordComponent },
      { path: 'iletisimformu', component: IletisimformuComponent },
      { path: 'haberler', component: HaberlerComponent },
      { path: 'haberdetay/:id', component: HaberdetayComponent },
      { path: 'hakkimizda', component: HakkimizdaComponent },
      { path: 'knightrank', component: KnightrankComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
