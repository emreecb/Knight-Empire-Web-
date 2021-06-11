import { Routes, RouterModule } from "@angular/router";
import { NgModule } from "@angular/core";
import { HaberComponent } from "./haber/haber.component";

const routes: Routes = [
    {
      path : '',
      data: {
        title: 'İcerik',
        breadcrumb: 'Home   /  Icerik',
      },
      children: [
        {
          path: 'haber',
          component: HaberComponent,
          data: {
            title: 'Haber',
            breadcrumb: 'Haber'
          }
        }
      ]
    }
  
  ];
  
  @NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
  })


export class IcerikRoutingModule { }
