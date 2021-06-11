import { CharacterRoutingModule } from "./character-routing.module";
import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { CharacterlevelComponent } from "./characterlevel/characterlevel.component";
import { FormsModule } from "@angular/forms";
import { OyunicerikRoutingModule } from "../oyunicerik/oyunicerik-routing.module";
import { DataTablesModule } from "angular-datatables";
import { QuillEditorModule } from "ngx-quill-editor";
import { RutbeComponent } from "./rutbe/rutbe.component";

@NgModule({
  imports: [
    CommonModule,
    CharacterRoutingModule,
    FormsModule,
    DataTablesModule,
    QuillEditorModule
  ],
  declarations: [CharacterlevelComponent,RutbeComponent]
})
export class ChacterModule {}
