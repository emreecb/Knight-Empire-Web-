import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { DataTablesModule } from 'angular-datatables';
import { ModalModule } from 'ngx-bootstrap/modal';
import { QuillEditorModule } from 'ngx-quill-editor';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { IcerikRoutingModule } from './icerik-routing.module';
import { HaberComponent } from './haber/haber.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IcerikRoutingModule,
    DataTablesModule,
    ModalModule.forRoot(),
    QuillEditorModule,
    TooltipModule.forRoot()
  ],
  declarations: [
    HaberComponent
    
  ]
})
export class IcerikModule { }
