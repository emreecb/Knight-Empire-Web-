import { ResetpasswordComponent } from "./views/defaultPages/resetpassword/resetpassword.component";
import { AuthGuard } from "./_Services/_authService/auth.guard";
import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

// default pages
import { P404Component } from "./views/defaultPages/error/p404/p404.component";
import { P500Component } from "./views/defaultPages/error/p500/p500.component";
import { LoginComponent } from "./views/defaultPages/login/login.component";
import { ForgotPassComponent } from "./views/defaultPages/forgotPass/forgotPass.component";
import { DefaultLayoutComponent } from "./containers";

const routes: Routes = [
  { path: "", redirectTo: "dashboard", pathMatch: "full" },
  { path: "404", component: P404Component },
  { path: "500", component: P500Component },
  { path: "login", component: LoginComponent },
  { path: "forgotpass", component: ForgotPassComponent },
  { path: "resetpass", component: ResetpasswordComponent },
  {
    path: "",
    component: DefaultLayoutComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: "dashboard",
        loadChildren: "./views/dashboard/dashboard.module#DashboardModule"
      },
      {
        path: "icerik",
        loadChildren: "./views/icerik/icerik.module#IcerikModule"
      },
      {
        path: "oyun",
        loadChildren: "./views/oyunicerik/oyunicerik.module#OyunicerikModule"
      },
      {
        path: "character",
        loadChildren: "./views/character/chacter.module#ChacterModule"
      },
      {
        path: "mekan",
        loadChildren: "./views/mekanicerik/mekan.module#MekanModule"
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
