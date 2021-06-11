import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminlayoutComponent } from './adminlayout/adminlayout.component';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { RenewPasswordComponent } from './pages/renewPassword/renewPassword.component';
import { AuthGuard } from './Services/_authService/auth.guard';
import { CharacterdetailsComponent } from './characterdetails/characterdetails.component';
import { BolgelerComponent } from './bolgeler/bolgeler.component';
import { VipstorageComponent } from './vipstorage/vipstorage.component';
import { MoblistComponent } from './bolgeler/moblist/moblist.component';
import { InventoryComponent } from './inventory/inventory.component';
import { PvpComponent } from './pvp/pvp.component';
import { QuestComponent } from './quest/quest.component';
import { SssComponent } from '../WebSite/Rehber/sss/sss.component';
import { HikayeComponent } from '../WebSite/Rehber/hikaye/hikaye.component';
import { NasiloynanirComponent } from '../WebSite/Rehber/nasiloynanir/nasiloynanir.component';
import { MedyaComponent } from '../WebSite/medya/medya.component';
import { IletisimformuComponent } from '../WebSite/iletisimformu/iletisimformu.component';
import { KnightrankComponent } from '../WebSite/knightrank/knightrank.component';
import { HaberlerComponent } from '../WebSite/haberler/haberler.component';
import { KurallarComponent } from '../WebSite/Rehber/kurallar/kurallar.component';
import { HakkimizdaComponent } from '../WebSite/hakkimizda/hakkimizda.component';

const routes: Routes = [{
  path: 'User',
  component: AdminlayoutComponent, canActivate: [AuthGuard],
  data: {
    title: 'useradmin',
    breadcrumb: 'useradmin',
  },
  children: [
    {
      path: 'adminpanel', component: AdminHomeComponent,
      data: {
        title: 'home',
        breadcrumb: 'home'
      }
    },
    {
      path: 'sifredegistir', component: RenewPasswordComponent,
      data: {
        title: 'sifredegistir',
        breadcrumb: 'sifredegistir'
      }
    },
    {
      path: 'characterdetails', component: CharacterdetailsComponent,
      data: {
        title: 'characterdetails',
        breadcrumb: 'characterdetails'
      }
    },
    {
      path: 'bolgeler', component: BolgelerComponent,
      data: {
        title: 'bolgeler',
        breadcrumb: 'bolgeler'
      }
    },
    {
      path: 'vipstorage', component: VipstorageComponent,
      data: {
        title: 'vipstorage',
        breadcrumb: 'vipstorage'
      }
    },
    {
      path: 'moblist/:id', component: MoblistComponent,
      data: {
        title: 'moblist',
        breadcrumb: 'moblist'
      }
    },
    {
      path: 'inventory', component: InventoryComponent,
      data: {
        title: 'inventory',
        breadcrumb: 'inventory'
      }
    },
    {
      path: 'pvp', component: PvpComponent,
      data: {
        title: 'pvp',
        breadcrumb: 'pvp'
      }
    },
    {
      path: 'quest', component: QuestComponent,
      data: {
        title: 'quest',
        breadcrumb: 'quest'
      }
    },
    {
      path: 'sikcasorulansorular', component: SssComponent,
      data: {
        title: 'sikcasorulansorular',
        breadcrumb: 'sikcasorulansorular'
      }
    },
    {
      path: 'haberler', component: HaberlerComponent,
      data: {
        title: 'haberler',
        breadcrumb: 'haberler'
      }
    },

    {
      path: 'hakkimizda', component: HakkimizdaComponent,
      data: {
        title: 'hakkimizda',
        breadcrumb: 'hakkimizda'
      }
    },
    {
      path: 'medya', component: MedyaComponent,
      data: {
        title: 'medya',
        breadcrumb: 'medya'
      }
    },
    {
      path: 'iletisimformu', component: IletisimformuComponent,
      data: {
        title: 'iletisimformu',
        breadcrumb: 'iletisimformu'
      }
    },
    {
      path: 'kurallar', component: KurallarComponent,
      data: {
        title: 'kurallar',
        breadcrumb: 'kurallar'
      }
    },
    {
      path: 'knightrank', component: KnightrankComponent,
      data: {
        title: 'knightrank',
        breadcrumb: 'knightrank'
      }
    }
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserAdminRoutingModule { }
