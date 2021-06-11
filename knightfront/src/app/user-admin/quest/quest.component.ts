import { Component, OnInit } from '@angular/core';
import { DashboardService } from '../Services/_authService/dashboard.service';
import { GlobalService } from 'src/app/_Services/global.service';

@Component({
  selector: 'app-quest',
  templateUrl: './quest.component.html',
  styleUrls: ['./quest.component.scss']
})
export class QuestComponent implements OnInit {

  private url = "/Gift";

  userobj: any;
  basariyuzde: any;
  giftlist: any[] = [];
  constructor(private dashService: DashboardService, private globalServ: GlobalService) {
    globalServ.Get(this.url).subscribe((resp: any) => {
      this.giftlist = resp;
      console.log("gift",resp)
    })
  }

  ngOnInit() {
    this.dashService.getHomeDetails().subscribe((home: any) => {
      this.userobj = home;
      console.log(home)
      this.basariyuzde = (home.pvpWon * 100) / (home.pvpWon + home.pvpLost);
    })
  }


}
