import { Component, OnInit, ViewChild } from "@angular/core";
import { dtOptions } from "src/app/dtOptions";
import { DataTableDirective } from "angular-datatables";
import { Subject } from "rxjs";
import { EditorOptions } from "src/app/editorOptions";
import { GlobalService } from "src/app/_Services/global.service";
import { ToastrService } from "src/app/_Services/toastr.service";
import { Item } from "src/app/_Models/item";

@Component({
  selector: "app-item",
  templateUrl: "./item.component.html",
  styleUrls: ["./item.component.scss"]
})
export class ItemComponent implements OnInit {
  dtOptions = dtOptions;
  selectedFile: File = null;
  private url = "/Item";
  @ViewChild(DataTableDirective)
  dtElement: DataTableDirective;
  dtTrigger = new Subject();
  dataTable: any;
  editorOptions = EditorOptions;

  itemobje: Item = {
    id: 0,
    itemName: "",
    itemType: 0,
    attack: 0,
    defence: 0,
    health: 0,
    dropRate: 0,
    flameBonus: 0,
    glacierBonus: 0,
    lightningBonus: 0,
    poisonBonus: 0,
    bonusMultiplier: 1,
    statMultiplier: 1,
    dropGroup: 1,
    photo: null,
    active: true,
    deleteStatus: false,
    createTime: null,
    updateTime: null,
    cost:0,
    itemAbout:"",
  };

  itemliste: Item[] = [];
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
      this.onUpload(resp.id);
    });
    this.service.loading(false, "işleminiz ");
  }
  edit(obj) {
    obj.kategoriler = null;
    this.itemobje = obj;
    this.service.yukariCIK();
  }

  activePassive(obj) {
    obj.kategoriler = null;
    if (obj.active) {
      obj.active = false;
      this.update(obj);
    } else {
      obj.active = true;
      this.update(obj);
    }
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
      itemName: "",
      itemType: 0,
      attack: 0,
      defence: 0,
      health: 0,
      dropRate: 0,
      flameBonus: 0,
      glacierBonus: 0,
      lightningBonus: 0,
      poisonBonus: 0,
      bonusMultiplier: 1,
      statMultiplier: 1,
      dropGroup: 1,
      photo: null,
      active: true,
      deleteStatus: false,
      createTime: null,
      updateTime: null,
      itemAbout:"",
      cost:0
    };
  }

  ngOnInit() {
    this.service.Get(this.url).subscribe((resp: any) => {
      this.itemliste = resp;
      this.dtTrigger.next();
    });
  }
}
