import { Mob } from "./../../../_Models/mob";
import { Component, OnInit, ViewChild } from "@angular/core";
import { dtOptions } from "src/app/dtOptions";
import { DataTableDirective } from "angular-datatables";
import { Subject } from "rxjs";
import { EditorOptions } from "src/app/editorOptions";
import { Pet } from "src/app/_Models/pet";
import { GlobalService } from "src/app/_Services/global.service";
import { ToastrService } from "src/app/_Services/toastr.service";

@Component({
  selector: "app-mob",
  templateUrl: "./mob.component.html",
  styleUrls: ["./mob.component.scss"]
})
export class MobComponent implements OnInit {
  dtOptions = dtOptions;
  selectedFile: File = null;
  private url = "/Mob";
  @ViewChild(DataTableDirective)
  dtElement: DataTableDirective;
  dtTrigger = new Subject();
  dataTable: any;
  editorOptions = EditorOptions;

  _mobobje: Mob = {
    id: 0,
    name: "",
    drop: 0,
    dropGroup: 0,
    minLevel: 0,
    health: 0,
    defense: 0,
    attack: 0,
    maxExp: 0,
    minExp: 0,
    maxCoin: 0,
    minCoin: 0,
    photo: "",
    manaValue: 0,
    active: true,
    deleteStatus: false,
    createTime: null,
    updateTime: null
  };

  mobListe: Mob[] = [];
  constructor(
    private service: GlobalService,
    private toastService: ToastrService
  ) {}

  onFileSelected(event) {
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
        this.clean();
        this.service.loading(true, "İşleminiz ");
      });
    } else {
      this.tablerefresh();
      this.clean();
    }
  }

  tablerefresh() {
    this.clean();
    this.service.Get(this.url).subscribe((resp: any) => {
      this.mobListe = resp;
      this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
        dtInstance.destroy();
        this.dtTrigger.next();
      });
    });
  }

  update(obj?) {
    console.log("obj",obj)
    this.service.loading(true, "işleminiz ");

    this.service.Update(this.url, obj).subscribe((resp: any) => {
      this.onUpload(resp.id);
    });
    this.service.loading(false, "işleminiz ");
  }

  edit(obj) {
    this._mobobje = obj;
    this.service.yukariCIK();
  }

  activePassive(obj) {
    console.log("actifpasif",obj)
    if (obj.active) {
      obj.active = false;
      this.update(obj);
    } else {
      obj.active = true;
      this.update(obj);
    }
  }
  delete(id, obj) {
    const index = this.mobListe.indexOf(obj);

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
    this._mobobje = {
      id: 0,
      name: "",
      drop: 0,
      dropGroup: 0,
      minLevel: 0,
      health: 0,
      defense: 0,
      attack: 0,
      maxExp: 0,
      minExp: 0,
      maxCoin: 0,
      minCoin: 0,
      photo: "",
      manaValue: 0,
      active: true,
      deleteStatus: false,
      createTime: null,
      updateTime: null
    };
  }

  ngOnInit() {
    this.service.Get(this.url).subscribe((resp: any) => {
      this.mobListe = resp;
      this.dtTrigger.next();
    });
  }
}
