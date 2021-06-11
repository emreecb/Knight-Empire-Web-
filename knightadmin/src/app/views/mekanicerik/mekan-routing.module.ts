import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { AreaComponent } from "./area/area.component";
import { AreamobComponent } from "./areamob/areamob.component";

const routes: Routes = [
  {
    path: "",
    data: {
      title: "Mekan",
      breadcrumb: "Home   /  Mekan"
    },
    children: [
      {
        path: "area",
        component: AreaComponent,
        data: {
          title: "Area",
          breadcrumb: "Area"
        }
      },
      {
        path: "areamob",
        component: AreamobComponent,
        data: {
          title: "Area-Mob",
          breadcrumb: "AreaMob"
        }
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MekanRoutingModule {}
