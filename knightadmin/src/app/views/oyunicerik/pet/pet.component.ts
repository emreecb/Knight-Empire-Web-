import { GlobalService } from 'src/app/_Services/global.service';
import { Pet } from "./../../../_Models/pet";
import { Component, OnInit, ViewChild } from "@angular/core";
import { dtOptions } from "src/app/dtOptions";
import { DataTableDirective } from "angular-datatables";
import { Subject } from "rxjs";
import { EditorOptions } from "src/app/editorOptions";
import { ToastrService } from "src/app/_Services/toastr.service";

@Component({
  selector: "app-pet",
  templateUrl: "./pet.component.html",
  styleUrls: ["./pet.component.scss"]
})
export class PetComponent implements OnInit {
  dtOptions = dtOptions;
  selectedFile: File = null;
  private url = "/Pet";
  @ViewChild(DataTableDirective)
  dtElement: DataTableDirective;
  dtTrigger = new Subject();
  dataTable: any;
  editorOptions = EditorOptions;

  _petobje: Pet = {
    id: 0,
    name: "",
    price: 0,
    attackBonus: 0,
    defenceBonus: 0,
    healthBonus: 0,
    photo: "",
    active: true,
    deleteStatus: false,
    createTime: null,
    updateTime: null
  };

  petListe: Pet[] = [];
  constructor(
    private service: GlobalService,
    private toastService: ToastrService
  ) {}

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
      this.petListe = resp;
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
    this._petobje = obj;
    this.service.yukariCIK();
  }

  activePassive(obj) {
    if (obj.active) {
      obj.active = false;
      this.update(obj);
    } else {
      obj.active = true;
      this.update(obj);
    }
  }
  delete(id, obj) {
    const index = this.petListe.indexOf(obj);

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
    this._petobje = {
      id: 0,
      name: "",
      price: 0,
      attackBonus: 0,
      defenceBonus: 0,
      healthBonus: 0,
      photo: "",
      active: true,
      deleteStatus: false,
      createTime: null,
      updateTime: null
    };
  }

  ngOnInit() {
    this.service.Get(this.url).subscribe((resp: any) => {
      this.petListe = resp;
      this.dtTrigger.next();
    });
  }
}
