import { ConfirmComponent } from "./../../WebSite/_shared/confirm/confirm.component";
import { Component, OnInit } from "@angular/core";
import { GlobalService } from "src/app/_Services/global.service";
import { DashboardService } from "../Services/_authService/dashboard.service";
import { ToastrService } from "src/app/_Services/toastr.service";

@Component({
  selector: "app-vipstorage",
  templateUrl: "./vipstorage.component.html",
  styleUrls: ["./vipstorage.component.scss"]
})
export class VipstorageComponent implements OnInit {
  private url = "/CharacterDetails";
  private url2 = "/Money";
  private url3 = "/Market";
  private url4 = "/Pet";
  private url5 = "/Inventory/pet";
  private url6 = "/Inventory";

  character: any;
  nation: any;
  money: any;
  petlist: any[] = [];
  marketlist: any[] = [];
  petobje: any;

  constructor(
    private globalService: GlobalService,
    private dashboardService: DashboardService,
    private toastr: ToastrService
  ) {
    this.dashboardService.getHomeDetails().subscribe((resp: any) => {
      globalService.GetID(this.url5, resp.id).subscribe(resp1 => {
        this.petobje = resp1;
        this.petobje.characterDetailsID = resp.id;
      });
      this.character = resp;
      if (this.character.nation) {
        this.nation = "Human";
      } else {
        this.nation = "Karus";
      }
      globalService.GetID(this.url2, resp.id).subscribe((response: any) => {
        this.money = response;
      });
    });
    globalService.Get(this.url3).subscribe((resp: any) => {
      this.marketlist = resp;
    });
    globalService.Get(this.url4).subscribe((resp1: any) => {
      this.petlist = resp1;
    });
  }
  satinal(item) {
    const onay = confirm("Satın alma işlemini onaylıyor musunuz?");
    if (onay) {
      this.globalService
        .GetID(this.url2, this.character.id)
        .subscribe((response: any) => {
          this.money = response;
          if (response.knightPoint >= item.price) {
            this.character.mana = this.character.mana + item.etken;
            if (this.character.mana > 100) {
              this.character.mana = 100;
            }
            this.globalService
              .Update(this.url, this.character)
              .subscribe(resp => {
                response.knightPoint = response.knightPoint - item.price;
                this.globalService
                  .Update(this.url2, response)
                  .subscribe(resp => {
                    this.toastr.Success("İşlem Başarılı");
                    setTimeout(() => {
                      location.reload();
                    }, 500);
                  });
              });
          } else {
            this.toastr.Warning("Paranız Yeterli Değil");
          }
        });
    }
  }

  petal(item) {
    this.petobje.petId = item.id;
    this.petobje.pet = null;
    this.petobje.wearing=true;
    const onay = confirm(
      "Satın alma işlemini onaylıyor musunuz? Daha önceki petiniz silinecektir"
    );
    if (onay) {
      this.globalService
        .GetID(this.url2, this.character.id)
        .subscribe((response: any) => {
          this.money = response;
          if (response.knightPoint >= item.price) {
            response.knightPoint = response.knightPoint - item.price;

            this.globalService
              .Update(this.url2, response)
              .subscribe(resp => {
                this.globalService
                  .Update(this.url6, this.petobje)
                  .subscribe(resp => {
                    this.toastr.Success("İşlem Başarılı");
                    setTimeout(() => {
                      location.reload();
                    }, 500);
                  });
              });
          }
          else{
            this.toastr.Warning("Yeterli Knight Point bulunmamaktadır.")
          }
        });
    }
  }

  kpyukle() {
    this.globalService
      .GetID(this.url2, this.character.id)
      .subscribe((response: any) => {
        response.knightPoint = response.knightPoint + 500;
        this.globalService
          .Update(this.url2, response)
          .subscribe((resp: any) => {
            alert("Hesabınıza 500 Knight Point Yüklenmiştir.");
            setTimeout(() => {
              location.reload();
            }, 500);
          });
      });
  }

  ngOnInit() {}
}
