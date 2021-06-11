import { Component, OnInit, TemplateRef } from '@angular/core';
import { GlobalService } from 'src/app/_Services/global.service';
import { DashboardService } from '../Services/_authService/dashboard.service';
import { ToastrService } from 'src/app/_Services/toastr.service';
import { BsModalService } from 'ngx-bootstrap/modal';
import { BsModalRef } from 'ngx-bootstrap/modal/bs-modal-ref.service';

@Component({
  selector: 'app-pvp',
  templateUrl: './pvp.component.html',
  styleUrls: ['./pvp.component.scss']
})
export class PvpComponent implements OnInit {

  private urlcharacter = "/CharacterDetails"
  private urlmoney = "/Money"
  private urlrakipbul = "/PVP/finduser"
  private urlsavas = "/PVP/fight"

  modalRef: BsModalRef;

  pvpobject: any = {
    userId: 0,
    opponentId: 0
  }

  goster = true;
  userobj = null;
  money = null;
  opmoney = null;
  constructor(private globalService: GlobalService,
    private modalService: BsModalService, private toast: ToastrService, private dashService: DashboardService) {
    dashService.getHomeDetails().subscribe((home: any) => {
      this.pvpobject.userId = home.id;
      globalService.GetID(this.urlmoney, home.id).subscribe((response: any) => {
        this.money = response;
      })
    })
  }

  rakipbul() {
    if (this.money.coin >= 100) {
      this.money.coin = this.money.coin - 100;
      this.globalService.Update(this.urlmoney, this.money).subscribe(resp => { })
      this.globalService.GetID(this.urlrakipbul, this.pvpobject.userId).subscribe((resp: any) => {
        this.goster = false;
        this.userobj = resp;
        this.pvpobject.opponentId = resp.id
        this.globalService.GetID(this.urlmoney, resp.id).subscribe((response: any) => {
          this.opmoney = response;
        })
      })
    }
    else {
      this.toast.Warning("Yeterli Paranız Bulunmamaktadır")
    }
  }
  savas(template, template2) {
    this.globalService.Create(this.urlsavas, this.pvpobject).subscribe((resp: any) => {
      if (resp == true) {
        this.openModal(template);
      }
      else {
        this.openModal2(template2)
      }
      this.refresh();
    })

  }
  refresh(){
    this.goster=true;
    this.globalService.GetID(this.urlmoney, this.pvpobject.userId).subscribe((response: any) => {
      this.money = response;
    })
    this.pvpobject.opponentId=0;
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  openModal2(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  ngOnInit() {
  }

}
