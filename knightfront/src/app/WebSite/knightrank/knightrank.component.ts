import { Component, OnInit, ViewChild } from '@angular/core';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
import { GlobalService } from 'src/app/_Services/global.service';
import { ToastrService } from 'src/app/_Services/toastr.service';
import { dtOptions } from 'src/app/dtOptions';
export class Person {
  constructor(public firstName: string, public lastName: string, public age: number) { }
}

@Component({
  selector: 'app-knightrank',
  templateUrl: './knightrank.component.html',
  styleUrls: ['./knightrank.component.scss'],
})
export class KnightrankComponent implements OnInit {
  dtOptions = dtOptions;
  selectedFile: File = null;
  private url = "/CharacterDetails";
  @ViewChild(DataTableDirective)
  dtElement: DataTableDirective;
  dtTrigger = new Subject();
  dataTable: any;


  constructor(
    private service: GlobalService,
    private toastService: ToastrService
  ) { }

  userlist: any[] = [];

  ngOnInit() {
    this.service.Get(this.url).subscribe((resp: any) => {
      this.userlist = resp;
      this.userlist.forEach(element => {
        if(element.nation){
          element.nation="Human"
        }
        if(!element.nation){
          element.nation="Karus"
        }
        
      });
      this.dtTrigger.next();
      
    });
  }
}
