import { PetComponent } from './pet/pet.component';
import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { ItemComponent } from "./item/item.component";
import { MobComponent } from './mob/mob.component';
import { MerchantComponent } from './merchant/merchant.component';

const routes: Routes = [
  {
    path: "",
    data: {
      title: "Ürünler",
      breadcrumb: "Home   /  Oyunicerik"
    },
    children: [
      {
        path: "item",
        component: ItemComponent,
        data: {
          title: "İtem",
          breadcrumb: "İtem"
        }
      },
      {
        path: "pet",
        component: PetComponent,
        data: {
          title: "Pet",
          breadcrumb: "Pet"
        }
      },
      {
        path: "mob",
        component: MobComponent,
        data: {
          title: "Mob",
          breadcrumb: "Mob"
        }
      },
      {
        path: "merchant",
        component: MerchantComponent,
        data: {
          title: "Merchant",
          breadcrumb: "Merchant"
        }
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OyunicerikRoutingModule {}
