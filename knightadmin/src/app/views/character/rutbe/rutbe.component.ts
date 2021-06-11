import { Component, OnInit, ViewChild } from '@angular/core';
import { dtOptions } from 'src/app/dtOptions';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
import { EditorOptions } from 'src/app/editorOptions';
import { Haber } from '../../icerik/haber/Haber';
import { GlobalService } from 'src/app/_Services/global.service';
import { ToastrService } from 'src/app/_Services/toastr.service';
import { Rutbe } from './rutbe';

@Component({
  selector: 'app-rutbe',
  templateUrl: './rutbe.component.html',
  styleUrls: ['./rutbe.component.scss']
})
export class RutbeComponent implements OnInit {
  dtOptions = dtOptions;
  selectedFile: File = null;
  private url = "/Rutbe";
  @ViewChild(DataTableDirective)
  dtElement: DataTableDirective;
  dtTrigger = new Subject();
  dataTable: any;
  editorOptions = EditorOptions;

  _obje: Rutbe = {
    id: 0,
    rutbeAdi: "",
    aciklama: "",
    logo: "",
    min: 0,
    max: 0
  };

  List: Rutbe[] = [];
  constructor(
    private service: GlobalService,
    private toastService: ToastrService
  ) { }

  onFileSelected(event, index) {
    const inp = $(event.target).parent();
    $(inp)
      .find("label")
      .text(event.target.files[0].name);
    this.selectedFile = <File>event.target.files[0];
  }

  onUpload(id) {
    const fd = new FormData();
    if (this.selectedFile != null) {
      this.service.loading(true, "İşleminiz ");
      fd.append("image", this.selectedFile, this.selectedFile.name);
      this.service.Patch(this.url, id, fd).subscribe((resp: any) => {
        this.tablerefresh();
        this.service.loading(true, "İşleminiz ");
      });
    } else {
      this.tablerefresh();
    }
  }

  tablerefresh() {
    this.clean();
    this.service.Get(this.url).subscribe((resp: any) => {
      this.List = resp;
      this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
        dtInstance.destroy();
        this.dtTrigger.next();
      });
    });
  }

  update(obj?) {
    this.service.loading(true, "işleminiz ");

    this.service.Update(this.url, obj).subscribe((resp: any) => {
      this.onUpload(resp.id);
    });
    this.service.loading(false, "işleminiz ");
  }

  edit(obj) {
    this._obje = obj;
    this.service.yukariCIK();
  }

  activePassive(obj) {
    if (obj.aktif) {
      obj.active = false;
      this.update(obj);
    } else {
      obj.active = true;
      this.update(obj);
    }
  }
  delete(id, obj) {
    const index = this.List.indexOf(obj);

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
    this._obje = {
      id: 0,
    rutbeAdi: "",
    aciklama: "",
    logo: "",
    min: 0,
    max: 0
    };
  }

  ngOnInit() {
    this.service.Get(this.url).subscribe((resp: any) => {
      this.List = resp;
      this.dtTrigger.next();
    });
  }
}
