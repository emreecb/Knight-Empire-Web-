import { Mob } from "./../../../_Models/mob";
import { Area } from "./../../../_Models/area";
import { Component, OnInit, ViewChild } from "@angular/core";
import { GlobalService } from "src/app/_Services/global.service";
import { DataTableDirective } from "angular-datatables";
import { dtOptions } from "src/app/dtOptions";
import { Subject } from "rxjs";
import { EditorOptions } from "src/app/editorOptions";
import { ToastrService } from "src/app/_Services/toastr.service";

@Component({
  selector: "app-areamob",
  templateUrl: "./areamob.component.html",
  styleUrls: ["./areamob.component.scss"]
})
export class AreamobComponent implements OnInit {
  dtOptions = dtOptions;
  @ViewChild(DataTableDirective)
  dtElement: DataTableDirective;
  dtTrigger = new Subject();
  dataTable: any;

  private urlarea = "/Area";
  private urlmob = "/Mob";
  areaname: any;

  arealist: Area[] = [];
  moblist: Mob[] = [];
  areamoblist: Mob[] = [];
  obje: any = {
    id: 0,
    areaId: null,
    mobId: null
  };
  constructor(private service: GlobalService, private toastr: ToastrService) {
    service.Get(this.urlmob).subscribe((resp: any) => {
      this.moblist = resp;
    });
  }
  update(id, obj) {
    this.service.Update("/AreaMob", this.obje).subscribe(resp => {
      this.toastr.Success("İşlem başarılı");
      this.service
        .GetID("/AreaMob/getmoblist", obj.areaId)
        .subscribe((resp: any) => {
          this.areamoblist = resp;
        });
    });
  }

  delete(item) {
    var check = confirm("Silme işlemini onaylıyorum!");
    if (check == true) {
      this.service.Get("/AreaMob").subscribe((resp: any) => {
        resp.forEach(element => {
          if (element.areaId == this.obje.areaId && element.mobId == item.id) {
            this.service
              .Remove("/AreaMob", element.id)
              .subscribe((resp: any) => {
                this.toastr.Success("Silme işlemi başarılı");
                this.service
                  .GetID("/AreaMob/getmoblist", this.obje.areaId)
                  .subscribe((resp: any) => {
                    this.areamoblist = resp;
                  });
              });
          }
        });
      });
    } else {
      return false;
    }
  }

  edit(item) {
    this.service.yukariCIK();
    this.obje.areaId = item.id;
    this.areaname = item.areaName;
    this.service
      .GetID("/AreaMob/getmoblist", item.id)
      .subscribe((resp: any) => {
        this.areamoblist = resp;
      });
  }

  ngOnInit() {
    this.service.Get(this.urlarea).subscribe((resp: any) => {
      this.arealist = resp;
      this.dtTrigger.next();
    });
  }
}
