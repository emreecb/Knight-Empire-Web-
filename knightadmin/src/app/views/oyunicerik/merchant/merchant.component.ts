import { Component, OnInit, ViewChild } from "@angular/core";
import { DataTableDirective } from "angular-datatables";
import { Subject } from "rxjs";
import { EditorOptions } from "src/app/editorOptions";
import { Item } from "src/app/_Models/item";
import { GlobalService } from "src/app/_Services/global.service";
import { ToastrService } from "src/app/_Services/toastr.service";
import { Merchant } from "src/app/_Models/merchant";

@Component({
  selector: "app-merchant",
  templateUrl: "./merchant.component.html",
  styleUrls: ["./merchant.component.scss"]
})
export class MerchantComponent implements OnInit {
  dtOptions = this.dtOptions;
  selectedFile: File = null;
  private url = "/Market";
  @ViewChild(DataTableDirective)
  dtElement: DataTableDirective;
  dtTrigger = new Subject();
  dataTable: any;
  editorOptions = EditorOptions;

  itemobje: Merchant = {
    id: 0,
    itemAd: "",
    itemType: 0,
    price: 0,
    photo: "",
    active: true,
    deleteStatus: false,
    addTime: null,
    updateTime: null
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
      itemAd: "",
      itemType: 0,
      price: 0,
      photo: "",
      active: true,
      deleteStatus: false,
      addTime: null,
      updateTime: null
    };
  }

  ngOnInit() {
    this.service.Get(this.url).subscribe((resp: any) => {
      this.itemliste = resp;
      this.dtTrigger.next();
    });
  }
}
