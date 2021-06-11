import { Component, OnInit, TemplateRef } from '@angular/core';
import { GlobalService } from 'src/app/_Services/global.service';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'src/app/_Services/toastr.service';
import { DashboardService } from '../../Services/_authService/dashboard.service';
import { BattleResult } from './BattleResult';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-moblist',
  templateUrl: './moblist.component.html',
  styleUrls: ['./moblist.component.scss']
})
export class MoblistComponent implements OnInit {

  modalRef: BsModalRef;

  private url = "/AreaMob/getmoblist";
  private urlbattle = "/Battle"
  private urlitem = "/Item"
  private urllevel="/CharacterLevel"
  param: any;
  moblist: any[] = [];

  battleobje: any = {
    mobId: null,
    characterId: null
  }
  Sonuc = new BattleResult;
  itemobje: any = null
  itemactive: boolean = false;
  harcananmana: number = 0;

  constructor(private route: ActivatedRoute,
    private toastService: ToastrService,
    private modalService: BsModalService,
    private dashService: DashboardService,
    private service: GlobalService) {
    route.params.subscribe((root: any) => {
      this.param = root.id;
      service.GetID(this.url, root.id).subscribe((resp: any) => {
        this.moblist = resp;
      })
    })
  }

  battle(mobitem, id, template, template2) {
    this.harcananmana = mobitem.manaValue;
    this.service.loading(true, "")
    this.itemobje = null;
    this.itemactive = false
    this.dashService.getHomeDetails().subscribe(resp => {
      this.battleobje.characterId = resp.id;
      this.battleobje.mobId = id;
      if (mobitem.manaValue <= resp.mana) {
        this.service.Create(this.urlbattle, this.battleobje).subscribe((result: BattleResult) => {
          this.Sonuc = result;
          if (result.exp != 0) {
            if (result.item != null) {
              this.service.GetID(this.urlitem, result.item).subscribe((respitem: any) => {
                this.itemobje = respitem;
                this.itemactive = true;
                this.service.loading(false, "");
                this.openModal(template)
                this.dashService.getHomeDetails().subscribe(resp => {
                  this.service.GetID(this.urllevel,resp.characterLevel).subscribe((response:any)=>{
                    this.service.funcmana(resp.mana,resp.experience,resp.characterLevel,response.experience)
                  })
                })

              })
            }
            else {
              this.service.loading(false, "");
              this.openModal(template);
              this.dashService.getHomeDetails().subscribe(resp => {
                this.service.GetID(this.urllevel,resp.characterLevel).subscribe((response:any)=>{
                  this.service.funcmana(resp.mana,resp.experience,resp.characterLevel,response.experience)
                })
              })
            }
          }
          else {
            this.service.loading(false, "");
            this.openModal2(template2)
            this.dashService.getHomeDetails().subscribe(resp => {
              this.service.GetID(this.urllevel,resp.characterLevel).subscribe((response:any)=>{
                this.service.funcmana(resp.mana,resp.experience,resp.characterLevel,response.experience)
              })
            })
          }

        })
      }
      else {
        this.toastService.Warning("Yetersiz Mana");
        this.service.loading(false, "");
      }
    })

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
