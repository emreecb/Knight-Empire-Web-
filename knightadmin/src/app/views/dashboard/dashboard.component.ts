import { Component, OnInit, ViewChild } from '@angular/core';
import { DataTableDirective } from 'angular-datatables';
import 'datatables.net';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  constructor() { }

  ngOnInit() {}

}
