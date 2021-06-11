import { Component, OnInit, ViewChild } from '@angular/core';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
import { EditorOptions } from 'src/app/editorOptions';
import { Item } from 'src/app/_Models/item';
import { GlobalService } from 'src/app/_Services/global.service';
import { ToastrService } from 'src/app/_Services/toastr.service';
import { Characterlevel } from 'src/app/_Models/characterlevel';
import { dtOptions } from 'src/app/dtOptions';

@Component({
  selector: 'app-characterlevel',
  templateUrl: './characterlevel.component.html',
  styleUrls: ['./characterlevel.component.scss']
})
export class CharacterlevelComponent implements OnInit {
  dtOptions = dtOptions;
  selectedFile: File = null;
  private url = "/CharacterLevel";
  @ViewChild(DataTableDirective)
  dtElement: DataTableDirective;
  dtTrigger = new Subject();
  dataTable: any;
  editorOptions = EditorOptions;

  itemobje: Characterlevel = {
    id: 0,
    level: 0,
    experience: 0,
    baseStats: 0
  };

  itemliste: Item[] = [];
  constructor(
    private service: GlobalService,
    private toastService: ToastrService
  ) {}

  tablerefresh() {
    this.clean();
    this.service.Get(this.url).subscribe((resp: any) => {
      this.itemliste = resp;
      this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
        dtInstance.destroy();
        this.dtTrigger.next();
      });
    });
  }


  update(obj?) {
    this.service.loading(true, "işleminiz ");

    this.service.Update(this.url, obj).subscribe((resp: any) => {
      this.tablerefresh();
    });
    this.service.loading(false, "işleminiz ");
  }

  edit(obj) {
    this.itemobje = obj;
    this.service.yukariCIK();
  }

  delete(id, obj) {
    const index = this.itemliste.indexOf(obj);

    const check = confirm("Silme işlemini onaylıyorum!");
    if (check === true) {
      this.service.loading(true, "isleminiz ");
      this.service.Remove(this.url, id).subscribe(resp => {
        this.tablerefresh();
        this.clean();
        this.service.loading(false, "isleminiz ");
      });
    } else {
      return false;
    }
  }

  clean() {
    this.selectedFile = null;
    this.itemobje = {
      id: 0,
    level: 0,
    experience: 0,
    baseStats: 0
    };
  }

  ngOnInit() {
    this.service.Get(this.url).subscribe((resp: any) => {
      this.itemliste = resp;
      this.dtTrigger.next();
    });
  }
}
