import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { DashboardComponent } from './dashboard.component';

import { DataTablesModule } from 'angular-datatables';

import { DashboardRoutingModule } from './dashboard-routing.module';
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    DashboardRoutingModule,
    DataTablesModule
  ],
  declarations: [DashboardComponent]
})
export class DashboardModule { }
