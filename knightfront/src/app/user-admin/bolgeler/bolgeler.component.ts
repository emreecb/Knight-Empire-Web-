import { Component, OnInit } from '@angular/core';
import { GlobalService } from 'src/app/_Services/global.service';
import { DashboardService } from '../Services/_authService/dashboard.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-bolgeler',
  templateUrl: './bolgeler.component.html',
  styleUrls: ['./bolgeler.component.scss']
})
export class BolgelerComponent implements OnInit {

  private url="/Area";
  arealist:any[]=[];
  user:any;
  constructor(private serv:GlobalService, private dash:DashboardService,private router: Router) {
    dash.getHomeDetails().subscribe(home=>{
      this.user=home;
      serv.Get(this.url).subscribe((resp:any[])=>{
        if(home.nation){
          for (let index = 0; index < resp.length; index++) {
            if(resp[index].areaName=="Luferson Castle"){
              resp.splice(index,1)
            }
            
          }
        }
        if(!home.nation){
          for (let index = 0; index < resp.length; index++) {
            if(resp[index].areaName=="El Morad Castle"){
              resp.splice(index,1)
            }
            
          }
        }
        for (let index = 0; index < resp.length; index++) {
          if(resp[index].levelCap >home.characterLevel){
            resp[index].cap=false;
          }
          else{
            resp[index].cap=true;
          }
        }
        this.arealist=resp;
      })
    })
   }
   adres(item){
     if(item.cap)
    this.router.navigate(['User/moblist',item.id]);
    else{
      alert("level cap")
    }
   }

  ngOnInit() {
  }

}
