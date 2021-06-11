import { RenewPasswordComponent } from './pages/renewPassword/renewPassword.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { UserAdminRoutingModule } from './user-admin-routing.module';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { AdminlayoutComponent } from './adminlayout/adminlayout.component';
import { AuthGuard } from './Services/_authService/auth.guard';
import { CharacterdetailsComponent } from './characterdetails/characterdetails.component';
import { BolgelerComponent } from './bolgeler/bolgeler.component';
import { VipstorageComponent } from './vipstorage/vipstorage.component';
import { MoblistComponent } from './bolgeler/moblist/moblist.component';
import { InventoryComponent } from './inventory/inventory.component';
import { PvpComponent } from './pvp/pvp.component';
import { QuestComponent } from './quest/quest.component';
import { ModalModule } from 'ngx-bootstrap';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    UserAdminRoutingModule,
    ModalModule.forRoot()
  ],
  declarations: [
    AdminlayoutComponent,
    AdminHomeComponent,
    CharacterdetailsComponent,
    BolgelerComponent,
    VipstorageComponent,
    MoblistComponent,
    InventoryComponent,
    PvpComponent,
    QuestComponent,
    RenewPasswordComponent
  ],
  providers: [
    AuthGuard
  ]
})
export class UserAdminModule { }
