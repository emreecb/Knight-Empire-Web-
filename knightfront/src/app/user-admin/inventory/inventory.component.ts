import { Component, OnInit } from "@angular/core";
import { Envantermodel } from "./envantermodel";
import { GlobalService } from "src/app/_Services/global.service";
import { DashboardService } from "../Services/_authService/dashboard.service";
import { ToastrService } from "src/app/_Services/toastr.service";

@Component({
  selector: "app-inventory",
  templateUrl: "./inventory.component.html",
  styleUrls: ["./inventory.component.scss"]
})
export class InventoryComponent implements OnInit {
  private url = "/Inventory";
  private url2 = "/Inventory/takeof";
  private url3 = "/Inventory/wear";
  private urlmoney = "/Money"
  private urlstat = "/Stat"

  inventorylist: Envantermodel[] = [];
  wearlist: Envantermodel[] = [];
  editarea = false;
  id: number;
  money: any;

  constructor(private serv: GlobalService, private dash: DashboardService, private toastr: ToastrService) {
    dash.getHomeDetails().subscribe(home => {
      this.id = home.id;
      serv.GetID(this.urlmoney, home.id).subscribe((respons: any) => {
        this.money = respons;
      })
      serv.GetID(this.url, home.id).subscribe((resp: Envantermodel[]) => {
        this.inventorylist = resp.filter(resp => resp.wearing == false)
        this.wearlist = resp.filter(resp => resp.wearing == true);
        this.wearlist.sort(function (obj1, obj2) {
          return obj1.itemType - obj2.itemType;
        });
      });
    });
  }

  _object: Envantermodel;

  giy(item) {
    this._object.wearing=true;
    this.serv
      .Update(this.url3, item)
      .subscribe(resp => {
        this.refresh();
      });
  }

  gelistir(item) {
    this.serv.loading(true, "İşleminiz")
    if (item.itemLevel < 8) {
      this.serv.GetID(this.urlmoney, this.id).subscribe((resp: any) => {
        if (resp.coin >= (item.itemLevel * item.item.cost)) {
          item.itemLevel++;
          this.serv.Update(this.url, item).subscribe((resp1: any) => {
            resp.coin = resp.coin - item.itemLevel * item.item.cost
            this.serv.Update(this.urlmoney, resp).subscribe((resp2: any) => {
              this.serv.loading(false, "İşleminiz")
              this.toastr.Success("Geliştirme Başarılı")
              this.refresh();
            })
          })
        }
        else {
          this.serv.loading(false, "İşleminiz")
          this.toastr.Warning("Yeterli Paranız bulunmamaktadır")
        }
      })
    }
    else {
      this.toastr.Warning("Geliştirme Max Düzeyde")
      this.serv.loading(false, "İşleminiz")
    }

  }

  sat(item) {
    const deger = confirm("Bu itemi satmak istediğinizden emin misiniz?")
    if (deger) {
      this.serv.loading(true, "İşleminiz")
      item.deleteStatus = true;
      item.wearing = false;
      this.serv.Update(this.url, item).subscribe((resp: any) => {
        this.serv.GetID(this.urlmoney, this.id).subscribe((resp1: any) => {
          resp1.coin = resp1.coin + item.itemLevel * item.item.cost + 10;
          this.serv.Update(this.urlmoney, resp1).subscribe(resp => {
            this.serv.loading(false, "İşleminiz")
            this.refresh();
            this.editarea = false;
          })
        })
      })
    }
  }

  refresh() {
    this.serv.GetID(this.urlmoney, this.id).subscribe((resp: any) => {
      this.money = resp;
    })
    this.serv.GetID(this.url, this.id).subscribe((resp: Envantermodel[]) => {
      this.inventorylist = resp.filter(resp => resp.wearing == false)
      this.wearlist = resp.filter(resp => resp.wearing == true);
      this.wearlist.sort(function (obj1, obj2) {
        return obj1.itemType - obj2.itemType;
      });
    });
  }

  show(obj) {
    this.editarea = true;
    this._object = obj;
  }

  ngOnInit() { }
}
