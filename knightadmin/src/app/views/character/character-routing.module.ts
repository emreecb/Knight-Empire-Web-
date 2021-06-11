import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { CharacterlevelComponent } from './characterlevel/characterlevel.component';
import { RutbeComponent } from "./rutbe/rutbe.component";

const routes: Routes = [
  {
    path: "",
    data: {
      title: "Karakter",
      breadcrumb: "Home   /  Karakter"
    },
    children: [
      {
        path: "characterlevel",
        component: CharacterlevelComponent,
        data: {
          title: "characterlevel",
          breadcrumb: "characterlevel"
        }
      },
      {
        path: "rutbe",
        component: RutbeComponent,
        data: {
          title: "rutbe",
          breadcrumb: "rutbe"
        }
      },
      // {
      //   path: "mob",
      //   component: MobComponent,
      //   data: {
      //     title: "Mob",
      //     breadcrumb: "Mob"
      //   }
      // }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CharacterRoutingModule {}
