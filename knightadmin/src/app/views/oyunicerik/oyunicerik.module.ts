import { PetComponent } from './pet/pet.component';
import { ItemComponent } from './item/item.component';
import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { FormsModule } from "@angular/forms";
import { DataTablesModule } from "angular-datatables";
import { QuillEditorModule } from "ngx-quill-editor";
import { MobComponent } from './mob/mob.component';
import { OyunicerikRoutingModule } from './oyunicerik-routing.module';
import { MerchantComponent } from './merchant/merchant.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    OyunicerikRoutingModule,
    DataTablesModule,
    QuillEditorModule
  ],
  declarations: [
    ItemComponent,
    PetComponent,
    MobComponent,
    MerchantComponent
  ]
})
export class OyunicerikModule {}
