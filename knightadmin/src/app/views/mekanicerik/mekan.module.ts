import { AreamobComponent } from "./areamob/areamob.component";
import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { AreaComponent } from "./area/area.component";
import { FormsModule } from "@angular/forms";
import { DataTablesModule } from "angular-datatables";
import { QuillEditorModule } from "ngx-quill-editor";
import { MekanRoutingModule } from "./mekan-routing.module";

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    DataTablesModule,
    QuillEditorModule,
    MekanRoutingModule
  ],
  declarations: [AreaComponent, AreamobComponent]
})
export class MekanModule {}
